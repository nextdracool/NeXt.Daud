using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using NeXt.Daud.Model;

namespace NeXt.Daud.ViewModels
{
    public sealed class ProfileEditorViewModel : PropertyChangedBase
    {
        public ProfileEditorViewModel(Profile p)
        {
            Profile = p;
            EditingProfile = p?.Clone();
        }
        
        public bool IsEditEnabled { get; set; }
        public Profile EditingProfile { get; }
        public Profile Profile { get;}

        public bool IsSavegameManagementEnabled => AppConfig.Instance.SeperateSavegamesPerProfile;

        public void Save()
        {
            Profile?.Update(EditingProfile);
        }

        public void Cancel()
        {
            EditingProfile?.Update(Profile);
        }
    }
}
