using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Master_Arepa.Models;
using System.Net.Mail;
using System.Net;
using Master_Arepa.Models.ArepaViewModels;
using Master_Arepa.Data;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using EFCore.BulkExtensions;

namespace Master_Arepa.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        public ApplicationDbContext _context;

        protected List<HomeInventory> HomeInventory = new List<HomeInventory>();

        protected List<FoodTruckInventory> FoodTruckInventory = new List<FoodTruckInventory>();

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FoodTruck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(InventoryViewModel model)
        {
            // Deal with the data from the database
            try
            {
                HomeInventory = _context.HomeInventory.ToList();

                Type type = typeof(InventoryViewModel);
                PropertyInfo[] properties = type.GetProperties();

                int id = 0;

                foreach (var pro in properties)
                {
                    HomeInventory home = new HomeInventory();
                    home.Id = SetID_And_Inventory_HomeInventory(pro?.Name, ref id, (int)pro.GetValue(model));
                    home.Item = pro.Name;
                    home.Quantity = (int)pro.GetValue(model);
                    home.Type = InventoryType.Home.ToString();
                    home.TimeStamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow
                            , TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                    if (!_context.HomeInventory.Any(x => x.Item == pro.Name))
                        HomeInventory.Add(home);
                }
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message;
                return View();
            }

            try
            {
                using (var tran = _context.Database.BeginTransaction())
                {
                    _context.BulkInsertOrUpdate(HomeInventory);
                    tran.Commit();
                }
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message;
                return View();
            }

            //try
            //{
            //    sendEmail("smtp.gmail.com", 587, "cguisao@masterarepa.com", "lotero321"
            //    , "cguisao@masterarepa.com", email, message);
            //}
            //catch(Exception e)
            //{
            //    ViewData["Error"] = e.Message;
            //    return View();
            //}
            //ViewBag.Success = "Message sent, thank you!";
            //return Redirect("#subscribe");
            ViewData["Success"] = "Home Inventory Updated Successfully!";
            return View();
        }

        [HttpPost]
        public IActionResult FoodTruck(InventoryViewModel model)
        {
            try
            {
                FoodTruckInventory = _context.FoodTruckInventory.ToList();

                Type type = typeof(InventoryViewModel);
                PropertyInfo[] properties = type.GetProperties();

                int id = 0;

                foreach (var pro in properties)
                {
                    FoodTruckInventory foodTruck = new FoodTruckInventory();
                    foodTruck.Id = SetID_And_Inventory_FoodTruck(pro?.Name, ref id, (int)pro.GetValue(model));
                    foodTruck.Item = pro.Name;
                    foodTruck.Quantity = (int)pro.GetValue(model);
                    foodTruck.Type = InventoryType.Food_Truck.ToString();
                    foodTruck.TimeStamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow
                            , TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                    if (!_context.FoodTruckInventory.Any(x => x.Item == pro.Name))
                        FoodTruckInventory.Add(foodTruck);
                }
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message;
                return View();
            }

            try
            {
                using (var tran = _context.Database.BeginTransaction())
                {
                    _context.BulkInsertOrUpdate(FoodTruckInventory);
                    tran.Commit();
                }
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message;
                return View();
            }

            ViewData["Success"] = "Food Truck Inventory Updated Successfully!";
            return View();
        }

        private int SetID_And_Inventory_HomeInventory(string name, ref int id, int quantity)
        {
            int insideId = _context.HomeInventory.Where(x => x.Item == name).Select(x => x.Id).FirstOrDefault();
            if(_context.HomeInventory.Any(x => x.Item == name))
            {
                var item = HomeInventory.ElementAt(HomeInventory.FindIndex(x => x.Id == insideId));
                item.Quantity = HomeInventory.Find(x => x.Item == name).Quantity + quantity;
                return _context.HomeInventory.Select(x => x.Id).FirstOrDefault();
            }
            else
            {
                id = id + _context.HomeInventory.Select(x => x.Id).Count() + 1;
                return id;
            }
        }

        private int SetID_And_Inventory_FoodTruck(string name, ref int id, int quantity)
        {
            int insideId = _context.FoodTruckInventory.Where(x => x.Item == name).Select(x => x.Id).FirstOrDefault();
            if (_context.FoodTruckInventory.Any(x => x.Item == name))
            {
                var item = FoodTruckInventory.ElementAt(FoodTruckInventory.FindIndex(x => x.Id == insideId));
                item.Quantity = FoodTruckInventory.Find(x => x.Item == name).Quantity + quantity;
                return _context.FoodTruckInventory.Select(x => x.Id).FirstOrDefault();
            }
            else
            {
                id = id + _context.FoodTruckInventory.Select(x => x.Id).Count() + 1;
                return id;
            }
        }

        public void sendEmail(string smtpClient, int port, string emailCredential, string passwordCredential,
            string fromEmail, string email, string message)
        {
            SmtpClient client = new SmtpClient(smtpClient, port);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(emailCredential, passwordCredential);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(email);
            mailMessage.To.Add(fromEmail);
            mailMessage.Body = message;
            mailMessage.Subject = email + " sent a message from the web";
            client.Send(mailMessage);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
