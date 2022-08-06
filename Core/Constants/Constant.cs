using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum Options1
    {
        Logout,
       CreateOwner,
       UpdateOwner,
       DeleteOwner,
       GetAllOwners
       

      
    }
    public enum Options2
    {
        Logout,
        CreateDrugstore,
        UpdateDrugstore,
        DeleteDrugstore,
        GetAllDrugstores,
        GetAllDrugstoresByOwner,
        Sale,
       
    }
    public enum Options3
    {   
        Logout,
        CreateDruggist,
        UpdateDruggist,
        DeleteDruggist,
        GetAllDruggists,
        GetAllDruggistByDrugstore,
       
    }
    public enum Options4
    {
        Logout,
        CreateDrug,
        UpdateDrug,
        DeleteDrug,
        GetAllDrugs,
        GetAllDrugsByDrugstore,
        Filter,
    }
}
