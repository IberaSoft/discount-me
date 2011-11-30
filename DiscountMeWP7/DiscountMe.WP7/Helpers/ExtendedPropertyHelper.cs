using Microsoft.Phone.Info;

namespace DiscountMe.WP7.Helpers {
    public static class ExtendedPropertyHelper {
        private const int ANIDLength = 32;
        private const int ANIDOffset = 2;

        public static string GetManufacturer() {
            var result = string.Empty;
            object manufacturer;
            if (DeviceExtendedProperties.TryGetValue("DeviceManufacturer", out manufacturer))
                result = manufacturer.ToString();
            return result;
        }

        // Note: to get a result requires ID_CAP_IDENTITY_DEVICE
        // to be added to the capabilities of the WMAppManifest
        // this will then warn users in marketplace
        public static byte[] GetDeviceUniqueId() {
            byte[] result = null;
            object uniqueId;
            if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out uniqueId))
                result = (byte[]) uniqueId;
            return result;
        }

        // NOTE: to get a result requires ID_CAP_IDENTITY_USER
        // to be added to the capabilities of the WMAppManifest
        // this will then warn users in marketplace
        public static string GetWindowsLiveAnonymousId() {
            var result = string.Empty;
            object anid;
            if (UserExtendedProperties.TryGetValue("ANID", out anid)) {
                if (anid != null && anid.ToString().Length >= (ANIDLength + ANIDOffset)) {
                    result = anid.ToString().Substring(ANIDOffset, ANIDLength);
                }
            }
            return result;
        }
    }
}