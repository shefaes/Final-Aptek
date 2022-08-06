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
    public class DruggistController
    {
        private  DruggistRepository _druggistRepository;
        private  DrugstoreRepository _drugstoreRepository;
        

        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
            _drugstoreRepository = new DrugstoreRepository();
        }
        public void CreateDruggist()
        {
            var drugStores = _drugstoreRepository.GetAll();
            if (drugStores.Count != 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter name:");
                string name = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter surname:");
                string surname = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter age:");
                string age = Console.ReadLine();
                byte Age;
                bool result = byte.TryParse(age, out Age);

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Experience:");
                string experienceInput = Console.ReadLine();
                int experience;
                result = int.TryParse(experienceInput, out experience);

            AllDrugStoreList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All drugstores");

                foreach (var drugStoreItem in drugStores)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, drugStoreItem.Name);
                }

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore name:");
                string drugStoreName = Console.ReadLine();

                var drugStore = _drugstoreRepository.Get(d => d.Name.ToLower() == drugStoreName.ToLower());
                if (drugStore != null)
                {
                    var druggist = new Druggist
                    {
                        Name = name,
                        Surname = surname,
                        Age = Age,
                        Experience = experience,
                    };

                    _druggistRepository.Create(druggist);
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Successfully created -  Name: {druggist.Name}, Surname: {druggist.Surname}, Age:{druggist.Age}, Drug store: {druggist.Name}");
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including drugstore doesn't exist");
                    goto AllDrugStoreList;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Drugstore not found! You must create drugstore before creating of druggist");
            }
        }

        public void UpdateDruggist()
        {
            GetAllDruggistByDrugstore();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter druggist id");
            string id = Console.ReadLine();

            int druggistId;
            bool result = int.TryParse(id, out druggistId);
            var druggist = _druggistRepository.Get(d => d.Id == druggistId);

            if (druggist != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new druggist name:");
                string newName = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new druggist surname:");
                string newSurname = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter new druggist age");
                string ageInput = Console.ReadLine();
                byte newAge;
                result = byte.TryParse(ageInput, out newAge);

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "P lease enter new druggist experience:");
                string experienceInput = Console.ReadLine();
                int experience;
                result = int.TryParse(experienceInput, out experience);

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "enter new Drug store name");
            DrugStoreName: string newDrugStoreName = Console.ReadLine();

                if (druggist.Name.ToLower() == newDrugStoreName.ToLower())
                {
                    druggist.Surname = newSurname;
                    druggist.Age = newAge;
                    druggist.Name = newName;
                    druggist.Experience = experience;

                    _druggistRepository.Update(druggist);
                }
                else
                {
                    druggist.Surname = newSurname;
                    druggist.Age = newAge;
                    druggist.Name = newName;
                    druggist.Experience = experience;

                    var drugStore = _drugstoreRepository.Get(d => d.Name.ToLower() == newDrugStoreName.ToLower());
                    if (drugStore != null)
                    {
                        drugStore = _drugstoreRepository.Get(d => d.Name.ToLower() == newDrugStoreName.ToLower());
                        _druggistRepository.Update(druggist);
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please enter correct drug store name");
                        goto DrugStoreName;
                    }
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct druggist ID");
            }
        }

        public void DeleteDruggist()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter druggist name");
            string druggistName = Console.ReadLine();

            var druggist = _druggistRepository.Get(d => d.Name.ToLower() == druggistName.ToLower());
            if (druggist != null)
            {
                _druggistRepository.Delete(druggist);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"{druggistName} is deleted");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This druggist doesn't exist");
            }
        }
        public void GetAllDruggists()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All druggists list");

                foreach (var druggist in druggists)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"Id - {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }

        public void GetAllDruggistByDrugstore()
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
                var drugStoreDruggists = _druggistRepository.GetAll(d => d.Id == drugStore.Id);

                if (drugStoreDruggists.Count != 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All druggist of the drugstore:");

                    foreach (var drugStoreDruggist in drugStoreDruggists)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{drugStoreDruggist.Name}, {drugStoreDruggist.Surname}, {drugStoreDruggist.Age}, {drugStoreDruggist.Id}");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"There is no druggist in this drugstore {drugStore.Name}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including drugstore doesn't exist");
            }
        }
    }

}
