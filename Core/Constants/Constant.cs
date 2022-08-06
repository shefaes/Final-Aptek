using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum Options1
    {
        Exit,
       CreateOwner,
       UpdateOwner,
       DeleteOwner,
       GetAllOwners
       

      
    }
    public enum Options2
    {
        Exit,
        CreateDrugstore,
        UpdateDrugstore,
        DeleteDrugstore,
        GetAllDrugstores,
        GetAllDrugstoresByOwner,
        Sale,
       
    }
    public enum Options3
    {   
        Exit,
        CreateDruggist,
        UpdateDruggist,
        DeleteDruggist,
        GetAllDruggists,
        GetAllDruggistByDrugstore,
       
    }
    public enum Options4
    {
        Exit,
        CreateDrug,
        UpdateDrug,
        DeleteDrug,
        GetAllDrugs,
        GetAllDrugsByDrugstore,
        Filter,
    }
}
