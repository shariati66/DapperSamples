using BusinessLayer.Models;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.StoreServe
{
    public class StoreService : IStoreService
    {
        private readonly IDataAccess<Store> _dataAccess;

        public StoreService(IDataAccess<Store> dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<Store> GetAll()
        {
            var stores =  _dataAccess.GetAll("sales.stores");
            return stores.Result;
        }

        public List<Store> GetByFilter(string storeName, string zipCode)
        {
            var isStoreName = (storeName ==null && storeName?.Length>0)?true:false;
            bool isZipCode = (zipCode == null && zipCode?.Length>0)?true: false;
            string whereClause = string.Empty;
            if (isStoreName && isZipCode)
                whereClause = $"store_name LIKE '%{storeName}%' AND zip_code LIKE '%{zipCode}%'";
            else if (isStoreName)
                whereClause = $"store_name LIKE '%{storeName}%'";
            else if (isZipCode)
                whereClause = $"zip_code LIKE '%{zipCode}%'";
            else
                whereClause = $"store_name LIKE '%{storeName}%' AND zip_code LIKE '%{zipCode}%'";
            var stores = _dataAccess.GetByFilter("sales.stores", whereClause);
            return stores.Result;
        }
    }
}
