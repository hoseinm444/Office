using System;
using Office.ChildPersonnel.Endpoin;
using Office.PersonnelMainOffice.Endpoint;
using Office.Organazation.Endpoint;
using Office.Personnel.Endpoint;
using Office.Permission.Endpoint;


namespace Office.Domain
{
    public class Program
    {
        public static void MainMenu()
        {
            int request = 0;
        MainMenu:
            /////////////Menu
            Console.WriteLine("-------------------------------------- Main Menu ------------------------------ ");
            Console.WriteLine("              Choose something you want by Enter it's numbers :   1 or 2 or 3 or 4 or 5 or 6 or 7       ");
            Console.WriteLine("              1-Personnels            ");
            Console.WriteLine("              2-Permissions             ");
            Console.WriteLine("              3-Offices              ");
            Console.WriteLine("              4-Children             ");
            Console.WriteLine("              5-Personnel Main Office            ");
            Console.WriteLine("              6-Menu                     ");
            Console.WriteLine("              7-Exit                   ");
            try
            {
                request = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("you can't Enter character or string values , just numbers");
                goto MainMenu;
            }

            if (request == 1)
            {
                PersonnelEndpoint.Personnel();
                goto MainMenu;
            }
            else if (request == 2)
            {
                PermissionEndpoint.Permission();
                goto MainMenu;
            }
            else if (request == 3)
            {
                OrganazationEndpoint.Organazation();
                goto MainMenu;
            }
            else if (request == 4)
            {
                ChildEndpoint.Children();
                goto MainMenu;
            }
            else if (request == 5)
            {
                PersonnelMainOfficeEndpoint.PMO();
                goto MainMenu;
            }
            else if (request == 6)
            {
                goto MainMenu;
            }
            else if (request == 7)
            {
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("                                GoodBye Bro                              ");
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
                return;
            }
            else if (request <= 0 || request > 7)
            {
                Console.WriteLine("you Should Enter  menu's numbers .");
                goto MainMenu;
            }
        }
        //public static void Main(string[] args)
        //{
        //    MainMenu();
        //}


    }
}



