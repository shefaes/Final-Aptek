using System;
using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Manage_Drugstore.Controllers;

namespace Manage_Drugstore
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                AdminController _adminController = new AdminController();
                OwnerController _ownerController = new OwnerController();
                DrugstoreController _drugstoreController = new DrugstoreController();
                DruggistController _druggistController = new DruggistController();
                DrugController _drugController = new DrugController();

                Authentication: var admin = _adminController.Authenticate();


                if (admin != null)
                {
                    while (true)
                    {

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Welcome to our Drugstore,{admin.Username}");
                        Console.WriteLine("----");
                        Number: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                        

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1 - Owner");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2 - Drugstore");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3 - Druggist");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4 - Drug");
                        string number = Console.ReadLine();
                        int selectedNumber;
                        bool result = int.TryParse(number, out selectedNumber);
                        if (result)
                        {
                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {

                                    case 1:
                                        while (true)
                                        {
                                            if (selectedNumber >= 0 && selectedNumber <= 4)
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Owner");
                                                Console.WriteLine("----");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "1 - Create Owner");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "2 - Update Owner");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "3 - Delete Owner");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "4 - Get All Owners");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "0 - Exit");
                                                number = Console.ReadLine();

                                                switch (selectedNumber)
                                                {
                                                    case (int)Options1.CreateOwner:
                                                        _ownerController.CreateOwner();
                                                        break;
                                                    case (int)Options1.UpdateOwner:
                                                        _ownerController.UpdateOwner();
                                                        break;
                                                    case (int)Options1.DeleteOwner:
                                                        _ownerController.DeleteOwner();
                                                        break;
                                                    case (int)Options1.GetAllOwners:
                                                        _ownerController.GetAllOwners();
                                                        break;
                                                    case (int)Options1.Exit:
                                                        goto Number;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                                            }
                                            
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            if (selectedNumber >= 0 && selectedNumber <= 6)
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Drugstore");
                                                Console.WriteLine("----");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "1 - Create Drugstore");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "2 - Update Drugstore");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "3- Delete Drugstore");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "4- Get All Drugstores ");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "5- Get All Drugstores By Owner");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "6 - Sale");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "0 - Exit");
                                                number = Console.ReadLine();
                                                switch (selectedNumber)
                                                {
                                                    case (int)Options2.CreateDrugstore:
                                                        _drugstoreController.CreateDrugstore();
                                                        break;
                                                    case (int)Options2.UpdateDrugstore:
                                                        _drugstoreController.UpdateDrugstore();
                                                        break;
                                                    case (int)Options2.DeleteDrugstore:
                                                        _drugstoreController.DeleteDrugstore();
                                                        break;
                                                    case (int)Options2.GetAllDrugstores:
                                                        _drugstoreController.GetAllDrugstores();
                                                        break;
                                                    case (int)Options2.GetAllDrugstoresByOwner:
                                                        _drugstoreController.GetAllDrugstoresByOwner();
                                                        break;
                                                    case (int)Options2.Sale:
                                                        _drugstoreController.Sale();
                                                        break;
                                                    case (int)Options2.Exit:
                                                        goto Number;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                                            }
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            if (selectedNumber >= 0 && selectedNumber <= 5)
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Druggist");
                                                Console.WriteLine("----");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Druggist");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "2- Update Druggist");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "3- Delete Druggist");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "4- Get All Drugstores ");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All Druggist by Drugstore");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "0 - Exit");
                                                number = Console.ReadLine();
                                                switch (selectedNumber)
                                                {
                                                    case (int)Options3.CreateDruggist:
                                                        _druggistController.CreateDruggist();
                                                        break;
                                                    case (int)Options3.UpdateDruggist:
                                                        _druggistController.UpdateDruggist();
                                                        break;
                                                    case (int)Options3.DeleteDruggist:
                                                        _druggistController.DeleteDruggist();
                                                        break;
                                                    case (int)Options3.GetAllDruggists:
                                                        _druggistController.GetAllDruggists();
                                                        break;
                                                    case (int)Options3.GetAllDruggistByDrugstore:
                                                        _druggistController.GetAllDruggistByDrugstore();
                                                        break;
                                                    case (int)Options3.Exit:
                                                        goto Number;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                                            }
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            if (selectedNumber >= 0 && selectedNumber <= 6)
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Drug");
                                                Console.WriteLine("----");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "1- Create Drug");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "2- Update Drug");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "3- Delete Drug");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "4- Get All Drugs");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "5- Get All Drugs by Drugstore");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "6 - Filter");
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "0 - Exit");
                                                number = Console.ReadLine();
                                                switch (selectedNumber)
                                                {
                                                    case (int)Options4.CreateDrug:
                                                        _drugController.CreateDrug();
                                                        break;
                                                    case (int)Options4.UpdateDrug:
                                                        _drugController.UpdateDrug();
                                                        break;
                                                    case (int)Options4.DeleteDrug:
                                                        _drugController.DeleteDrug();
                                                        break;
                                                    case (int)Options4.GetAllDrugs:
                                                        _drugController.GetAllDrugs();
                                                        break;
                                                    case (int)Options4.GetAllDrugsByDrugstore:
                                                        _drugController.GetAllDrugsByDrugstore();
                                                        break;
                                                    case (int)Options4.Exit:
                                                        goto Number;      
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                                            }
                                        } 
                                        break;
                                    case 0:
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "0 - Logout");
                                        Console.WriteLine("----");
                                        number = Console.ReadLine();
                                        break;
                                }
                            }
                            else
                            {
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "number should be within 0-4");
                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "enter number in correct format");
                            goto Number;
                        }
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no admin with this password,please enter the correct passwor");
                }
            }
        }
    }
}
