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
    public class DrugstoreController
    {
        private DrugstoreRepository _drugstoreRepository;
        private OwnerRepository _ownerRepository;

        public DrugstoreController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
        }

        public void CreateDrugstore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {

                AllOwnersList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All owners:");

                foreach (var ownerItem in owners)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{ownerItem.Id} name:{ownerItem.Name} ");
                }

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id:");
                string ownerId = Console.ReadLine();
                int Id;
                bool result = int.TryParse(ownerId, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore name:");
                        string name = Console.ReadLine();

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore address:");
                        string address = Console.ReadLine();

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore contactnumber:");
                        string contactnumber = Console.ReadLine();
                      
                       
                        var drugStore = new Drugstore
                        {
                            Name = name,
                            Address = address,
                            ContactNumber = contactnumber,
                            Owner = owner,
                        };
                        _drugstoreRepository.Create(drugStore);
                        owner.Drugstores.Add(drugStore);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Successfully created -  Name: {drugStore.Name}, Surname: {drugStore.Address}, contact number:{drugStore.ContactNumber}, Owner: {drugStore.Owner}");
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including owner doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "please enter id in digits");
                    goto AllOwnersList;
                }

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Owners not found! You must create owner before creating of drug store");
            }
        }

        public void UpdateDrugstore()
        {
            var drugStores = _drugstoreRepository.GetAll();
            if (drugStores.Count != 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All drugstores :");

                foreach (var drugStore in drugStores)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $" name : {drugStore.Name}, address: " +
                        $"{drugStore.Address},contact number: {drugStore.ContactNumber},Id :{drugStore.Id}");
                }
                Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Choose drug store by id");
                string id = Console.ReadLine();

                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugstoreRepository.Get(d => d.Id == drugStoreId);

                    if (drugStore != null)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore name:");
                        string newName = Console.ReadLine();

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore address:");
                        string newAddress = Console.ReadLine();

                        contactnumber: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore contact number");
                        string contactNumberInput = Console.ReadLine();
                            
                                drugStore.Name = newName;
                                drugStore.Address = newAddress;
                                drugStore.ContactNumber = contactNumberInput;
                                    _drugstoreRepository.Update(drugStore);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"Id{drugStore.Id} name{drugStore.Name} " +
                            $"Address{drugStore.Address} contactnumber{drugStore.ContactNumber} owner{drugStore.Owner}");
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "no drugstore found with this Id");

                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please correct drugstore Id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"There is no drugstore");
            }
           

        }

        public void DeleteDrugstore()
        {
            var drugStores = _drugstoreRepository.GetAll();
            if (drugStores.Count != 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All drugstores :");

                foreach (var drugStore in drugStores)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $" name : {drugStore.Name}, address: " +
                        $"{drugStore.Address},contact number: {drugStore.ContactNumber},Id :{drugStore.Id}");
                }
                Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Choose drug store by id");
                string id = Console.ReadLine();

                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugstoreRepository.Get(d => d.Id == drugStoreId);

                    if (drugStore != null)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore name:");
                        string newName = Console.ReadLine();

                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore address:");
                        string newAddress = Console.ReadLine();

                        contactnumber: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore contact number");
                        string contactNumberInput = Console.ReadLine();

                        drugStore.Name = newName;
                        drugStore.Address = newAddress;
                        drugStore.ContactNumber = contactNumberInput;
                        _drugstoreRepository.Update(drugStore);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"Id{drugStore.Id} name{drugStore.Name} " +
                            $"Address{drugStore.Address} contactnumber{drugStore.ContactNumber} owner{drugStore.Owner}");
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "no drugstore found with this Id");

                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please correct drugstore Id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"There is no drugstore");
            }


        }

        public void GetAllDrugstores()
        {
            var drugStores = _drugstoreRepository.GetAll();
            var owners = _ownerRepository.GetAll();

            if (drugStores.Count > 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All drugstore list");

                foreach (var drugStore in drugStores)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"Id - {drugStore.Id}, Name: {drugStore.Name}, Address: {drugStore.Address}, ContactNumber: {drugStore.ContactNumber}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }

        public void GetAllDrugstoresByOwner()
        {
            var owners = _ownerRepository.GetAll();
            AllOwnerList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "All owner lists");

            foreach (var ownerItem in owners)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, ownerItem.Id);
            }

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id:");
            string ownerId = Console.ReadLine();

            var owner = _ownerRepository.Get(o => o.Name.ToLower() == ownerId.ToLower());
            if (owner != null)
            {
                var drugStoreOfOwners = _drugstoreRepository.GetAll(o => o.Id == owner.Id);
                if (drugStoreOfOwners.Count != 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All drugstore of the owner:");

                    foreach (var drugStoreOfOwner in drugStoreOfOwners)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{drugStoreOfOwner.Name}, {drugStoreOfOwner.Address}, {drugStoreOfOwner.ContactNumber}, {drugStoreOfOwner.Id}");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"There is no drugstore in this owner {owner.Id}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including owner doesn't exist");
            }

        }

        public void Sale()
        {

        }

    }
}
