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
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug name:");
                string name;
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug price:");
                byte price;
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug count:");
                string count = Console.ReadLine();
                byte IdItem;
                bool result = byte.TryParse(count, out IdItem);

                AllOwnersList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All ");
            }
        }
        public void UpdateDrug()
        {

        }

        public void DeleteDrug()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter drug name");
            string name = Console.ReadLine();
            var drug = _drugRepository.Get(d => d.Name.ToLower() == name.ToLower());
            if (drug != null)
            {
                _drugRepository.Delete(drug);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"{name} is deleted");

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
            }
        }

        public void GetAllDrugs()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count>0)
            {
                var drugstore = _drugstoreRepository.Get();
                foreach(var drug in drugs)
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

        }

    }

}
