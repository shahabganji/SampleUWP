using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DynamicSample.Common;

namespace DynamicSample.ViewModels
{
    public sealed class FamilyViewModel : ViewModel
    {
        public override string Name => nameof(FamilyViewModel);

        public ICollection<string> Members { get; set; }

        public FamilyViewModel()
        {
            this.Members = new List<string>
            {
                "Shahab",  "Mansooreh" , "Bahar", "Ali Abbas"
            };
        }

    }
}
