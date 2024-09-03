using BusinessLayer.Services.StoreServe;
using Microsoft.AspNetCore.Mvc;

namespace DapperSamples.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
           _storeService = storeService;
        }
        public IActionResult Index()
        {
            var stores = _storeService.GetAll();
            return View(stores);
        }
        [HttpPost]
        public IActionResult Index(string storeName, string zipCode)
        {
            var stores = _storeService.GetByFilter(storeName, zipCode);
            return View(stores);
        }
    }
}
