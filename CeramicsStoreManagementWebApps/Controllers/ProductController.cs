using CeramicsStoreManagementWebApps.BLL;
using CeramicsStoreManagementWebApps.Models;
using CeramicsStoreManagementWebApps.Models.ViewModel;
using System.Web.Mvc;

namespace CeramicsStoreManagementWebApps.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ProductManager aProductManager = new ProductManager();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Add
        public ActionResult Add()
        {
            ViewBag.Brands = new SelectList(db.Brands, "ID", "Name");
            ViewBag.Country = new SelectList(db.Countries, "ID", "ManufacturingCountry");
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Product aProduct = new Product()
                {
                    Name = product.Name,
                    Color = product.Color,
                    Size = product.Size,
                    Description = product.Description,
                    BrandID = product.BrandID,
                    CountryID = product.CountryID,
                };
                db.Products.Add(aProduct);
                db.SaveChanges();

                Product productID = aProductManager.GetProductID();
                Price aPrice = new Price()
                {
                    ProductID = productID.ID,
                    Purches = product.PurchesPrice,
                    MinSelling = product.MinSellingPrice,
                    MaxSelling = product.MaxSellingPrice,
                };
                db.Prices.Add(aPrice);
                db.SaveChanges();

                Store aStore = new Store()
                {
                    Quentity = product.Quentity,
                    ProductID = productID.ID,
                };

                db.Stores.Add(aStore);
                db.SaveChanges();
                ModelState.Clear();
            }


            ViewBag.Brands = new SelectList(db.Brands, "ID", "Name");
            ViewBag.Country = new SelectList(db.Countries, "ID", "ManufacturingCountry");
            return View();
        }

        public ActionResult Display()
        {
            return View();
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
