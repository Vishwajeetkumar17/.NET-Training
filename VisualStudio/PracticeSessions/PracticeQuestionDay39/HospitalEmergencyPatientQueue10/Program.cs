using System;
using System.Collections.Generic;

namespace HospitalEmergencyPatientQueue10
{

    class Program
    {
        static void Main(string[] args)
        {
            PatientUtility utility = new PatientUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Patients by Priority");
                Console.WriteLine("2 -> Update Severity");
                Console.WriteLine("3 -> Add Patient");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayPatients();
                            break;

                        case 2:
                            Console.WriteLine("Enter Patient ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New Severity Level:");
                            int newSeverity = int.Parse(Console.ReadLine());

                            utility.UpdateSeverity(id, newSeverity);
                            Console.WriteLine("Severity Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter PatientId Name SeverityLevel:");
                            string[] input = Console.ReadLine().Split(' ');

                            string patientId = input[0];
                            string name = input[1];
                            int severity = int.Parse(input[2]);

                            Patient patient = new Patient(patientId, name, severity);
                            utility.AddPatient(patient);

                            Console.WriteLine("Patient Added Successfully");
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
