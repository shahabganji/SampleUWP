using System.Collections.Generic;
using System.Collections.ObjectModel;
using Common;
using DynamicSample.ViewModels;
using ExternalViews.ViewModels;

namespace DynamicSample.Common.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public override string Name => nameof(MainViewModel);
        public ObservableCollection<ViewModel> ViewModels { get; set; }

        private ViewModel _selectedViewModel;

        public ViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                if (_selectedViewModel == value) return;

                _selectedViewModel = value;
                this.Notify();
                this.Notify(this.SelectedViewModel.Name);
            }
        }

        public MainViewModel()
        {
            this.ViewModels = new ObservableCollection<ViewModel>();
        }

        public void Load()
        {
            this.ViewModels.Add(new FamilyViewModel());
            this.ViewModels.Add(new DashboardViewModel());
            this.ViewModels.Add(new ColleaguesViewModel());
        }

    }
}
