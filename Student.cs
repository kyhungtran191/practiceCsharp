using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage
{
    public class Student
    {

         public Guid ID { get; set; }
         public string Name { get; set; }
         public int Age { get; set; }
         public double Math { get; set; }
         public double English { get; set; }
         public double Average { get; set; }

        public Student( string Name, int Age, double Math, double English)
        {
            this.ID = Guid.NewGuid(); 
            this.Name = Name;
            this.Age = Age;
            this.Math= Math;
            this.English = English;
            this.Average = (this.Math + this.English) / 2; 
        }

        public void Studying()
        {
            Console.WriteLine($"Student {Name} is studying...");
        }

        public override string ToString()
        {
            return $"ID: {ID} - Name: {Name} - Age:{Age} - Grade Math: {Math} - Grade EngLish: {English} - Average: {Average}";
        }
    }
}
