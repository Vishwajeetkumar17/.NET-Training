namespace PharmacyMedicineInventorySystem01
{
    public class InvalidExpiryYearException : Exception
    {
        public InvalidExpiryYearException(string message) : base(message) { }
    }
}
