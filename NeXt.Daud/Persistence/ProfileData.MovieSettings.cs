using Newtonsoft.Json;

namespace NeXt.Daud.Persistence
{
    public partial class ProfileData
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class MovieSettings
        {
            [JsonProperty("disable_intro")]
            public bool Intro { get; set; }

            [JsonProperty("disable_loadscreen")]
            public bool Loadscreen { get; set; }
        }
    }
}
