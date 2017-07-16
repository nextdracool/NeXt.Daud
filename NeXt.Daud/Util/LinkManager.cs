using System.Runtime.InteropServices;

namespace NeXt.Daud.Util
{
    public static class LinkManager
    {
        [DllImport("kernel32.dll")]
        public static extern bool CreateSymbolicLink(string sourceFileName, string targetFileName, SymbolicLinkFlags flags);

        public enum SymbolicLinkFlags
        {
            File = 0,
            Directory = 1
        }
    }
}
