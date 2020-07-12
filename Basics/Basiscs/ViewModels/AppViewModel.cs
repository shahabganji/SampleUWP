using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;


namespace App1.ViewModels
{
    public class AppViewModel : ViewModel
    {
        private CancellationTokenSource _cts;
        public string Message { get; private set; }
        public ImageSource ProfileImage { get; private set; }
        public ObservableCollection<BitmapImage> Images { get; private set; }
        public ObservableCollection<Program> Programs { get; private set; }

        public AppViewModel()
        {
            this.Images = new ObservableCollection<BitmapImage>();
            this.Programs = new ObservableCollection<Program>();
        }


        public void CancelShowImagesInAFolder()
        {
            _cts?.Cancel(true);
            _cts = null;
        }

        public async Task ShowImagesInAFolder()
        {
            var picker = new FolderPicker();
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add("*");

            var folder = await picker.PickSingleFolderAsync();
            var files = await folder.GetFilesAsync();

            this.CancelShowImagesInAFolder();
            _cts = new CancellationTokenSource();

            var tasks = files.Select(file => LoadImageFromFileAsync(file, _cts.Token)).ToList();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException ex)
            {
                return;
            }

            this.Images.Clear();
            foreach (var task in tasks)
            {
                var image = await task;
                if (image != null) this.Images.Add(image);
            }
        }

        private static async Task<BitmapImage> LoadImageFromFileAsync(StorageFile file,
            CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();
            // if (cancellationToken.IsCancellationRequested)
            //     return null;

            using var stream = await file.OpenReadAsync();
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(stream);

            return bitmapImage;
        }

        public async Task PickProfileAsync()
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.Downloads;

            var file = await picker.PickSingleFileAsync();

            this.ProfileImage = await LoadImageFromFileAsync(file, CancellationToken.None);
            Notify(nameof(ProfileImage));
        }

        public async Task LoadMessageAsync()
        {
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await folder.GetFileAsync("Help.txt");
            await Task.Delay(3000); // Not: Task.Delay(3000).Wait();
            var text = await FileIO.ReadTextAsync(file);
            Message = text;
            Notify(nameof(Message));
        }

        public async Task LoadAntenPrograms()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.anten.ir/v3.1/programs");
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var allPrograms = JsonConvert.DeserializeObject<List<ProgramGroup>>(content);

                var programs = allPrograms.SelectMany(x => x.programs.Where(p => p.layoutData != null));

                this.Programs.Clear();
                foreach (var program in programs)
                {
                    this.Programs.Add(program);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}