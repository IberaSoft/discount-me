using System;

namespace DiscountMe.BL.DTO {
    public class DiscountDTO {
        #region Primitive Properties

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public double? DiscountPercent { get; set; }

        public int? StockQuantity { get; set; }

        public int? StockWarningLevel { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? UntilDate { get; set; }

        public bool? IsPublished { get; set; }

        public string Comment { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        #endregion
    }
}