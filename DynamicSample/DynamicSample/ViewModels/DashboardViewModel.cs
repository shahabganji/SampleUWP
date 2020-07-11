using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Common;
using DynamicSample.Common;

namespace DynamicSample.ViewModels
{
    public sealed class DashboardViewModel : ViewModel
    {
        private string _message;
        public string  Message
        {
            get => _message;
            set
            {
                if (_message == value) return;

                _message = value;
                this.Notify();
            } }
        public override string Name => nameof(DashboardViewModel);
    }
}
