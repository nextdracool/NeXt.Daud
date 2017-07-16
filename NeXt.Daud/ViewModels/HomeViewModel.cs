using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Daud.Model;

namespace NeXt.Daud.ViewModels
{
    public sealed class HomeViewModel : Screen
    {
        public HomeViewModel()
        {
            DisplayName = "Home";
        }

        public AppConfig Config => AppConfig.Instance;
    }
}
