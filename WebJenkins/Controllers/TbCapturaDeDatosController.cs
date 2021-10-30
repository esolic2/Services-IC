using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebJenkins.Models;

namespace WebJenkins.Controllers
{
    public class TbCapturaDeDatosController : Controller
    {
        // GET: TbCapturaDeDatos
        public async Task<ActionResult> Index()
        {
            IEnumerable<mvcTbCargaDeDatosModel> tbDatosList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TbCapturaDeDatos").Result;
            tbDatosList = response.Content.ReadAsAsync<IEnumerable<mvcTbCargaDeDatosModel>>().Result;
            return View(tbDatosList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id==0)
            return View(new mvcTbCargaDeDatosModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TbCapturaDeDatos/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcTbCargaDeDatosModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcTbCargaDeDatosModel emp)
        {
            if (emp.IdRegistro == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TbCapturaDeDatos", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TbCapturaDeDatos/"+emp.IdRegistro, emp).Result;
                TempData["SuccessMessage"] = "Update Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TbCapturaDeDatos/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}