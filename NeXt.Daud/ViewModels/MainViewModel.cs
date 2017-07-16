using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NeXt.Daud.Model;

namespace NeXt.Daud.ViewModels
{
    public sealed class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public MainViewModel()
        {
            DisplayName = "NeXt Dishonored Manager";

            if (AppConfig.Instance.FirstRun)
            {
                Items.Add(new FirstRunViewModel());
            }
            else
            {
                Items.Add(new HomeViewModel());
                Items.Add(new ProfileManagerViewModel());
                Items.Add(new ConfigurationViewModel());
            }
        }

        public void FinishFirstRun()
        {
            AppConfig.Instance.FirstRun = false;
            Items.Clear();
            Items.Add(new HomeViewModel());
            Items.Add(new ProfileManagerViewModel());
            Items.Add(new ConfigurationViewModel());
        }
    }
}
