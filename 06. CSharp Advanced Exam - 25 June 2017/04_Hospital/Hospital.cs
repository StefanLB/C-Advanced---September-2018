using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<string, Dictionary<int, List<string>>> departments = new Dictionary<string, Dictionary<int, List<string>>>();
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            while (input != "Output")
            {
                string department = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                string doctor = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1] + " " +
                                input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
                string patient = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];

                bool movedToDiffHospital = false;
                AddToDepartments(departments, department, patient, ref movedToDiffHospital);

                if (!movedToDiffHospital)
                {
                    AddToDoctors(doctors, doctor, patient);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                PrintRequest(departments, doctors, input);
                input = Console.ReadLine();
            }

        }

        static void PrintRequest(Dictionary<string, Dictionary<int, List<string>>> departments, Dictionary<string, List<string>> doctors, string input)
        {
            var tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (doctors.ContainsKey(input.Trim()))
            {
                PrintDoctor(doctors[input.Trim()]);
            }
            else if (departments.ContainsKey(input.Trim()))
            {
                PrintDepartment(departments[input.Trim()]);
            }
            else if (tokens.Count() > 1 && departments.ContainsKey(tokens[0].Trim()))
            {
                int roomNumber = int.Parse(tokens[1]);

                if (departments[tokens[0].Trim()].ContainsKey(roomNumber))
                {
                    PrintDepartmentRoom(departments[tokens[0].Trim()], roomNumber);
                }
            }
        }

        static void PrintDepartmentRoom(Dictionary<int, List<string>> selectedDepartment, int roomNumber)
        {
            foreach (var healed in selectedDepartment[roomNumber].OrderBy(x => x))
            {
                Console.WriteLine(healed);
            }
        }

        static void PrintDepartment(Dictionary<int, List<string>> departmentRooms)
        {
            for (int i = 1; i <= departmentRooms.Keys.Count; i++)
            {
                foreach (var healed in departmentRooms[i])
                {
                    Console.WriteLine(healed);
                }
            }
        }

        static void PrintDoctor(List<string> doctorPatients)
        {
            foreach (var healed in doctorPatients.OrderBy(x => x))
            {
                Console.WriteLine(healed);
            }
        }

        static void AddToDoctors(Dictionary<string, List<string>> doctors, string doctor, string patient)
        {
            if (!doctors.ContainsKey(doctor))
            {
                doctors.Add(doctor, new List<string>());
            }

            doctors[doctor].Add(patient);
        }

        static void AddToDepartments(Dictionary<string, Dictionary<int, List<string>>> departments, string department, string patient, ref bool movedToDiffHospital)
        {
            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new Dictionary<int, List<string>>());
                departments[department].Add(1, new List<string> { patient });
                return;
            }

            if (departments[department].Last().Value.Count < 3)
            {
                departments[department].Last().Value.Add(patient);
            }
            else if (departments[department].Last().Value.Count >= 3 && departments[department].Last().Key < 20)
            {
                departments[department].Add((departments[department].Last().Key + 1), new List<string> { patient });
            }
            else
            {
                movedToDiffHospital = true;
            }
        }

    }
}
