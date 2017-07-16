using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NeXt.Daud.Model;

namespace NeXt.Daud.ViewModels
{
    public sealed class FirstRunViewModel : Screen
    {
        public FirstRunViewModel()
        {
            DisplayName = "First Run";
            Manager = new FirstRunManager();
            Updater = new UpdateManagerViewModel(Manager.Updater);
        }

        public FirstRunManager Manager { get; set; }

        [PropertyChanged.DependsOn(nameof(Manager))]
        public UpdateManagerViewModel Updater { get; set; }
    }
}
