using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVC_Project2021.Data;
using MVC_Project2021.Models;
using MVC_Project2021.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace MVC_Project2021.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string searchBy, string search)
        {
                if (searchBy == "Product Code")
                {
                    return View(_db.Product.Where(x => x.ProductCode.Contains(search) || search == null).ToList());
                }
                else
                {
                    return View(_db.Product.Where(x => x.ProductName.Contains(search) || search == null).ToList());
                }
        }

        //Get - Create
        public IActionResult Create()
        {

            return View();
        }
        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateViewModel obj)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(obj);

                Product newProduct = new Product
                {
                    ProductCode = obj.ProductCode,
                    ProductName = obj.ProductName,
                    ProductPrice = obj.ProductPrice,
                    ProductImage = uniqueFileName

                };
                _db.Product.Add(newProduct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);            
        }

        //Get - Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null|| id == 0)
            {
                return NotFound();
            }
            var obj = _db.Product.Find(id);
            if(obj != null)
            { 
                ProductEditViewModel productEditViewModel = new ProductEditViewModel
                {
                    Id = obj.Id,
                    ProductCode = obj.ProductCode,
                    ProductName = obj.ProductName,
                    ProductPrice = obj.ProductPrice,
                    ExistingImagePath = obj.ProductImage
                };
                return View(productEditViewModel);
            }
            return NotFound();
        }
        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(ProductEditViewModel obj)
        {
            if (ModelState.IsValid)
            {

                Product product = _db.Product.Find(obj.Id);
                product.ProductCode = obj.ProductCode;
                product.ProductName = obj.ProductName;
                product.ProductPrice = obj.ProductPrice;

                if (obj.ProductImage != null)
                {
                    product.ProductImage = ProcessUploadedFile(obj);
                } 

                _db.Product.Update(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        private string ProcessUploadedFile(ProductCreateViewModel obj)
        {
            string uniqueFileName = null;
            if (obj.ProductImage != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "lib\\img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + obj.ProductImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                obj.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            return uniqueFileName;
        }

        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = obj.Id,
                ProductCode = obj.ProductCode,
                ProductName = obj.ProductName,
                ProductPrice = obj.ProductPrice,
                ExistingImagePath = obj.ProductImage
            };
            return View(productEditViewModel);
        }
        //Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Product.Find(id);
            if (obj != null)
            {
                _db.Product.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }    
            return NotFound();
        }
    }
}
