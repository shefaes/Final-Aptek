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
            AdminController _adminController = new AdminController();
            OwnerController _ownerController = new OwnerController();
            DrugstoreController _drugstoreController = new DrugstoreController();
            DruggistController _druggistController = new DruggistController();
            DrugController _drugController = new DrugController();

        Authentication: var admin = _adminController.Authenticate();


            if (admin != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Welcome to our Drugstore,{admin.Username}");
                Console.WriteLine("----");

                while (true)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1 - Create Owner");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2 - Update Owner");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3 - Delete Owner");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4 - Get All Owners");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "5 - Create Drugstore");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "6 - Update Drugstore");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "7 - Delete Drugstore");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "8 - Get All Drugstores ");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "9 - Get All Drugstores By Owner");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "10 - Sale");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "11 - Create Druggist");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "12- Update Druggist");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "13- Delete Druggist");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "14- Get All Drugstores ");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "15 - Get All Druggist by Drugstore");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "16- Create Drug");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "17- Update Drug");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "18- Delete Drug");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "19- Get All Drugs");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "20- Get All Drugs by Drugstore");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "21 - Filter");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "0 - Logout");
                    Console.WriteLine("----");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 21)
                        {
                            switch (selectedNumber)
                            {
                                case (int)Options.CreateOwner:
                                    _ownerController.CreateOwner();
                                    break;
                                case (int)Options.UpdateOwner:
                                    _ownerController.UpdateOwner();
                                    break;
                                case (int)Options.DeleteOwner:
                                    _ownerController.DeleteOwner();
                                    break;
                                case (int)Options.GetAllOwners:
                                    _ownerController.GetAllOwners();
                                    break;
                                case (int)Options.CreateDrugstore:
                                    _drugstoreController.CreateDrugstore();
                                    break;
                                case (int)Options.UpdateDrugstore:
                                    _drugstoreController.UpdateDrugstore();
                                    break;
                                case (int)Options.DeleteDrugstore:
                                    _drugstoreController.DeleteDrugstore();
                                    break;
                                case (int)Options.GetAllDrugstores:
                                    _drugstoreController.GetAllDrugstores();
                                    break;
                                case (int)Options.GetAllDrugstoresByOwner:
                                    _drugstoreController.GetAllDrugstoresByOwner();
                                    break;
                                case (int)Options.Sale:
                                    _drugstoreController.Sale();
                                    break;
                                case (int)Options.CreateDruggist:
                                    _druggistController.CreateDruggist();
                                    break;
                                case (int)Options.UpdateDruggist:
                                    _druggistController.UpdateDruggist();
                                    break;
                                case (int)Options.DeleteDruggist:
                                    _druggistController.DeleteDruggist();
                                    break;
                                case (int)Options.GetAllDruggists:
                                    _druggistController.GetAllDruggists();
                                    break;
                                case (int)Options.GetAllDruggistByDrugstore:
                                    _druggistController.GetAllDruggistByDrugstore();
                                    break;
                                case (int)Options.CreateDrug:
                                    _drugController.CreateDrug();
                                    break;
                                case (int)Options.UpdateDrug:
                                    _drugController.UpdateDrug();
                                    break;
                                case (int)Options.DeleteDrug:
                                    _drugController.DeleteDrug();
                                    break;
                                case (int)Options.GetAllDrugs:
                                    _drugController.GetAllDrugs();
                                    break;
                                case(int)Options.GetAllDrugsByDrugstore:
                                    _drugController.GetAllDrugsByDrugstore();
                                    break;
                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                        }
                        
                    }
                     
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Log out");
                    while (true)
                    {
                        goto Authentication;
                    }
                
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                    }
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Admin username or password is incorrect");
                goto Authentication;
            }
        }
    }
}
