using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using NeXt.Daud.Model;
using NeXt.Daud.Model.Updates;

namespace NeXt.Daud.ViewModels
{
    public sealed class UpdateManagerViewModel : PropertyChangedBase
    {
        public UpdateManagerViewModel(UpdateManager mgr)
        {
            Updater = mgr;
        }

        public UpdateManager Updater { get; set; }

        public void Execute()
        {
            Updater.Execute();
        }
    }
}
