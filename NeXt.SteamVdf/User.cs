using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.SteamVdf
{
    public class User
    {
        public User(string name, long id, string avatar)
        {
            Username = name;
            SteamId64 = id;
            AvatarCachePath = avatar;
        }

        public string Username { get; }
        public long SteamId64 { get; }
        public long SteamId3 => (SteamId64 >> 56) & 0xffffffff;
        public string AvatarCachePath { get; }
    }
}
