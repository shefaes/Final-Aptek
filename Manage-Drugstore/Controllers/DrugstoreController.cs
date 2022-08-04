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
            if (owners.Count>0)
            {
              ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore name:");
              string name = Console.ReadLine();

              ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore address:");
              string address = Console.ReadLine();

              ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore contactnumber:");
              string contactnumber = Console.ReadLine();
              int contactNumber;
              bool result = int.TryParse(contactnumber, out contactNumber);

            AllOwnersList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All owners:");
                foreach ( Owner in owners)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Id{Owner.Id}, owner name{Owner.Name}");
                }
                foreach (var ownerItem in owners)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, ownerItem.Name);
                }

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner name:");
                string ownerName = Console.ReadLine();

                var owner = _ownerRepository.Get(o => o.Name.ToLower() == ownerName.ToLower());
                if (owner != null)
                {
                    var drugStore = new Drugstore
                    {
                        Name = name,
                        Address = address,
                        ContactNumber = contactnumber,
                        Owner = owner
                    };

                    _drugstoreRepository.Create(drugStore);
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Successfully created -  Name: {drugStore.Name}, Surname: {drugStore.Address}, Age:{drugStore.ContactNumber}, Owner: {drugStore.Owner}");
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including owner doesn't exist");
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
            GetAllDrugstoresByOwner();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug store id");
            string id = Console.ReadLine();

            int drugStoreId;
            bool result = int.TryParse(id, out drugStoreId);
            var drugStore = _drugstoreRepository.Get(d => d.Id == drugStoreId);

            if (drugStore != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore name:");
                string newName = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore address:");
                string newAddress = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new drugstore contact number");
                string contactNumberInput = Console.ReadLine();
                int newContactNumber;
                result = int.TryParse(contactNumberInput, out newContactNumber);

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter new Owner name");
            OwnerName: string newOwnerName = Console.ReadLine();

                if (drugStore.Owner.Name.ToLower() == newOwnerName.ToLower())
                {
                    drugStore.Name = newName;
                    drugStore.Address = newAddress;
                    drugStore.ContactNumber = newContactNumber;

                    _drugstoreRepository.Update(drugStore);
                }
                else
                {
                    drugStore.Name = newName;
                    drugStore.Address = newAddress;
                    drugStore.ContactNumber = newContactNumber;

                    var owner = _ownerRepository.Get(o => o.Name.ToLower() == newOwnerName.ToLower());
                    if (owner != null)
                    {
                        drugStore.Owner = _ownerRepository.Get(o => o.Name.ToLower() == newOwnerName.ToLower());
                        _drugstoreRepository.Update(drugStore);
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter correct owner name");
                        goto OwnerName;
                    }
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please correct drug store ID");
            }
        }

        public void DeleteDrugstore()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter drugstore name");
            string drugstoreName = Console.ReadLine();

            var drugstore = _drugstoreRepository.Get(g => g.Name.ToLower() == drugstoreName.ToLower());
            if (drugstore != null)
            {
                _drugstoreRepository.Delete(drugstore);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"{drugstoreName} is deleted");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
            }

        }

        public void GetAllDrugstores()
        {

        }

        public void GetAllDrugstoresByOwner()
        {

        }

        public void Sale()
        {

        }

    }
}
