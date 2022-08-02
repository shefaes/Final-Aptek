using System;
using Core.Constans;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Welcome to our Drugstore,{admin.Username}");
                Console.WriteLine("----");

                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "1 - Create Owner");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "2 - Update Owner");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "3 - Delete Owner");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "4 - GetAll Owner");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "5 - Create Drugstore");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "6 - Update Drugstore");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "7 - Delete Drugstore");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "8 - GetAll Drugstore");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "9 - Create Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "10- Update Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "11- Delete Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "12- GetAll Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "13- Create Drug");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "14- Update Drug");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "15- Delete Drug");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "16- GetAll Drug");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "0 - Logout");
                    Console.WriteLine("----");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 16)
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
                                case (int)Options.GetAllOwner:
                                 _ownerController.GetAllOwner();
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
                                case (int)Options.GetAllDrugstore:
                                    _drugstoreController.GetAllDrugstore();
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
                                case (int)Options.GetAllDruggist:
                                    _druggistController.GetAllDruggist();
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
                                case (int)Options.GetAllDrug:
                                    _drugController.GetAllDrug();
                                    break;
                                    return;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Admin username or password is incorrect");
                goto Authentication;
            }
        }
    }
}
