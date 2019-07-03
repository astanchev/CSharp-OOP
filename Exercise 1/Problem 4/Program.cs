namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Doctor> doctors;
        private static List<Department> departments;
        public static void Main()
        {
            doctors = new List<Doctor>();
            departments = new List<Department>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                var commandParts = CommandParts(command);

                string departamentName = commandParts[0];
                string doctorName = commandParts[1] + " " + commandParts[2];
                string patientName = commandParts[3];

                Patient patient = new Patient(patientName);

                AddDoctorsAndPatients(doctorName, patient);

                AddDepartmentAndPatients(departamentName, patient);

                command = Console.ReadLine();
            }


            command = Console.ReadLine();

            while (command != "End")
            {
                var commandParts = CommandParts(command);

                if (commandParts.Length == 1)
                {
                    PrintDepartmentPatients(commandParts);
                }
                else if (commandParts.Length == 2 && int.TryParse(commandParts[1], out int room))
                {
                    PrintRoomPatients(commandParts, room);
                }
                else
                {
                    PrintDoctorPatients(commandParts);
                }

                command = Console.ReadLine();
            }
        }

        private static string[] CommandParts(string command)
        {
            string[] commandParts = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return commandParts;
        }

        private static void PrintRoomPatients(string[] commandParts, int room)
        {
            string departmentToShow = commandParts[0];

            var currentRoom = departments
                                        .FirstOrDefault(d => d.Name == departmentToShow)
                                        .GetRooms()[room - 1];

            foreach (var patient in currentRoom.GetPatients().OrderBy(p => p.Name))
            {
                Console.WriteLine(patient.Name);
            }
        }

        private static void PrintDepartmentPatients(string[] commandParts)
        {
            string departmentToShow = commandParts[0];

            foreach (var room in departments
                                         .FirstOrDefault(d => d.Name == departmentToShow)
                                         .GetRooms()
                                         .Where(r => r.Count > 0))
            {
                foreach (var patient in room.GetPatients())
                {
                    Console.WriteLine(patient.Name);
                }
            }
        }

        private static void PrintDoctorPatients(string[] commandParts)
        {
            string doctorName = commandParts[0] + " " + commandParts[1];

            foreach (var patient in doctors
                                         .FirstOrDefault(d => d.Name == doctorName)
                                         .GetPatients()
                                         .OrderBy(p => p.Name))
            {
                Console.WriteLine(patient.Name);
            }
        }

        private static void AddDepartmentAndPatients(string departamentName, Patient patient)
        {
            Department department = new Department(departamentName);

            if (!departments.Contains(department))
            {
                departments.Add(department);
            }

            departments.FirstOrDefault(d => d.Name == departamentName)?.AddPatient(patient);
        }

        private static void AddDoctorsAndPatients(string doctorName, Patient patient)
        {
            Doctor doctor = new Doctor(doctorName);

            if (!doctors.Contains(doctor))
            {
                doctors.Add(doctor);
            }

            doctors.FirstOrDefault(d => d.Name == doctorName)?.AddPatient(patient);
        }
    }
}
