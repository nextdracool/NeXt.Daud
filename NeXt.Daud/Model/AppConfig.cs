using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace NeXt.Daud.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class AppConfig
    {
        [JsonConstructor]
        private AppConfig() { }

        private AppConfig(bool defaultConfig)
        {
            //TODO: enable first run by default
            FirstRun = false;
            Profiles = new ObservableCollection<Profile>
            {
                Profile.Default
            };
            DefaultProfile = Profile.Default;
            CurrentProfile = Profile.Default;
        }

        

        /// <summary>
        /// Triggers initial configuration dialog
        /// </summary>
        public bool FirstRun { get; set; }

        #region configuration
        /// <summary>
        /// Use seperate save games per profile
        /// </summary>
        [JsonProperty("seperate_savegames_per_profile")]
        public bool SeperateSavegamesPerProfile { get; set; }
        #endregion

        #region profiles
        [JsonProperty("profiles")]
        public ObservableCollection<Profile> Profiles { get; set; }
        [JsonProperty("profile_default",IsReference = true)]
        public Profile DefaultProfile { get; set; }
        [JsonProperty("profile_currnet", IsReference = true)]
        public Profile CurrentProfile { get; set; }
        #endregion
        
        public static AppConfig Instance { get; private set; } = new AppConfig(true);

        /// <summary>
        /// Loads the configuration from file, if it exists
        /// </summary>
        /// <param name="fileName">the file to load form</param>
        public static void Load(string fileName)
        {
            try
            {
                using (var reader = new JsonTextReader(new StreamReader(fileName)))
                {
                    Instance = JsonSerializer.CreateDefault().Deserialize<AppConfig>(reader);
                    Instance.FirstRun = false;
                }
            }
            catch(IOException) { }
            catch(JsonException) { }
        }
    }
}
