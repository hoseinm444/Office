using System;
using Office.DataLayer.Models;
using Office.DataLayer.Context;
using Office.DataLayer.Services;
using Office.DataLayer.DTO_Class;

namespace Office.Permission.Endpoint
{
    public class PermissionEndpoint
    {
        public static void Permission()
        {
            IUnitOfWork uow = new OrganazationDbContext();
            PermissionService permissionService = new PermissionService(uow);
            int request;

        Menu:
            /////////////Menu
            Console.WriteLine("---------------------------- Permission Menu ------------------------------ ");
            Console.WriteLine("              Choose something you want by Enter it's numbers :   1 or 2 or 3 or 4 or 5  or 6       ");
            Console.WriteLine("              1-Get All Permission            ");
            Console.WriteLine("              2-Insert Permission             ");
            Console.WriteLine("              3-Delet  Permission              ");
            Console.WriteLine("              4-Update Permission             ");
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
                Console.WriteLine("---------------------------- GetAll Permission ------------------------------ ");

                foreach (var c in permissionService.GetAll())
                {
                    var x = permissionService.Get(c);
                    Console.WriteLine($"  Permission Info PersonnelName={ x.PersonnelNameDTO}    ,     PersonnelFamily:{x.PersonnelFamilyDTO}" +
                        $" ,  PersonnelNationalCode:{x.NationalCodeDTO}  ");
                    Console.WriteLine($"  Permission  Organazation Name: { x.OrgNameDTO}/ Organazation Code: { x.OrgCodeDTO}");
                }
                goto Menu;
            }



            ///////////////////insert
            else if (request == 2)
            {
                Console.WriteLine("------------------------------- Insert Permission ---------------------------- ");

                Console.WriteLine("Do you want to insert any Permission  ? yes or no  ");
                string questionInsert = Console.ReadLine();
                string OkAnswerInset = "yes";
                string NoAnswerInsert = "no";

                var c = new PermissionDTO { };

                if (questionInsert == OkAnswerInset)
                {
                    Console.WriteLine("Please Enter Personnel Name :");
                    c.PersonnelNameDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel Family :");
                    c.PersonnelFamilyDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel National Code :");
                    c.NationalCodeDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Organazation Name: ");
                    c.OrgNameDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Organazation Code: ");
                    c.OrgCodeDTO = Console.ReadLine();
                    var IsInserted = permissionService.InsertPermission(c);
                    if (IsInserted == true)
                    {
                        uow.save();
                        Console.WriteLine($"Personnel {c.PersonnelNameDTO} ,{c.PersonnelFamilyDTO} , {c.OrgNameDTO} Inserted sucessfully.");
                    }
                    else
                    {
                        Console.WriteLine("Inserting Personnel is not sucessfull.");
                    }
                    goto Menu;
                }
                else if (questionInsert == NoAnswerInsert)
                {
                    Console.WriteLine("  ");
                    goto Menu;
                }
            }



            ////////////////////////////delet
            else if (request == 3)
            {
                Console.WriteLine("---------------------------- Delete Permission  -------------------------- ");

                Console.WriteLine("Do you want to delete any Permission  ? yes or no  ");
                string question = Console.ReadLine();
                string OkAnswer = "yes";
                string NoAnswer = "no";

                var ch = new PermissionDTO { };

                Console.WriteLine(" PersonnelMainOffice List :  ");
                foreach (var c in permissionService.GetAll())
                {
                    var x = permissionService.Get(c);
                    Console.WriteLine($"  Permission Info PersonnelName={ x.PersonnelNameDTO}    ,     PersonnelFamily:{x.PersonnelFamilyDTO}" +
                        $" ,  PersonnelNationalCode:{x.NationalCodeDTO}  ");
                    Console.WriteLine($"  Permission  Organazation Name: { x.OrgNameDTO}/ Organazation Code: { x.OrgCodeDTO}");
                }

                if (question == OkAnswer)
                {
                    Console.WriteLine("Please Enter Personnel Name :");
                    ch.PersonnelNameDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel Family :");
                    ch.PersonnelFamilyDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Personnel National Code :");
                    ch.NationalCodeDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Organazation Name: ");
                    ch.OrgNameDTO = Console.ReadLine();
                    Console.WriteLine("Please Enter Organazation Code: ");
                    ch.OrgCodeDTO = Console.ReadLine();


                    var isDeleted = permissionService.DeletePermission(ch);
                    uow.save();
                    if (isDeleted == true)
                    {
                        Console.WriteLine($"Permission Personnel Name  {ch.PersonnelNameDTO} with Organazation {ch.OrgNameDTO} is Deleted sucessFully.");
                    }
                    else
                    {
                        Console.WriteLine(" Permission don't delete. ");
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
                Console.WriteLine("---------------------------- Update Permission  -------------------------- ");
                Console.WriteLine("Do you want to Update any Permission  ? yes or no  ");
                string question = Console.ReadLine();

                var ch = new PermissionDTO { };

                foreach (var c in permissionService.GetAll())
                {
                    var x = permissionService.Get(c);
                    Console.WriteLine($"  Permission Info PersonnelName={ x.PersonnelNameDTO}    ,     PersonnelFamily:{x.PersonnelFamilyDTO}" +
                        $" ,  PersonnelNationalCode:{x.NationalCodeDTO}  ");
                    Console.WriteLine($"  Permission  Organazation Name: { x.OrgNameDTO}/ Organazation Code: { x.OrgCodeDTO}");
                }

                Console.WriteLine("Wich Permission do you want to Update ? ");


                Console.WriteLine("Please Enter  Name of Personnel for update :");
                ch.PersonnelNameDTO = Console.ReadLine();

                Console.WriteLine("Please Enter Family of Personeel for update :");
                ch.PersonnelFamilyDTO = Console.ReadLine();


                Console.WriteLine("Please Enter National Code of Personnel for update : ");
                ch.NationalCodeDTO = Console.ReadLine();

                Console.WriteLine("Please Enter Name of Orgnazation for update : ");
                ch.OrgNameDTO = Console.ReadLine();

                Console.WriteLine("Please Enter Code of Orgnazation for update : ");
                ch.OrgCodeDTO = Console.ReadLine();

                var p = new PermissionDTO { };

                ///////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Please Enter Personnel Name :");
                p.PersonnelNameDTO = Console.ReadLine();
                Console.WriteLine("Please Enter Personnel Family :");
                p.PersonnelFamilyDTO = Console.ReadLine();
                Console.WriteLine("Please Enter Personnel National Code :");
                p.NationalCodeDTO = Console.ReadLine();
                Console.WriteLine("Please Enter Organazation Name: ");
                p.OrgNameDTO = Console.ReadLine();
                Console.WriteLine("Please Enter Organazation Code: ");
                p.OrgCodeDTO = Console.ReadLine();


                var isUpdated = permissionService.UpdatePermission(p, ch);
                if (isUpdated == true)
                {
                    uow.save();

                    /////////
                    ///we have exception in savechanges beacuase we can't change PersonnelId
                    ///and OrganazationId of conposit key .

                    Console.WriteLine("Permission  Updated correctly");
                }


                goto Menu;

            }

            else if (request == 5)
            {
                goto Menu;
            }


            else if (request <= 0 || request > 6)
            {
                Console.WriteLine("Pleas Enter Recommended Numbers");
            }
        }
        //static void Main(string[] args)
        //{
        //  Permission();
        //}
    }
}