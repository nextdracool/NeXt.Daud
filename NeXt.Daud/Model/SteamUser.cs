using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace NeXt.Daud.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SteamUser
    {
        public SteamUser(string name, ulong id)
        {
            Username = name;
            SteamId64 = id;
        }

        [JsonProperty("username")]
        public string Username { get; }

        [JsonProperty("steamid64")]
        public ulong SteamId64 { get; }
        [JsonProperty("steamid3")]
        public ulong SteamId3 => (SteamId64 >> 56);
    }
}
