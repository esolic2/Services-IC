using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebJenkins.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;

namespace WebJenkins.Controllers
{
    public class TbLoginController : Controller
    {
        // GET: TbLogin
        public ActionResult LoginWebApi()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Autherize(mvcTbLoginModel adminlogin)
        {
            using (ProyJenkinsEntities db = new ProyJenkinsEntities())
            {
                var obj = db.TbLogin.Where(a => a.Usuario == adminlogin.Usuario && a.contraseña == adminlogin.contraseña).FirstOrDefault();
                if (obj == null)
                {
                    TempData["SuccessMessage"] = "wrong username and password: plese provide correct login data!!";
                    adminlogin.loginErrorMessage = "wrong username and password: plese provide correct login data!!";
                    return View("LoginWebApi", adminlogin);
                }
                else if (adminlogin.Usuario == "" || adminlogin.contraseña == "")
                {
                    TempData["SuccessMessage"] = "Please Provid Username and Password";
                    return View("LoginWebApi", adminlogin);
                }
                else
                {
                    Session["IdUsuario"] = obj.IdUsuario;
                    Session["Usuario"] = obj.Usuario;
                    TempData["SuccessMessage"] = "You are Successfully Loggin as Admin " + adminlogin.Usuario.ToString();
                    return RedirectToAction("Index", "TbCapturaDeDatos");

                }

            }
        }
        

    // systm logout
    public ActionResult logout(mvcTbLoginModel adminlog)
        {
            int idUsuario = (int)Session["idUsuario"];
            Session.Abandon();
            TempData["BadMsg"] = "You are Successfully Logout as Admin " + adminlog.Usuario.ToString();
            return RedirectToAction("Index", "AdminLogin");

        }

    }
}