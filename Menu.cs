using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage
{
    public class Menu
    {

        public Menu() { 
        
        }

        public  void printMenu()
        {
                Console.WriteLine("--------Choose your option--------- \n" + "0. Out\n" + "1.  Add\n" + "2.  Update\n" + "3.  Delete\n" + "4.  Sort\n" + "5.  Find\n" + "6.  Highest Grade\n" + "7.  Lowest Grade\n" + "8. AVG Each Subject\n" + "9. 5 best student\n"
                    );
        }
            

        
    }
}
