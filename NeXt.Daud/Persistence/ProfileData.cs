using System;
using Newtonsoft.Json;

namespace NeXt.Daud.Persistence
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ProfileData
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("speedrun")]
        public SpeedrunSettings Speedrun { get; set; }

        [JsonProperty("daud")]
        public DaudSettings Daud { get; set; }

        [JsonProperty("movies")]
        public MovieSettings Movies { get; set; }
    }
}
