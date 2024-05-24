namespace StudentManage
{

    internal class Program
    {

        static List<Student> studentList = new List<Student>();
 
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int option;
            do
            {
                menu.printMenu();
                option = int.Parse(Console.ReadLine());
                
                switch (option)
                {
                    //Add Student
                    case 1:
                        {
                            AddStudent();
                        }
                        break;
                    //Update 
                    case 2:
                        {
                            UpdateStudent();
                        }
                        break;
                    //Delete
                    case 3:
                        {
                            DeleteStudent();
                        }
                        break;
                    //Sort
                    case 4:
                        {
                            Sort();
                        }
                        break;
                    //Find
                    case 5:
                        {
                            FindStudent();
                        }
                        break;
                    //Highest Grade
                    case 6:
                        {
                            FindHighestScore();
                        }
                        break;
                     //Lowest Grade
                    case 7:
                        {
                            FindLowestScore();
                        }
                        break;
                     //AVG
                    case 8:
                        {
                            var StudentMaxMathAVG = studentList.OrderByDescending(s => s.Average).FirstOrDefault();
                            Console.WriteLine(StudentMaxMathAVG.ToString());
                        }
                        break;
                    case 9:
                        {
                            var BestStudentList = studentList.OrderByDescending(s => s.Average).Take(5).ToList();
                            PrintStudent(BestStudentList);
                        }break;
                }
            } while (option != 0);

        }

        //Add
        public static void AddStudent()
        {
            Console.Write("Nhap so luong sinh vien muon them:");
            int n =int.Parse(Console.ReadLine());
            while(n > 0)
            {
                Console.Write("Ten SV:");
                string Name=Console.ReadLine();
                Console.Write("Tuoi:");
                int Age = int.Parse(Console.ReadLine());
                Console.Write("Diem Toan:");
                double Math = double.Parse(Console.ReadLine());
                Console.Write("Diem Tieng Anh:");
                double English = double.Parse(Console.ReadLine());
                Student student = new Student(Name, Age, Math, English);
                studentList.Add(student);
                Console.WriteLine($"Add Student {Name} Successfully!");
                n--;
            }
            PrintStudent(studentList);
        }

        public static void FindHighestScore()
        {
            var StudentMaxMathGrade = studentList.OrderByDescending(s => s.Math).FirstOrDefault();
            var StudentMaxEngGrade = studentList.OrderByDescending(s => s.English).FirstOrDefault();
            Console.WriteLine("Math");
            Console.WriteLine(StudentMaxMathGrade.ToString());
            Console.WriteLine("Eng");
            Console.WriteLine(StudentMaxEngGrade.ToString());
        }

        public static void FindLowestScore()
        {
            var StudentLowMathGrade = studentList.OrderBy(s => s.Math).FirstOrDefault();
            var StudentLowEngGrade = studentList.OrderBy(s => s.English).FirstOrDefault();
            Console.WriteLine("Math");
            Console.WriteLine(StudentLowMathGrade.ToString());
            Console.WriteLine("Eng");
            Console.WriteLine(StudentLowEngGrade.ToString());
        }
        //Update
        public static void UpdateStudent()
        {
            Guid Id = Guid.Parse(Console.ReadLine());
            var s = studentList.Find(student => student.ID.Equals(Id));
            if (s==null)
            {
                Console.WriteLine("Student ID not exist in system");
            }
            Console.Write("Ten SV:");
            string Name = Console.ReadLine();
            s.Name = Name;
            Console.Write("Tuoi:");
            int Age = int.Parse(Console.ReadLine());
            s.Age = Age;
            Console.Write("Diem Toan:");
            double Math = double.Parse(Console.ReadLine());
            s.Math = Math;
            Console.Write("Diem Tieng Anh:");
            double English = double.Parse(Console.ReadLine());
            s.English = English;
            PrintStudent(studentList);
        }

        //Delete
        public static void DeleteStudent()
        {
            Guid Id = Guid.Parse(Console.ReadLine());
            var s = studentList.Find(student => student.ID.Equals(Id));
            if (s == null)
            {
                Console.WriteLine("Student ID not exist in system");
            }
            else
            {
                studentList.Remove(s);
                Console.WriteLine($"Delete Student {s.Name} Successfully!");
            }
        }
        //Sort
        public static void Sort()
        {
            Console.WriteLine("What you want to sort ? ");
            Console.WriteLine("1.Name - 2.Grade - 3.AVG");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("1.ASC - 2.DESC");
            int sortBy = int.Parse(Console.ReadLine());
            List<Student> result = null;
            switch (option)
            {
                case 1:
                    {

                        result = sortBy == 1 ? studentList.OrderBy(s => s.Name).ToList() : studentList.OrderByDescending(s => s.Name).ToList();
                    }
                    break;
                case 2:
                    {
                        result = sortBy == 1 ? studentList.OrderBy(s => s.Math).ThenBy(s => s.English).ToList() : studentList.OrderByDescending(s => s.Math).ThenByDescending(s => s.English).ToList();
                    }
                    break;
                case 3:
                    {
                        result = sortBy == 1 ? studentList.OrderBy(s => s.Average).ToList() : studentList.OrderByDescending(s => s.Average).ToList();
                    }
                    break;
            }
            if (result != null)
            {
                PrintStudent(result);
            }
        }
        //FindStudent 

        public static void FindStudent()
        {
            Console.Write("Student Name:");
            String Name = Console.ReadLine();
            var s = studentList.Find(student => student.Name.Contains(Name));
            Console.WriteLine(s.ToString());
        }

        //Print
        public static void PrintStudent(List<Student> listStudents)
        {
            foreach(Student s in listStudents)
            {
                Console.WriteLine(s.ToString());
            }
        }

    }
}