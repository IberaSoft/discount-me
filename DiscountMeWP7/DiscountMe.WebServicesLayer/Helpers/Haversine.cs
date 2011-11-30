using System;
using DiscountMe.BL;

namespace DiscountMe.WebServicesLayer {
    /// <summary>
    /// The distance type to return the results in.
    /// </summary>
    public enum DistanceType { Miles, Kilometers };

    /// <summary>
    /// Specifies a Latitude / Longitude point.
    /// </summary>
    public struct Position {
        public double Latitude;
        public double Longitude;
    }

    public class Haversine {
        /// <summary>
        /// Returns the distance in miles or kilometers of any two
        /// latitude / longitude points.
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static double Distance(GeoZone pos1, GeoZone pos2, DistanceType type) {
            double R = (type == DistanceType.Miles) ? 3960 : 6371;

            double dLat = ToRadian(pos2.Latitude - pos1.Latitude);
            double dLon = ToRadian(pos2.Longitude - pos1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadian(pos1.Latitude)) * Math.Cos(ToRadian(pos2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }

        /// <summary>
        /// Convert to Radians.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static double ToRadian(double val) {
            return (Math.PI / 180) * val;
        }
    }
}