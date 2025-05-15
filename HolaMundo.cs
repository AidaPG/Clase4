using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Define the Student class
    class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string Course { get; set; }
        public double PreEval { get; set; }
        public double MidTermEval { get; set; }
        public double FinalEval { get; set; }
    }

    static List<Student> students = new List<Student>();
    static string filePath = "students.csv";

    static void Main(string[] args)
    {
        LoadStudentsFromFile();

        while (true)
        {
            Console.WriteLine("\nStudent Menu:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Modify Student");
            Console.WriteLine("4. Search Student");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    DeleteStudent();
                    break;
                case "3":
                    ModifyStudent();
                    break;
                case "4":
                    SearchStudent();
                    break;
                case "5":
                    SaveStudentsToFile();
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Student student = new Student();

        Console.Write("Enter Name: ");
        student.Name = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        student.LastName = Console.ReadLine();

        Console.Write("Enter ID: ");
        student.ID = Console.ReadLine();

        Console.Write("Enter Course: ");
        student.Course = Console.ReadLine();

        Console.Write("Enter Pre-Evaluation Score: ");
        student.PreEval = double.Parse(Console.ReadLine());

        Console.Write("Enter Mid-Term Evaluation Score: ");
        student.MidTermEval = double.Parse(Console.ReadLine());

        Console.Write("Enter Final Evaluation Score: ");
        student.FinalEval = double.Parse(Console.ReadLine());

        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter the ID of the student to delete: ");
        string id = Console.ReadLine();

        Student student = students.Find(s => s.ID == id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void ModifyStudent()
    {
        Console.Write("Enter the ID of the student to modify: ");
        string id = Console.ReadLine();

        Student student = students.Find(s => s.ID == id);
        if (student != null)
        {
            Console.Write("Enter New Name (leave blank to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) student.Name = name;

            Console.Write("Enter New Last Name (leave blank to keep current): ");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastName)) student.LastName = lastName;

            Console.Write("Enter New Course (leave blank to keep current): ");
            string course = Console.ReadLine();
            if (!string.IsNullOrEmpty(course)) student.Course = course;

            Console.Write("Enter New Pre-Evaluation Score (leave blank to keep current): ");
            string preEval = Console.ReadLine();
            if (!string.IsNullOrEmpty(preEval)) student.PreEval = double.Parse(preEval);

            Console.Write("Enter New Mid-Term Evaluation Score (leave blank to keep current): ");
            string midTermEval = Console.ReadLine();
            if (!string.IsNullOrEmpty(midTermEval)) student.MidTermEval = double.Parse(midTermEval);

            Console.Write("Enter New Final Evaluation Score (leave blank to keep current): ");
            string finalEval = Console.ReadLine();
            if (!string.IsNullOrEmpty(finalEval)) student.FinalEval = double.Parse(finalEval);

            Console.WriteLine("Student modified successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter the ID of the student to search: ");
        string id = Console.ReadLine();

        Student student = students.Find(s => s.ID == id);
        if (student != null)
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Last Name: {student.LastName}");
            Console.WriteLine($"ID: {student.ID}");
            Console.WriteLine($"Course: {student.Course}");
            Console.WriteLine($"Pre-Evaluation Score: {student.PreEval}");
            Console.WriteLine($"Mid-Term Evaluation Score: {student.MidTermEval}");
            Console.WriteLine($"Final Evaluation Score: {student.FinalEval}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void SaveStudentsToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.Name},{student.LastName},{student.ID},{student.Course},{student.PreEval},{student.MidTermEval},{student.FinalEval}");
            }
        }
        Console.WriteLine("Students saved to file successfully.");
    }

    static void LoadStudentsFromFile()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    Student student = new Student
                    {
                        Name = data[0],
                        LastName = data[1],
                        ID = data[2],
                        Course = data[3],
                        PreEval = double.Parse(data[4]),
                        MidTermEval = double.Parse(data[5]),
                        FinalEval = double.Parse(data[6])
                    };
                    students.Add(student);
                }
            }
            Console.WriteLine("Students loaded from file successfully.");
        }
    }
}