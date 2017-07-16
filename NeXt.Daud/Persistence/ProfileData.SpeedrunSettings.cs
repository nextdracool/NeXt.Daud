using Newtonsoft.Json;

namespace NeXt.Daud.Persistence
{
    public partial class ProfileData
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class SpeedrunSettings
        {
            [JsonProperty("engine")]
            public bool Engine { get; set; }

            [JsonProperty("keybinds")]
            public bool Keybinds { get; set; }
        }
    }
}
