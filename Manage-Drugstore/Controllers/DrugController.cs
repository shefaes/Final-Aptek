using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Drugstore.Controllers
{
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugstoreRepository _drugstoreRepository;

        public DrugController()
        {
            _drugRepository = new DrugRepository();
            _drugstoreRepository = new DrugstoreRepository();
        }
        public void CreateDrug()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {

                AlldrugstoresList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All drugstores:");

                foreach (var drugstore in drugstores)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} name:{drugstore.Name} ");
                }

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore Id:");
                string drugstoresId = Console.ReadLine();
                int Id;
                bool result = int.TryParse(drugstoresId, out Id);
                if (result)
                {
                    var drugStore = _drugstoreRepository.Get(o => o.Id == Id);
                    if (drugStore != null)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug name:");
                        string name = Console.ReadLine();

                        digits: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug price:");
                        string price = Console.ReadLine();
                        int drugprice;
                        result = int.TryParse(price, out drugprice);
                        if (result)
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug count:");
                            string count = Console.ReadLine();
                            int drugcount;
                            result = int.TryParse(count, out drugcount);
                            if (result)
                            {

                                var drug = new Drug
                                {
                                    Name = name,
                                    Price = drugprice,
                                    Count = drugcount,

                                };
                                drugStore.Drugs.Add(drug);
                                _drugRepository.Create(drug);
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Successfully created -  Name: {drug.Name}, count: {drug.Count}, " +
                                                                                $"price:{drug.Price}, drugstore{drug.Drugstore.Name}");
                            }
                            else
                            {
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter price in digits");
                            }
                            goto digits;
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter price in digits");
                            goto digits;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including drugstore doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "please enter id in digits");
                    goto AlldrugstoresList;
                }

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Drugstores not found! You must create drugstore before creating of drug");
            }
        }

        public void UpdateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "All drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id}, Name:{drug.Name}, Price:{drug.Price}, count:{drug.Count}");
                }

                Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug Id");
                string Id = Console.ReadLine();
                if (Id != "")
                {
                    int drugId;
                    bool result = int.TryParse(Id, out drugId);
                    if (result)
                    {
                        var drug = _drugRepository.Get(d => d.Id == drugId);
                        if (drug != null)
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, "Please enter new name");
                            string newName = Console.ReadLine();
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, "Please enter new Price");
                            string newPrice = Console.ReadLine();

                            double price;
                            bool result1 = double.TryParse(newPrice, out price);
                            if (result1)
                            {
                                Count: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, "Please enter new Count");
                                string newCount = Console.ReadLine();
                                int count;
                                bool result2 = int.TryParse(newCount, out count);
                                if (result2)
                                {
                                    var dbDrugs = _drugRepository.GetAll();
                                    foreach (var dbdrug in dbDrugs)
                                    {
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"Id: {drug.Id} Name: {drug.Name}" +
                                            $"price{drug.Price} count: {drug.Count}");
                                    }
                                    if (count > 0)
                                    {
                                        var updateDrug = new Drug
                                        {
                                            Id = drug.Id,
                                            Name = newName,
                                            Price = price,
                                            Count = count
                                        };
                                        _drugRepository.Update(updateDrug);
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"new Name: {updateDrug.Name}" +
                                            $" new price{updateDrug.Price}  new count: {updateDrug.Count}");
                                    }
                                    else
                                    {
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Count cant be negative");
                                        goto Count;
                                    }
                                }
                                else
                                {
                                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct new count");
                                }
                            }
                            else
                            {
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct new price");
                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
                    }
                }
            }
        }

        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "All drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id}, Name:{drug.Name}, DrugstoreName:{drug.Drugstore.Name}");
                }

                Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug Id");
                string Id = Console.ReadLine();
                int drugId;
                var result = int.TryParse(Id, out drugId);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == drugId);
                    if (drug != null)
                    {
                        _drugRepository.Delete(drug);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"{drug.Name} is deleted");
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }

        public void GetAllDrugs()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                var drugstore = _drugstoreRepository.Get();
                foreach (var drug in drugs)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id}, drug name:{drug.Name}, drug price:{drug.Price}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "not found drug");
            }
        }

        public void GetAllDrugsByDrugstore()
        {
            var drugStores = _drugstoreRepository.GetAll();
            AllDrugStoreList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "All drugstore lists");

            foreach (var drugStoreItem in drugStores)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, drugStoreItem.Name);
            }

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore name:");
            string drugStoreName = Console.ReadLine();

            var drugStore = _drugstoreRepository.Get(d => d.Name.ToLower() == drugStoreName.ToLower());
            if (drugStore != null)
            {
                var drugStoreDrugs = _drugRepository.GetAll(d => d.Id == drugStore.Id);

                if (drugStoreDrugs.Count != 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All drugs of the drugstore:");

                    foreach (var drugStoreDrug in drugStoreDrugs)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{drugStoreDrug.Name}, {drugStoreDrug.Count}, {drugStoreDrug.Price}, {drugStoreDrug.Id}");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"There is no drugs in this drugstore {drugStore.Name}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including drug doesn't exist");
            }

        }

        public void Filter()
        {
            digits: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter MaxPrice Drugs and to list all prices of drug and including maxprice");
            string price = Console.ReadLine();
            double maxprice;
            bool result = double.TryParse(price, out maxprice);
            if (result)
            {
                var drugs = _drugRepository.GetAll(d => d.Price <= maxprice);
                if (drugs.Count > 0)
                {
                    foreach (var drug in drugs)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, $"Id:{drug.Id}, name:{drug.Name}, price:{drug.Price}" +
                            $"count{drug.Count}, drugstore:{drug.Drugstore}");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "no drug found with the entered price or less than that");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "price should be in digits");
                goto digits;
            }
        }
    }
}
