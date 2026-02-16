namespace PharmacyMedicineInventorySystem01
{
    public class DuplicateMedicineException : Exception
    {
        public DuplicateMedicineException(string message) : base(message) { }
    }
}
