
using System;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public List<string> MedicalHistory { get; set; }

        public Patient()
        {
            MedicalHistory = new List<string>();
        }
    }
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<DateTime> AvailableSlots { get; set; }

        public Doctor()
        {
            AvailableSlots = new List<DateTime>();
        }
    }
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }
    }
    public class HospitalManager
    {
        private readonly List<Patient> patients = new List<Patient>();
        private readonly List<Doctor> doctors = new List<Doctor>();
        private readonly List<Appointment> appointments = new List<Appointment>();
        private int patientId = 1;
        private int doctorId = 1;
        private int appointmentIdCounter = 1;
        public void AddPatient(string name, int age, string bloodGroup)
        {
            Patient patient = new Patient()
            {
                PatientId = patientId++,
                Name = name,
                Age = age,
                BloodGroup = bloodGroup,
            };
            patients.Add(patient);
        }
        public void AddDoctor(string name, string specialization)
        {
            Doctor doctor = new Doctor()
            {
                DoctorId = doctorId++,
                Name = name,
                Specialization = specialization
            };
            doctor.AvailableSlots.Add(DateTime.Today.AddHours(10));
            doctor.AvailableSlots.Add(DateTime.Today.AddHours(12));
            doctor.AvailableSlots.Add(DateTime.Today.AddHours(15));

            doctors.Add(doctor);
        }

        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            Patient patient = null;
            Doctor doctor = null;

            foreach (Patient p in patients)
            {
                if (p.PatientId == patientId)
                {
                    patient = p;
                    break;
                }
            }

            foreach (Doctor d in doctors)
            {
                if (d.DoctorId == doctorId)
                {
                    doctor = d;
                    break;
                }
            }

            if (patient == null || doctor == null)
                return false;

            bool slotAvailable = false;
            foreach (DateTime slot in doctor.AvailableSlots)
            {
                if (slot == time)
                {
                    slotAvailable = true;
                    break;
                }
            }

            if (!slotAvailable)
                return false;

            Appointment appointment = new Appointment
            {
                AppointmentId = appointmentIdCounter++,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentTime = time,
                Status = "Scheduled"
            };

            appointments.Add(appointment);
            doctor.AvailableSlots.Remove(time);

            return true;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            Dictionary<string, List<Doctor>> grouped =
                new Dictionary<string, List<Doctor>>();

            foreach (Doctor doctor in doctors)
            {
                if (!grouped.ContainsKey(doctor.Specialization))
                {
                    grouped[doctor.Specialization] = new List<Doctor>();
                }
                grouped[doctor.Specialization].Add(doctor);
            }
            return grouped;
        }

        public List<Appointment> GetTodayAppointments()
        {
            List<Appointment> todayAppointment = new List<Appointment>();
            DateTime today = DateTime.Now;
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentTime.Date == today)
                {
                    todayAppointment.Add(appointment);
                }
            }
            return todayAppointment;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            HospitalManager manager = new HospitalManager();

            while (true)
            {
                Console.WriteLine("===== Hospital Patient Management =====");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Schedule Appointment");
                Console.WriteLine("4. View Doctors by Specialization");
                Console.WriteLine("5. View Today's Appointments");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Patient Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Enter Blood Group: ");
                    string bloodGroup = Console.ReadLine();

                    manager.AddPatient(name, age, bloodGroup);

                    Console.WriteLine("Patient added successfully.\n");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Doctor Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Specialization: ");
                    string specialization = Console.ReadLine();

                    manager.AddDoctor(name, specialization);

                    Console.WriteLine("Doctor added successfully with available slots:");
                    Console.WriteLine("10:00, 12:00, 15:00\n");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Patient ID: ");
                    int patientId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Doctor ID: ");
                    int doctorId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Appointment Time (yyyy-MM-dd HH:mm): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());

                    bool success = manager.ScheduleAppointment(patientId, doctorId, time);

                    if (success)
                    {
                        Console.WriteLine("Appointment scheduled successfully.");
                        Console.WriteLine($"Patient ID: {patientId}");
                        Console.WriteLine($"Doctor ID: {doctorId}");
                        Console.WriteLine($"Time: {time}\n");
                    }
                    else
                    {
                        Console.WriteLine("Failed to schedule appointment.");
                        Console.WriteLine("Reason: Invalid IDs or slot not available.\n");
                    }
                }
                else if (choice == 4)
                {
                    var grouped = manager.GroupDoctorsBySpecialization();

                    if (grouped.Count == 0)
                    {
                        Console.WriteLine("No doctors available.\n");
                    }
                    else
                    {
                        Console.WriteLine("Doctors by Specialization:");
                        foreach (var group in grouped)
                        {
                            Console.WriteLine($"Specialization: {group.Key}");
                            foreach (Doctor d in group.Value)
                            {
                                Console.WriteLine($"Doctor ID: {d.DoctorId}, Name: {d.Name}");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == 5)
                {
                    var todayAppointments = manager.GetTodayAppointments();

                    if (todayAppointments.Count == 0)
                    {
                        Console.WriteLine("No appointments scheduled for today.\n");
                    }
                    else
                    {
                        Console.WriteLine("Today's Appointments:");
                        foreach (Appointment a in todayAppointments)
                        {
                            Console.WriteLine(
                                $"Appointment ID: {a.AppointmentId}, " +
                                $"Patient ID: {a.PatientId}, " +
                                $"Doctor ID: {a.DoctorId}, " +
                                $"Time: {a.AppointmentTime}, " +
                                $"Status: {a.Status}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Exiting system. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.\n");
                }
            }
        }
    }
}