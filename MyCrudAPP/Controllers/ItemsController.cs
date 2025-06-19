using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyCrudAPP.Models;

using Newtonsoft.Json;
using System.Text;

namespace MyCrudAPP.Controllers
{
    public class ItemsController : Controller
    {
       // private readonly ApplicationDbContext context;
        Uri baseAddress = new Uri("https://localhost:7071/api");
        private readonly HttpClient _client;
        private static List<Items> ItemList = new();
        public ItemsController()
        {
            //this.context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Items> itemslist= new List<Items>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Items").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                itemslist = JsonConvert.DeserializeObject<List<Items>>(data);
            }
           // var Items = context.Items.OrderByDescending(x => x.Id).ToList();
            return View(itemslist);
        }
        
       
    
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create([FromBody] Items item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                string data = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client
                    .PostAsync(_client.BaseAddress + "/Items/Post", content)
                    .Result;

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Item added." });
                }
                else
                {
                    return Json(new { success = false, message = "API error." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        //[HttpPost]
        //public IActionResult Create(Items item)
        //{
        //    try
        //    {
        //        string data = JsonConvert.SerializeObject(item);
        //        StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
        //        HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Items/Post",content).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            TempData["successMessage"] = "Items Added.";
        //            return RedirectToAction("Index");
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["errorMessage"] =ex.Message;
        //    }
        //    return View();

        //}
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Items item = new Items();
            try
            {
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Items/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<Items>(data);
                }
                return View(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            // var Items = context.Items.OrderByDescending(x => x.Id).ToList();
          
        }

        [HttpPost]
        public IActionResult Edit(Items item)
        {
            try
            {
                string data = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Items/Put", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Items Updated.";
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {

            Items item = new Items();
            try
            {
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Items/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<Items>(data);
                }
                return View(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            // var Items = context.Items.OrderByDescending(x => x.Id).ToList();
            
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Items/" + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Items Deleted.";
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View();

        }

    }
}
