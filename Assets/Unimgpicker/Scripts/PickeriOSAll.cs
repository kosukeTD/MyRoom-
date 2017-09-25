#if UNITY_IOS
using System.Runtime.InteropServices;

namespace Kakera
{
    internal class PickeriOSAll : IPicker
    {
        [DllImport("__Internal")]
        private static extern void UnimgpickerAll_show(string title, string outputFileName, int maxSize);

        public void Show(string title, string outputFileName, int maxSize)
        {
            UnimgpickerAll_show(title, outputFileName, maxSize);
        }
    }
}
#endif