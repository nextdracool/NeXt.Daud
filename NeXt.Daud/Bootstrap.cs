using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NeXt.Daud.Model;

namespace NeXt.Daud
{
    public class Bootstrap : BootstrapperBase
    {
        public Bootstrap()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            AppConfig.Load(FileManager.ConfigFileName);
            DisplayRootViewFor<ViewModels.MainViewModel>();
        }
    }
}
