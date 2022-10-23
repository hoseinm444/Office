using System;
using Office.DataLayer.Models;
using Office.DataLayer.Context;
using Office.DataLayer.Services;

namespace Office.Personnel.Endpoint
{
    public class PersonnelEndpoint 
    {
        public static void Personnel()
        {
            IUnitOfWork uow = new OrganazationDbContext();
            PersonnelService personelService = new PersonnelService(uow);
            int request;
        Menu:
            /////////////Menu
            Console.WriteLine("----------------------------Personnel Menu ------------------------------ ");
            Console.WriteLine("              Choose something you want by Enter it's numbers :   1 or 2 or 3 or 4 or 5 or 6       ");
            Console.WriteLine("              1-Get All Personnel            ");
            Console.WriteLine("              2-Insert Personnel             ");
            Console.WriteLine("              3-Delet Personnel              ");
            Console.WriteLine("              4-Update Personnel              ");
            Console.WriteLine("              5-How many child a personnel has        ");
            Console.WriteLine("              6-Menu             ");
            Console.WriteLine("              7-MainMenu                    ");
            try
            {
                request = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("you can't Enter character or string values , just numbers");
                goto Menu;
            }

            ////////////////////////////////get all
            if (request == 1)
            {
                Console.WriteLine("----------------------------GetAll Personnel ------------------------------ ");

                foreach (var pers in personelService.GetAllPersonnel())
                {
                    Console.WriteLine($"  Personnel Name={ pers.Name}    ,     Family:{pers.Family}" +
                        $" ,   NationalCode: {pers.NationalCode}  ,    Gender:{pers.PersonnelGender}");
                }
                goto Menu;
            }

            /////////////////////////////////////////////insert
            else if (request == 2)
            {
                Console.WriteLine("------------------------------- Personnel Insert ---------------------------- ");

                Console.WriteLine("Do you want to insert any Personnel  ? yes or no  ");
                string questionInsert = Console.ReadLine();
                string OkAnswerInset = "yes";
                string NoAnswerInsert = "no";

                var p = new DataLayer.Models.Personnel { };

                if (questionInsert == OkAnswerInset)
                {
                    Console.WriteLine("Please Enter Personnel Name :");
                    var name = p.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel Family :");
                    var family = p.Family = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel National Code: ");
                    p.NationalCode = Console.ReadLine();



                    Console.WriteLine("Please Enter a gender you must Enter 1:Men & 2:Wemon");
                    int g = Convert.ToInt32(Console.ReadLine());
                    if (g == 1) { p.PersonnelGender = Gender.Men; }
                    else if (g == 2) { p.PersonnelGender = Gender.Wemon; }

                    personelService.InsertPersonnel(p);
                    uow.save();
                }
                else if (questionInsert == NoAnswerInsert)
                {
                    Console.WriteLine("  ");
                    goto Menu;
                }
                goto Menu;
            }

            /////////////////////////////////////////delet
            else if (request == 3)
            {
                Console.WriteLine("---------------------------- Delete Personnel  -------------------------- ");

                Console.WriteLine("Do you want to delete any Personnel  ? yes or no  ");
                string question = Console.ReadLine();
                string OkAnswer = "yes";
                string NoAnswer = "no";
                var pe = new DataLayer.Models.Personnel { };

                Console.WriteLine("Personnel List:");
                foreach (var pers in personelService.GetAllPersonnel())
                {
                    Console.WriteLine($"  Personnel Name={ pers.Name}    ,     Family:{pers.Family}" +
                        $" ,   NationalCode: {pers.NationalCode}  ,    Gender:{pers.PersonnelGender}");
                }

                if (question == OkAnswer)
                {
                    Console.WriteLine("Please Enter Personnel Name :");
                    pe.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel Family :");
                    pe.Family = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel National Code: ");
                    pe.NationalCode = Console.ReadLine();
                    var IsDeleted = personelService.DeletePersonnel(pe);
                    if (IsDeleted == true)
                    {
                        uow.save();
                        Console.WriteLine(" Personnel Deleted susscessfully. ");
                    }
                    else
                    {
                        Console.WriteLine(" Personnel isn't  Deleted . ");
                    }
                }
                else if (question == NoAnswer)
                {
                    Console.WriteLine(" Nothing is  deleted. ");
                }
                goto Menu;
            }


            //////////////////////////////////////////upeate
            else if (request == 4)
            {
                Console.WriteLine("Do you want to update any Personnel  ? yes or no  ");
                string question = Console.ReadLine();
                string OkAnswer = "yes";
                string NoAnswer = "no";
                var pe = new DataLayer.Models.Personnel();

                Console.WriteLine("Personnel List:");
                foreach (var pers in personelService.GetAllPersonnel())
                {
                    Console.WriteLine($"  Personnel Name={ pers.Name}    ,     Family:{pers.Family}" +
                        $" ,   NationalCode: {pers.NationalCode}  ,    Gender:{pers.PersonnelGender}");
                }

                if (question == OkAnswer)
                {
                    Console.WriteLine("Please Enter Personnel Name for update :");
                    pe.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel Family for update:");
                    pe.Family = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel National Code for update: ");
                    pe.NationalCode = Console.ReadLine();

                    var p = new DataLayer.Models.Personnel();
                    p = personelService.GetPersonnelForUpdate(pe);

                    Console.WriteLine("Please Enter Personnel Name  :");
                    p.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel Family :");
                    p.Family = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel National Code : ");
                    p.NationalCode = Console.ReadLine();
                    var IsUpdated = personelService.UpdatePersonnel(p);
                    if (IsUpdated == true)
                    {
                        uow.save();
                        Console.WriteLine(" Personnel Updated successfully. ");
                    }
                }
                else if (question == NoAnswer)
                {
                    Console.WriteLine(" Nothing is  Update. ");
                }
                goto Menu;
            }


            else if (request == 5)
            {
                Console.WriteLine("----------------------------Amount Of Child ----------------------------------");
                Console.WriteLine("Pleas Enter Personnel Name : ");
                string Name = Console.ReadLine();
                string count = personelService.AmountOfChild(Name);
                Console.WriteLine($"Amount Of Personnel Child :  {count}");
                goto Menu;
            }

            else if (request == 6)
            {
                goto Menu;
            }

            else if (request <= 0 || request > 7)
            {
                Console.WriteLine("Pleas Enter Recommended Numbers");
            }
        }
        //public static void Main(string[] args)
        //{
        //   // Personnel();
        //}


    }
}