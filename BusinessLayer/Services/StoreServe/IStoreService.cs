using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.StoreServe
{
    public interface IStoreService:IGenericService<Store>
    {
        List<Store> GetByFilter(string storeName,string zipCode);
    }
}
