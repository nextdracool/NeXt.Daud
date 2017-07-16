using NeXt.Vdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.SteamVdf
{
    public class SteamConfiguration
    {
        private readonly Steam Steam;
        public SteamConfiguration(Steam steam)
        {
            Steam = steam;
            users = new Lazy<IReadOnlyList<User>>(() => new List<User>(GetUserList()).AsReadOnly(), isThreadSafe: true);
        }
        private Lazy<IReadOnlyList<User>> users;



        public IReadOnlyList<User> LoginUsers => users.Value;







        private IEnumerable<User> GetUserList()
        {
            var cfgdir = Path.Combine(Steam.Folder, "config");
            var ulist = VdfDeserializer.FromFile(Path.Combine(cfgdir, "loginusers.vdf")).Deserialize() as VdfTable;

            foreach (var item in ulist)
            {
                var uid = item.Name;
                var uname = ((item as VdfTable)["PersonaName"] as VdfString).Content;
                var avt = Path.Combine(cfgdir, "avatarcache", Path.ChangeExtension(uid, ".png"));

                yield return new User(uname, long.Parse(uid), avt);
            }
        }

    }
}
