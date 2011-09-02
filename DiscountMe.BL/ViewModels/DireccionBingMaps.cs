namespace DiscountMe.BL.ViewModels {
    public class DireccionBingMaps {
        public string AddressLine { get; set; }
        public string AdminDistrict { get; set; }
        public string AdminDistrict2 { get; set; }
        public string CountryRegion { get; set; }
        public string FormattedAddress { get; set; }
        public string Locality { get; set; }
        public string PostalCode { get; set; }

        public override string ToString() {
            return AddressLine;
        }
    }
}