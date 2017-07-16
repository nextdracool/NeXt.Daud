using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Daud.Model;

namespace NeXt.Daud.ViewModels
{
    public sealed class ProfileManagerViewModel : Caliburn.Micro.Screen
    {
        public ProfileManagerViewModel()
        {
            DisplayName = "Profiles";
            ViewProfile(Config.Profiles.First());
        }

        public AppConfig Config => AppConfig.Instance;

        public ProfileEditorViewModel ActiveProfile { get; set; }

        [PropertyChanged.DependsOn(nameof(ActiveProfile))]
        public bool CanDeleteProfile =>ActiveProfile != null && !ActiveProfile.IsEditEnabled && ActiveProfile.Profile != Config.DefaultProfile;

        [PropertyChanged.DependsOn(nameof(ActiveProfile))]
        public bool CanAddProfile => !ActiveProfile?.IsEditEnabled ?? true;

        [PropertyChanged.DependsOn(nameof(ActiveProfile))]
        public bool EditButtonsVisible => ActiveProfile != null;

        public void AddProfile(Profile config_Profiles)
        {
            var p = config_Profiles?.Duplicate() ?? new Profile() { Name = "New Profile" };
            Config.Profiles.Add(p);
            EditProfile(p);
        }

        public void ViewProfile(Profile profile)
        {
            ActiveProfile = new ProfileEditorViewModel(profile) { IsEditEnabled = false };
        }

        public void EditProfile(Profile profile)
        {
            ActiveProfile = new ProfileEditorViewModel(profile) { IsEditEnabled = true };
        }

        public void DeleteProfile(Profile config_Profiles)
        {
            ActiveProfile = null;
            Config.Profiles.Remove(config_Profiles);
        }

        public void CancelEdit()
        {
            ActiveProfile.Cancel();
            ActiveProfile = null;
        }

        public void SaveEdit()
        {
            ActiveProfile.Save();
        }
    }
}
