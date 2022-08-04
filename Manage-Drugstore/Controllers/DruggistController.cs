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
        private DruggistRepository _druggistRepository;
        private DrugstoreRepository _drugstoreRepository;
        

        public DruggistController()
        {
            DruggistRepository = new DruggistRepository();
            _drugstoreRepository = new DrugstoreRepository();
        }
        public void CreateDruggist()
        {

        }

        public void UpdateDruggist()
        {

        }

        public void DeleteDruggist()
        {

        }

        public void GetAllDruggists()
        {

        }

        public void GetAllDruggistByDrugstore()
        {

        }
    }

}
