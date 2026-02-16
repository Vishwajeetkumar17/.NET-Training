namespace HospitalEmergencyPatientQueue10
{
    public class Patient
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public int SeverityLevel { get; set; }

        public Patient(string patientId, string name, int severityLevel)
        {
            if (severityLevel <= 0)
                throw new InvalidSeverityLevelException("Invalid Severity Level");

            PatientId = patientId;
            Name = name;
            SeverityLevel = severityLevel;
        }
    }
}
