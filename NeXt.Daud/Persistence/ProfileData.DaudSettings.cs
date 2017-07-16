using Newtonsoft.Json;

namespace NeXt.Daud.Persistence
{
    public partial class ProfileData
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class DaudSettings
        {
            [JsonProperty("knife_of_dunwall")]
            public bool KnifeOfDunwall { get; set; }

            [JsonProperty("brigmore_witches")]
            public bool BrigmoreWitches { get; set; }
        }
    }
}
