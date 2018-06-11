using J_Market.Models;
using J_Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J_Market.Controllers
{
    
    public class OrdersController : Controller
    {
        private J_MarketContext db = new J_MarketContext();
        // GET: Orders
        public ActionResult NewOrders()
        {
            var orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();
            Session["orderView"] = orderView;

            var list = db.Customers.ToList();
            list.Add(new Customer {CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            list = list.OrderBy(c => c.FullName).ToList();
                       ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");
     
            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrders(OrderView orderView)
        {

             orderView = Session["orderView"] as OrderView;

            var customerID = int.Parse(Request["CustomerID"]);


            if(customerID == 0)
            {
               
              

                var listac = db.Customers.ToList();
                ViewBag.ID = new SelectList(listac, "CustomerID", "FullName");
                ViewBag.Error = "Debe seleccionar un Cliente";
                listac.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
                listac = listac.OrderBy(c => c.FullName).ToList();
                ViewBag.CustomerID = new SelectList(listac, "CustomerID", "FullName");

                return View(orderView);
            }
            var customer = db.Customers.Find(customerID);
            if(customer == null)
            {
                
               
                ViewBag.Errors = "Cliente No existe";
                var listac = db.Customers.ToList();
                ViewBag.ID = new SelectList(listac, "CustomerID", "FullName");
                listac.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente]" });
                listac = listac.OrderBy(c => c.FullName).ToList();

                return View(orderView);
            }

            if(orderView.Products.Count == 0)
            {
             
               
                ViewBag.Errors = "Cliente Ingresar detalle";
                var listac = db.Customers.ToList();
                ViewBag.ID = new SelectList(listac, "CustomerID", "FullName");
                listac.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente]" });
                listac = listac.OrderBy(c => c.FullName).ToList();

                return View(orderView);
            }

            // Guardar la Orden En base de datos 
            int orderID = 0;
            using (var transaction = db.Database.BeginTransaction()) {

                try
                {
                    var order = new Order
                    {
                        CustomerID = customerID,
                        DateOrder = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderID = db.Orders.ToList().Select(o => o.OrderID).Max();

                    foreach (var item in orderView.Products)
                    {
                        var orderDetail = new OrderDetail
                        {
                            ID = item.ID,
                            Description = item.Description,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            OrderID = orderID
                        };
                        db.orderDetails.Add(orderDetail);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    ViewBag.Error = "ERROR" + ex.Message;

                    var listc = db.Customers.ToList();
                    listc.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
                    listc = listc.OrderBy(c => c.FullName).ToList();
                    ViewBag.CustomerID = new SelectList(listc, "CustomerID", "FullName");

                    return View(orderView);
                }
              
            }

            ViewBag.Message = string.Format("La orden: {0}, Grabado ok", orderID);

            var list = db.Customers.ToList();
            list.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");

            orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();
            Session["orderView"] = orderView;
            var lista = db.Customers.ToList();
            list.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");

            return View(orderView);
        }

        public ActionResult AddProduct()
        {
            var list = db.Products.ToList();
            list.Add(new ProductOrder { ID = 0, Description = "[Seleccione un Producto...]" });
            list = list.OrderBy(p => p.Description).ToList();
           
            ViewBag.ID = new SelectList(list, "ID", "Description");
           
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder ProductOrder)
        {
            var orderView = Session["orderView"] as OrderView;
            var ProductID = int.Parse(Request["ID"]);
            if (ProductID == 0)
            {

                var list = db.Products.ToList();
                list.Add(new ProductOrder { ID = 0, Description = "[Seleccione un Producto...]" });
                list = list.OrderBy(p => p.Description).ToList();

                ViewBag.ID = new SelectList(list, "ID", "Description");
                ViewBag.Error = "Debe seleccionar un Producto";

                return View(ProductOrder);
            }

            var product = db.Products.Find(ProductID);
            if (product == null)
            {

                var list = db.Products.ToList();
                list.Add(new ProductOrder { ID = 0, Description = "[Seleccione un Producto...]" });
                list = list.OrderBy(p => p.Description).ToList();

                ViewBag.ID = new SelectList(list, "ID", "Description");
                ViewBag.Error = "El Producto No existe";

                return View(ProductOrder);
            }

            ProductOrder = orderView.Products.Find(p => p.ID == ProductID);
            if( ProductOrder == null)
            {
                ProductOrder = new ProductOrder
                {
                    Description = product.Description,
                    Price = product.Price,
                    ID = product.ID,
                    Quantity = float.Parse(Request["Quantity"]),

                };
                orderView.Products.Add(ProductOrder);
            } else
            {
              
                ProductOrder.Quantity += float.Parse(Request["Quantity"]);
            }

         

            
            var listc = db.Customers.ToList();
            listc.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            listc = listc.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(listc, "CustomerID", "FullName");

            return View("NewOrders", orderView);
        }

        public ActionResult EditRole(ProductOrder ID )
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}