using System;
using Avalonia;
using Avalonia.Platform;

namespace HoNPrivateServerLanucher.UI
{
    public class HoNClient
    {
        public void OpenHoN()
        {
            var platform = AvaloniaLocator.Current.GetService<IRuntimePlatform>()?.GetRuntimeInfo().OperatingSystem ?? OperatingSystemType.Unknown;

            switch (platform)
            {
                case OperatingSystemType.WinNT:
                    OpenHoNWindows();
                    break;
                case OperatingSystemType.OSX:
                    OpenHoNMacOS();
                    break;
                default:
                    throw new InvalidOperationException($"Cannot open HoN. Unsupported platform: {platform}");
            }
        }

        private void OpenHoNWindows()
        {

        }

        private void OpenHoNMacOS()
        {

        }
    }
}
