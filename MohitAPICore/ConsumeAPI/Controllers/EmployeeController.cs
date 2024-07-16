using Microsoft.AspNetCore.Mvc;
using System.Text;
using ConsumeAPI.Models;
using Newtonsoft.Json;

namespace ConsumeAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private IConfiguration _iconfiguration;
        Employee emp =new  Employee();
        public EmployeeController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public async Task<IActionResult> Index()
        {
            string dbConn = _iconfiguration.GetSection("WebApiUrl").Value;
            List<Employee> empList = new List<Employee>();
            using (var httpClient = new HttpClient())// For avoiding "The SSL connection could not be established see inner Exception" we have to use "HttpClientHandle".
            {
                using (var response = await httpClient.GetAsync(dbConn))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        empList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                    }
                }
            }
            return View(empList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee empObj)
        {
            string dbConn = _iconfiguration.GetSection("WebApiUrl").Value;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(empObj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(dbConn, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
           Employee _emp = new Employee();
            string dbConn = _iconfiguration.GetSection("WebApiUrl").Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(dbConn + "/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _emp = JsonConvert.DeserializeObject<Employee>(apiResponse);
                    }
                }
            }
            return View(_emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee empObj)
        {
            string dbConn = _iconfiguration.GetSection("WebApiUrl").Value;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(empObj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(dbConn,content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            string dbConn = _iconfiguration.GetSection("WebApiUrl").Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(dbConn +"/"+ id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            Employee _emp = new Employee();
            string dbConn = _iconfiguration.GetSection("WebApiUrl").Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(dbConn +"/"+ id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _emp = JsonConvert.DeserializeObject<Employee>(apiResponse);
                    }
                }
            }
            return View(_emp);
        }

    }
}
