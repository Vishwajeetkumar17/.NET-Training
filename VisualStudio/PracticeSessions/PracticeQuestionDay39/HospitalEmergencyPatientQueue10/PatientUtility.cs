namespace HospitalEmergencyPatientQueue10
{
    public class PatientUtility
    {
        private SortedDictionary<int, Queue<Patient>> patients = new SortedDictionary<int, Queue<Patient>>();

        public void AddPatient(Patient patient)
        {
            if (!patients.ContainsKey(patient.SeverityLevel))
                patients[patient.SeverityLevel] = new Queue<Patient>();

            patients[patient.SeverityLevel].Enqueue(patient);
        }

        public void DisplayPatients()
        {
            foreach (var entry in patients)
            {
                foreach (var p in entry.Value)
                {
                    Console.WriteLine($"Details: {p.PatientId} {p.Name} {p.SeverityLevel}");
                }
            }
        }

        public void UpdateSeverity(string patientId, int newSeverity)
        {
            if (newSeverity <= 0)
                throw new InvalidSeverityLevelException("Invalid Severity Level");

            foreach (var entry in patients)
            {
                int currentSeverity = entry.Key;
                foreach (var p in entry.Value)
                {
                    if (p.PatientId.Equals(patientId))
                    {
                        entry.Value.Dequeue();

                        p.SeverityLevel = newSeverity;

                        if (!patients.ContainsKey(newSeverity))
                            patients[newSeverity] = new Queue<Patient>();

                        patients[newSeverity].Enqueue(p);
                        return;
                    }
                }
            }

            throw new PatientNotFoundException("Patient Not Found");
        }
    }
}
