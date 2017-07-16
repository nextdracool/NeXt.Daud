using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Daud.Model;

namespace NeXt.Daud.ViewModels
{
    public sealed class ConfigurationViewModel : Screen
    {
        public ConfigurationViewModel()
        {
            DisplayName = "Configuration";
        }

        public AppConfig Config => AppConfig.Instance;

        public void RestoreToInitialState()
        {
            
        }
    }
}
