using System;
using Office.DataLayer.Models;
using Office.DataLayer.Context;
using Office.DataLayer.Services;
namespace Office.ChildPersonnel.Endpoin
{
   public class ChildEndpoint
    {
        public static void Children()
        {
            IUnitOfWork uow = new OrganazationDbContext();
            ChildService ChildService = new ChildService(uow);
            int request;

        Menu:
            /////////////Menu
            Console.WriteLine("----------------------------Child Menu ------------------------------ ");
            Console.WriteLine("              Choose something you want by Enter it's numbers :   1 or 2 or 3 or 4 or 5 or 6      ");
            Console.WriteLine("              1-Get All Child            ");
            Console.WriteLine("              2-Insert Child             ");
            Console.WriteLine("              3-Delet Child              ");
            Console.WriteLine("              4-Update Child             ");
            Console.WriteLine("              5-Menu                     ");
            Console.WriteLine("              6-MainMenu                    ");
            

            try
            {
                request = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("you can't Enter character or string values , just numbers");
                goto Menu;
            }

            ////////////////////getAll
            if (request == 1)
            {
                Console.WriteLine("----------------------------GetAll Child ------------------------------ ");

                foreach (var c in ChildService.GetAllChild())
                {
                    Console.WriteLine($"  Child Name={ c.Name}    ,     Family:{c.Family}" +
                        $" ,  FatherName:{c.FatherName}       , NationalCode: {c.NationalCode}  ,    Gender:{c.ChildGender}");
                }
                goto Menu;
            }



            ///////////////////insert
            else if (request == 2)
            {
                Console.WriteLine("------------------------------- Insert Child ---------------------------- ");

                Console.WriteLine("Do you want to insert any Child  ? yes or no  ");
                string questionInsert = Console.ReadLine();
                string OkAnswerInset = "yes";
                string NoAnswerInsert = "no";

                var c = new ChildOfPerosnnel { };

                if (questionInsert == OkAnswerInset)
                {
                    Console.WriteLine("Please Enter Child Name :");
                    var name = c.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter Child Family :");
                    var family = c.Family = Console.ReadLine();
                    Console.WriteLine("Please Enter Child Father's Name :");
                    var Fn = c.FatherName = Console.ReadLine();
                    Console.WriteLine("Please Enter Child National Code: ");
                    c.NationalCode = Console.ReadLine();

                    ///////finding personnelId 
                    var personnelId = ChildService.PersonnelIdByName(c.FatherName);
                    c.PersonnelId = personnelId;

                    //var personlId = ChildService.PersonnelIdByIdFromPersonnel(c.NationalCode);
                    //c.PersonnelId = personlId;

                    Console.WriteLine("Please Enter Child gender you must Enter 1:Men & 2:Wemon");
                    int g = Convert.ToInt32(Console.ReadLine());
                    if (g == 1) { c.ChildGender = Gender.Men; }
                    else if (g == 2) { c.ChildGender = Gender.Wemon; }

                    if (c.PersonnelId != 0)
                    {
                        ChildService.InsertChild(c);
                        uow.save();
                        ChildService.GetChildById(c.Id);
                        Console.WriteLine($"Child {c.Name}  " + $" " + $" {c.Family} inserted succussfully.");
                    }
                    else
                    {
                        Console.WriteLine("you can't insert such child.");
                        goto Menu;
                    }
                }
                else if (questionInsert == NoAnswerInsert)
                {
                    Console.WriteLine("  ");
                }
                goto Menu;
            }



            ////////////////////////////delet
            else if (request == 3)
            {
                Console.WriteLine("---------------------------- Delete Child  -------------------------- ");

                Console.WriteLine("Do you want to delete any Child  ? yes or no  ");
                string question = Console.ReadLine();
                string OkAnswer = "yes";
                string NoAnswer = "no";

                var ch = new ChildOfPerosnnel { };

                Console.WriteLine(" Child List :  ");
                foreach (var c in ChildService.GetAllChild())
                {
                    Console.WriteLine($"  Child Name={ c.Name}    ,     Family:{c.Family}" +
                        $" ,  FatherName:{c.FatherName}       , NationalCode: {c.NationalCode}  ,    Gender:{c.ChildGender}");
                }

                if (question == OkAnswer)
                {
                    Console.WriteLine("Please Enter Child Name :");
                    var name = ch.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter Child Family :");
                    var family = ch.Family = Console.ReadLine();
                    Console.WriteLine("Please Enter Child Father's Name :");
                    var Fn = ch.FatherName = Console.ReadLine();
                    Console.WriteLine("Please Enter Child National Code: ");
                    ch.NationalCode = Console.ReadLine();

                    Console.WriteLine("Please Enter Child gender you must Enter 1:Men & 2:Wemon");
                    int g = Convert.ToInt32(Console.ReadLine());
                    if (g == 1) { ch.ChildGender = Gender.Men; }
                    else if (g == 2) { ch.ChildGender = Gender.Wemon; }

                    Console.WriteLine($"Do you Want to Delete  {ch.Name} {ch.Family} ");

                    var isDeleted = ChildService.DeleteChild(ch);
                    uow.save();
                    if (isDeleted == true)
                    {
                        Console.WriteLine($"child {ch.Name} {ch.Family} is Deleted sucessFully.");
                    }
                    else
                    {
                        Console.WriteLine(" Child don't delete. ");
                    }
                }
                else if (question == NoAnswer)
                {
                    Console.WriteLine(" Nothing is  deleted. ");
                }
                goto Menu;
            }

            //////////////////////////////////////////update
            else if (request == 4)
            {
                Console.WriteLine("---------------------------- Update Child  -------------------------- ");
                Console.WriteLine("Do you want to Update any Child  ? yes or no  ");
                string question = Console.ReadLine();

                var ch = new ChildOfPerosnnel { };

                Console.WriteLine(" Child List :  ");
                foreach (var c in ChildService.GetAllChild())
                {
                    Console.WriteLine($"  Child Name={ c.Name}    ,     Family:{c.Family}" +
                        $" ,  FatherName:{c.FatherName}       , NationalCode: {c.NationalCode}  ,    Gender:{c.ChildGender}");
                }

                Console.WriteLine("Witch child do you want to Update ? ");


                Console.WriteLine("Please Enter  Name of child for update :");
                var name = Console.ReadLine();

                Console.WriteLine("Please Enter Family of child for update :");
                var family = Console.ReadLine();

                Console.WriteLine("Please Enter  Father's Name of child for update :");
                var Fn = Console.ReadLine();


                Console.WriteLine("Please Enter National Code of child for update : ");
                var nc = Console.ReadLine();

                ch = ChildService.GetChildUpdate(name, family, Fn, nc);
                ///////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Please Enter Child Name: ");
                ch.Name = Console.ReadLine();

                Console.WriteLine("Please Enter Child Family: ");
                ch.Family = Console.ReadLine();

                Console.WriteLine("Please Enter Child Father's Name: ");
                ch.FatherName = Console.ReadLine();

                Console.WriteLine("Please Enter Child National Code: ");
                ch.NationalCode = Console.ReadLine();

                Console.WriteLine("Please Enter Child gender you must Enter 1:Men & 2:Wemon");
                int g = Convert.ToInt32(Console.ReadLine());
                if (g == 1) { ch.ChildGender = Gender.Men; }
                else if (g == 2) { ch.ChildGender = Gender.Wemon; }

                var personnelId = ChildService.PersonnelIdByName(ch.FatherName);
                ch.PersonnelId = personnelId;

                var isUpdated = ChildService.UpdateChild(ch);
                if (isUpdated == true)
                {
                    uow.save();
                    Console.WriteLine("Child Updated correctly");
                }


                goto Menu;

            }

            else if (request == 5)
            {
                goto Menu;
            }


            else if (request <= 0 && request > 5)
            {
                Console.WriteLine("Pleas Enter Recommended Numbers");
            }
        }
        //static void Main(string[] args)
        //{
        //    Children();
        //}
    }
}
