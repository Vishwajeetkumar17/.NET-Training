namespace HospitalEmergencyPatientQueue10
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(string message) : base(message) { }
    }
}
