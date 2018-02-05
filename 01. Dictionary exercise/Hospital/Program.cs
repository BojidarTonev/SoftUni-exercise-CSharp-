using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departmentAndPatients = new Dictionary<string, List<string>>();
            var doctorsAndPatients = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }
                string[] tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                //add departments and patients to them
                if (!departmentAndPatients.ContainsKey(department))
                {
                    departmentAndPatients.Add(department, new List<string>());
                    departmentAndPatients[department].Add(patient);
                }
                else
                {
                    if (departmentAndPatients[department].Count < 60)
                    {
                        departmentAndPatients[department].Add(patient);
                    }
                }

                //add doctors and their patients
                if (!doctorsAndPatients.ContainsKey(doctor))
                {
                    doctorsAndPatients.Add(doctor, new List<string>());
                    doctorsAndPatients[doctor].Add(patient);
                }
                else
                {
                    doctorsAndPatients[doctor].Add(patient);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length == 2)
                {
                    //Print for room in department
                    if (int.TryParse(tokens[1], out int room))
                    {
                        PrintPataientsInRoom(tokens, room, departmentAndPatients);
                    }
                    //Print doctors patients
                    else
                    {
                        PrintPatientsForDoctor(tokens, doctorsAndPatients);
                    }
                }
                else
                {
                    PrintDepartmentPatients(tokens, departmentAndPatients);
                }
            }
        }

        private static void PrintDepartmentPatients(string[] tokens, Dictionary<string, List<string>> departmentAndPatients)
        {
            string departmentName = tokens[0];
            foreach (var patient in departmentAndPatients[departmentName])
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatientsForDoctor(string[] tokens, Dictionary<string, List<string>> doctorsAndPatients)
        {
            string fullName = tokens[0] + " " + tokens[1];
            foreach (var patient in doctorsAndPatients[fullName].OrderBy(x => x))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPataientsInRoom(string[] tokens, int room, Dictionary<string, List<string>> departmentAndPatients)
        {
            string department = tokens[0];
            foreach (var hospitalDepartment in departmentAndPatients)
            {
                if (hospitalDepartment.Key == department)
                {
                    List<string> patientsToPrint = new List<string>();
                    for (int i = (room - 1) * 3; i < (room - 1) * 3 + 3; i++)
                    {
                        patientsToPrint.Add(hospitalDepartment.Value[i]);
                    }
                    patientsToPrint = patientsToPrint.OrderBy(x => x).ToList();
                    for (int i = 0; i < patientsToPrint.Count; i++)
                    {
                        Console.WriteLine(patientsToPrint[i]);
                    }
                    break;
                }
            }
        }
    }
}
