namespace Catalyte.Apparel.Data.Model
{
    public class ShippingRate : BaseEntity
    {
        public decimal ShippingCost { get; set; }

        public string State { get; set; }
    }
}
