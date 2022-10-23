using System;
using Office.DataLayer.Models;
using Office.DataLayer.Context;
using Office.DataLayer.Services;
using Office.DataLayer.DTO_Class;
namespace Office.PersonnelMainOffice.Endpoint
{
    public class PersonnelMainOfficeEndpoint
    {
        public static void PMO()
        {
            IUnitOfWork uow = new OrganazationDbContext();
            PersonnelMainOfficeService PMOService = new PersonnelMainOfficeService(uow);
            int request;
        Menu:
            /////////////Menu
            Console.WriteLine("---------------------------- PersonnelMainOffice Menu ------------------------------ ");
            Console.WriteLine("              Choose something you want by Enter it's numbers :   1 or 2 or 3 or 4 or 5 or 6        ");
            Console.WriteLine("              1-Get All PersonnelMainOffice            ");
            Console.WriteLine("              2-Insert  PersonnelMainOffice             ");
            Console.WriteLine("              3-Delet   PersonnelMainOffice              ");
            Console.WriteLine("              4-Update  PersonnelMainOffice             ");
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
                Console.WriteLine("---------------------------- GetAll PersonnelMainOffice ------------------------------ ");

                foreach (var c in PMOService.GetAll())
                {
                    var x = PMOService.Get(c);
                    Console.WriteLine($"  PersonnelMainOffice Info PersonnelName={ x.PersonnelNameDTO}    ,     PersonnelFamily:{x.PersonnelFamilyDTO}" +
                        $" ,  PersonnelNationalCode:{x.NationalCodeDTO}  ");
                    Console.WriteLine($"  PersonnelMainOffice  Organazation Name: { x.OrgNameDTO}/ Organazation Code: { x.OrgCodeDTO}");
                }
                goto Menu;
            }



            ///////////////////insert
            else if (request == 2)
            {
                Console.WriteLine("------------------------------- Insert PersonnelMainOffice ---------------------------- ");

                Console.WriteLine("Do you want to insert any PersonnelMainOffice  ? yes or no  ");
                string questionInsert = Console.ReadLine();
                string OkAnswerInset = "yes";
                string NoAnswerInsert = "no";

                var c = new PersonnelMainOfficeDTO { };

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
                    PMOService.InsertPersonnelMainOffice(c);
                    uow.save();
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
                Console.WriteLine("---------------------------- Delete PersonnelMainOffice  -------------------------- ");

                Console.WriteLine("Do you want to delete any PersonnelMainOffice  ? yes or no  ");
                string question = Console.ReadLine();
                string OkAnswer = "yes";
                string NoAnswer = "no";

                var ch = new PersonnelMainOfficeDTO { };

                Console.WriteLine(" PersonnelMainOffice List :  ");
                foreach (var c in PMOService.GetAll())
                {
                    var x = PMOService.Get(c);
                    Console.WriteLine($"  PersonnelMainOffice Info PersonnelName={ x.PersonnelNameDTO}    ,     PersonnelFamily:{x.PersonnelFamilyDTO}" +
                        $" ,  PersonnelNationalCode:{x.NationalCodeDTO}  ");
                    Console.WriteLine($"  PersonnelMainOffice  Organazation Name: { x.OrgNameDTO}/ Organazation Code: { x.OrgCodeDTO}");
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


                    var isDeleted = PMOService.DeletePersonnelMainOffice(ch);
                    uow.save();
                    if (isDeleted == true)
                    {
                        Console.WriteLine($"PersonnelMainOffice Personnel Name  {ch.PersonnelNameDTO} with Organazation {ch.OrgNameDTO} is Deleted sucessFully.");
                    }
                    else
                    {
                        Console.WriteLine(" PersonnelMainOffice don't delete. ");
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
                Console.WriteLine("---------------------------- Update PersonnelMainOffice  -------------------------- ");
                Console.WriteLine("Do you want to Update any PersonnelMainOffice  ? yes or no  ");
                string question = Console.ReadLine();

                var ch = new PersonnelMainOfficeDTO { };

                foreach (var c in PMOService.GetAll())
                {
                    var x = PMOService.Get(c);
                    Console.WriteLine($"  PersonnelMainOffice Info PersonnelName={ x.PersonnelNameDTO}    ,     PersonnelFamily:{x.PersonnelFamilyDTO}" +
                        $" ,  PersonnelNationalCode:{x.NationalCodeDTO}  ");
                    Console.WriteLine($"  PersonnelMainOffice  Organazation Name: { x.OrgNameDTO}/ Organazation Code: { x.OrgCodeDTO}");
                }

                Console.WriteLine("Wich PersonnelMainOffice do you want to Update ? ");


                Console.WriteLine("Please Enter  Name of CurrentPersonnel for update :");
                ch.PersonnelNameDTO = Console.ReadLine();

                Console.WriteLine("Please Enter Family of Current Personeel  :");
                ch.PersonnelFamilyDTO = Console.ReadLine();


                Console.WriteLine("Please Enter National Code of Current Personnel : ");
                ch.NationalCodeDTO = Console.ReadLine();

                Console.WriteLine("Please Enter Name of Current Orgnazation  : ");
                ch.OrgNameDTO = Console.ReadLine();

                Console.WriteLine("Please Enter Code of Current Orgnazation : ");
                ch.OrgCodeDTO = Console.ReadLine();

                var p = new PersonnelMainOfficeDTO { };

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


                var isUpdated = PMOService.UpdatePersonnelMainOffice(p,ch);
                if (isUpdated == true)
                {
                    uow.save();
                    Console.WriteLine("Personnel Main Office Updated correctly");
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
       // static void Main(string[] args)
        //{
       //     PMO();
       // }
    }
}
