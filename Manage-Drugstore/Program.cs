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
                        string number = Console.ReadLine();

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1 - Owner");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2 - Drugstore");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3 - Druggist");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4 - Drug");

                        int selectedNumber;
                        bool result = int.TryParse(number, out selectedNumber);
                        if (result)
                        {
                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {
                                    case 1:
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Owner");
                                        Console.WriteLine("----");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                        number = Console.ReadLine();

                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1 - Create Owner");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2 - Update Owner");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3 - Delete Owner");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4 - Get All Owners");
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
                                        }
                                        break;

                                    case 2:
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Drugstore");
                                        Console.WriteLine("----");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                        number = Console.ReadLine();

                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1 - Create Drugstore");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2 - Update Drugstore");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3- Delete Drugstore");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4- Get All Drugstores ");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "5- Get All Drugstores By Owner");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "6 - Sale");
                                        switch (selectedNumber)
                                        {
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
                                        }
                                        break;
                                    case 3:
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Druggist");
                                        Console.WriteLine("----");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                        number = Console.ReadLine();

                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1 - Create Druggist");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2- Update Druggist");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3- Delete Druggist");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4- Get All Drugstores ");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "5 - Get All Druggist by Drugstore");
                                        switch (selectedNumber)
                                        {
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
                                        }
                                        break;
                                    case 4:
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Drug");
                                        Console.WriteLine("----");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                                        number = Console.ReadLine();

                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "1- Create Drug");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "2- Update Drug");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "3- Delete Drug");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "4- Get All Drugs");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "5- Get All Drugs by Drugstore");
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "6 - Filter");
                                        switch (selectedNumber)
                                        {
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
                                            case (int)Options.GetAllDrugsByDrugstore:
                                                _drugController.GetAllDrugsByDrugstore();
                                                break;
                                        }
                                        break;
                                    case 0:
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "0 - Logout");
                                        Console.WriteLine("----");
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
