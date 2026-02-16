namespace PharmacyMedicineInventorySystem01
{
    public class MedicineUtility
    {
        private SortedDictionary<int, List<Medicine>> medicines = new SortedDictionary<int, List<Medicine>>();

        public void AddMedicine(Medicine medicine)
        {
            if (medicine.Price <= 0)
                throw new InvalidPriceException("Invalid Price");

            if (medicine.ExpiryYear < DateTime.Now.Year)
                throw new InvalidExpiryYearException("Invalid Expiry Year");


            foreach (var list in medicines.Values)
            {
                foreach (var med in list)
                {
                    if (med.Id.Equals(medicine.Id))
                        throw new DuplicateMedicineException("Duplicate Medicine");
                }
            }

            if (!medicines.ContainsKey(medicine.ExpiryYear))
            {
                medicines[medicine.ExpiryYear] = new List<Medicine>();
            }

            medicines[medicine.ExpiryYear].Add(medicine);
        }

        public void GetAllMedicines()
        {
            foreach (var entry in medicines)
            {
                foreach (var med in entry.Value)
                {
                    Console.WriteLine($"Details: {med.Id} {med.Name} {med.Price} {med.ExpiryYear}");
                }
            }
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if (newPrice <= 0)
                throw new InvalidPriceException("Invalid Price");

            foreach (var list in medicines.Values)
            {
                foreach (var med in list)
                {
                    if (med.Id.Equals(id))
                    {
                        med.Price = newPrice;
                        return;
                    }
                }
            }

            throw new MedicineNotFoundException("Medicine Not Found");
        }
    }
}
