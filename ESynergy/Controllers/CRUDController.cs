using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ESynergy.Model;

namespace ESynergy.Controllers
{
    public class CRUDController : Controller
    {
        private decimal PVN = 0.21m;
        ProductContext objDataContext = new ProductContext();
        public ActionResult ProductDetails()
        {
            var list = objDataContext.Products.ToList();
            var response = new List<ProductResponse>();
            foreach (var product in list)
            {
                response.Add(new ProductResponse()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Count = product.Count,
                    Pvn = (product.Price*product.Count) * (1+PVN)
                });
            }
            return View(response);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            using (var context = new ProductContext())
            {
                context.Products.Add(model);
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            ViewBag.Message = message;

            return View();
        }
        public ActionResult Update(int Id)
        {
            using (var context = new ProductContext())
            {
                var data = context.Products.Where(x => x.Id == Id).SingleOrDefault();
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int Id, Product model)
        {
            using (var context = new ProductContext())
            {
                var data = context.Products.FirstOrDefault(x => x.Id == Id);

                if (data != null)
                {
                    data.Name = model.Name;
                    data.Price = model.Price;
                    data.Count = model.Count;
                    context.SaveChanges();

                    return RedirectToAction("ProductDetails");
                }
                else
                    return View();
            }
        }
        public ActionResult Delete()
            {
                return View();
            }
        [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int Id)
            {
                using (var context = new ProductContext())
                {
                    var data = context.Products.FirstOrDefault(x => x.Id == Id);
                    if (data != null)
                    {
                        context.Products.Remove(data);
                        context.SaveChanges();
                        return RedirectToAction("ProductDetails");
                    }
                    else 
                        return View();
                }
            }
    }
}
