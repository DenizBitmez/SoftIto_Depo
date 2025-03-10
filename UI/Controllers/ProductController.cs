using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EFProductDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        StockDetailsManager sm = new StockDetailsManager(new EFStockDetailsDal());
        BarcodeManager bm = new BarcodeManager(new EFBarcodeDal());
        Context _context = new Context();

        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Products.Where(s => s.IsActive).ToList();
            return View(products);
        }

        public ActionResult ProductAdd()
        {
            List<SelectListItem> sonuc = (from x in cm.Categoryliste()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.d = sonuc;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            pm.ProductInsert(product);
            return RedirectToAction("Index");
        }

        public ActionResult ProductUpdate(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = pm.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = cm.Categoryliste()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList();

            return View(product);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = cm.Categoryliste()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CategoryId.ToString()
                    }).ToList();

                return View(product);
            }

            pm.ProductUpdate(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProductDelete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            product.IsActive = false;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult CategoryIndex()
        {
            var categories = _context.Categories.Where(c => c.IsActive).ToList();
            return View(categories);
        }

        public ActionResult CategoryAdd()
        {
            List<SelectListItem> sonuc = (from x in cm.Categoryliste()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.d = sonuc;
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            cm.CategoryInsert(category);
            return RedirectToAction("CategoryIndex");
        }

        public ActionResult CategoryUpdate(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = cm.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = cm.Categoryliste()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList();

            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = cm.Categoryliste()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CategoryId.ToString()
                    }).ToList();

                return View(category);
            }

            cm.CategoryUpdate(category);
            return RedirectToAction("CategoryIndex");
        }

        public ActionResult CategoryDelete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category != null)
            {
                category.IsActive = false;
                _context.SaveChanges();

                return RedirectToAction("CategoryIndex");
            }

            return HttpNotFound();
        }



        public ActionResult StockIndex()
        {
            var stocks = _context.StockDetails.Where(s => s.IsActive).ToList();
            return View(stocks);
        }

        public ActionResult AddStock()
        {
            List<SelectListItem> productList = _context.Products
        .Select(p => new SelectListItem
        {
            Text = p.Name,
            Value = p.ProductId.ToString()
        })
        .ToList();

            ViewBag.Products = productList;
            return View();
        }


        [HttpPost]
        public ActionResult AddStock(StockDetails stock)
        {
            if (!_context.Products.Any(p => p.ProductId == stock.ProductId))
            {
                ModelState.AddModelError("", "Seçilen ürün bulunamadı.");
                return View(stock);
            }

            _context.StockDetails.Add(stock);
            _context.SaveChanges();
            return RedirectToAction("StockIndex");
        }

        public ActionResult UpdateStock(int id)
        {
            var stock = _context.StockDetails
                               .FirstOrDefault(s => s.StockDetailsId == id);

            if (stock == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> productList = _context.Products
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.ProductId.ToString(),
                    Selected = p.ProductId == stock.ProductId
                })
                .ToList();

            ViewBag.Products = productList;

            return View(stock);
        }

        [HttpPost]
        public ActionResult UpdateStock(StockDetails stock)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> productList = _context.Products
                    .Select(p => new SelectListItem
                    {
                        Text = p.Name,
                        Value = p.ProductId.ToString(),
                        Selected = p.ProductId == stock.ProductId
                    })
                    .ToList();

                ViewBag.Products = productList;
                return View(stock);
            }

            var existingStock = _context.StockDetails.FirstOrDefault(s => s.StockDetailsId == stock.StockDetailsId);

            if (existingStock == null)
            {
                return HttpNotFound();
            }

            existingStock.ProductId = stock.ProductId;
            existingStock.Quantity = stock.Quantity;
            existingStock.Date = stock.Date;

            _context.SaveChanges();

            return RedirectToAction("StockIndex");
        }

        public ActionResult DeleteStock(int id)
        {
            var stock = _context.StockDetails.FirstOrDefault(s => s.StockDetailsId == id);

            if (stock == null)
            {
                return HttpNotFound();
            }

            stock.IsActive = false;

            _context.SaveChanges();

            return RedirectToAction("StockIndex");
        }

        public ActionResult SupplierIndex()
        {
            var suppliers = _context.Supplies.Where(s => s.IsActive).ToList();
            return View(suppliers);
        }

        public ActionResult SupplierAdd()
        {
            List<SelectListItem> supplierList = _context.Supplies
       .Select(s => new SelectListItem
       {
           Text = s.Name,
           Value = s.SupplierId.ToString()
       })
       .ToList();

            ViewBag.Supplies = supplierList;
            return View();

        }

        [HttpPost]
        public ActionResult SupplierAdd(Supplier supplier)
        {
            if (!_context.Supplies.Any(s => s.SupplierId == supplier.SupplierId))
            {
                ModelState.AddModelError("", "Seçilen ürün bulunamadı.");
                return View(supplier);
            }

            _context.Supplies.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("SupplierIndex");
        }

        public ActionResult SupplierUpdate(int id)
        {
            var supplier = _context.Supplies.FirstOrDefault(s => s.SupplierId == id);
            if (supplier != null)
            {
                return View(supplier);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult SupplierUpdate(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var existingSupplier = _context.Supplies.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
                if (existingSupplier != null)
                {
                    existingSupplier.Name = supplier.Name;
                    existingSupplier.ContactPerson = supplier.ContactPerson;
                    existingSupplier.Phone = supplier.Phone;
                    _context.SaveChanges();
                    return RedirectToAction("SupplierIndex");
                }
            }
            return View(supplier);
        }
        public ActionResult DeleteSupplier(int id)
        {
            var supplier = _context.Supplies.FirstOrDefault(s => s.SupplierId == id);
            if (supplier != null)
            {
                supplier.IsActive = false;
                _context.SaveChanges();
                return RedirectToAction("SupplierIndex");
            }
            return HttpNotFound();
        }

        public ActionResult ScanIndex()
        {
            var barcodes = _context.Barcodes.Include("Product").ToList();
            return View(barcodes);
        }

        public ActionResult ScanBarcode(int productId)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return HttpNotFound("Ürün bulunamadı.");
            }

            var barcodeModel = new Barcode
            {
                ProductId = productId,
                CreatedDate = DateTime.Now
            };

            return View(barcodeModel);
        }

        [HttpPost]
        public ActionResult ScanBarcode(Barcode barcode)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Geçersiz veriler gönderildi.";
                return View(barcode);
            }

            // Ürünü bul
            var product = _context.Products.SingleOrDefault(p => p.ProductId == barcode.ProductId);
            if (product == null)
            {
                ViewBag.ErrorMessage = "Ürün bulunamadı.";
                return View(barcode);
            }

            // Barkodu kaydet
            _context.Barcodes.Add(barcode);
            _context.SaveChanges();

            // Stok güncelleme
            if (barcode.MovementType)
            {
                product.Stock += 1; // Giriş
            }
            else
            {
                if (product.Stock > 0)
                {
                    product.Stock -= 1; // Çıkış
                }
                else
                {
                    ViewBag.ErrorMessage = "Stoğunuzda yeterli ürün yok.";
                    return View(barcode);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("ScanIndex");
        }
    }
}

