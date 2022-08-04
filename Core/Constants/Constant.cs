using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum Options
    {
       CreateOwner,
       UpdateOwner,
       DeleteOwner,
       GetAllOwners,

       CreateDrugstore,
       UpdateDrugstore,
       DeleteDrugstore,
       GetAllDrugstores,
       GetAllDrugstoresByOwner,
       Sale,

       CreateDruggist,
       UpdateDruggist,
       DeleteDruggist,
       GetAllDruggists,
       GetAllDruggistByDrugstore,

       CreateDrug,
       UpdateDrug,
       DeleteDrug,
       GetAllDrugs,
       GetAllDrugsByDrugstore,
       Filter,
    }
}
