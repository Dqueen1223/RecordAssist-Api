namespace Catalyte.Apparel.DTOs.ShippingRate
{
    /// <summary>
    /// Describes a data transfer object for a purchase transaction billing address.
    /// </summary>
    public class ShippingRateDTO
    {
        public string State { get; set; }

        public decimal ShippingRate { get; set; }
    }
}