namespace FraudPrevention.Data
{
    public class Record : INormalizable
    {
        public long OrderId { get; set; }

        public long DealId { get; set; }

        public Normalizable EmailAddress { get; set; }

        public Normalizable StreetAddress { get; set; }

        public Normalizable City { get; set; }

        public Normalizable State { get; set; }

        public Normalizable ZipCode { get; set; }

        public long CreditCardNumber { get; set; }

        public void Normalize()
        {
            this.EmailAddress.Normalize();
            this.StreetAddress.Normalize();
            this.City.Normalize();
            this.ZipCode.Normalize();
            this.State.Normalize();
        }
    }
}