using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TbLoginsController : ApiController
    {
        private ProyJenkinsEntities db = new ProyJenkinsEntities();

        // GET: api/TbLogins
        public IQueryable<TbLogin> GetTbLogin()
        {
            return db.TbLogin;
        }

        // GET: api/TbLogins/5
        [ResponseType(typeof(TbLogin))]
        public IHttpActionResult GetTbLogin(int id)
        {
            TbLogin tbLogin = db.TbLogin.Find(id);
            if (tbLogin == null)
            {
                return NotFound();
            }

            return Ok(tbLogin);
        }

        // PUT: api/TbLogins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbLogin(int id, TbLogin tbLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbLogin.IdUsuario)
            {
                return BadRequest();
            }

            db.Entry(tbLogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TbLogins
        [ResponseType(typeof(TbLogin))]
        public IHttpActionResult PostTbLogin(TbLogin tbLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TbLogin.Add(tbLogin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbLogin.IdUsuario }, tbLogin);
        }

        // DELETE: api/TbLogins/5
        [ResponseType(typeof(TbLogin))]
        public IHttpActionResult DeleteTbLogin(int id)
        {
            TbLogin tbLogin = db.TbLogin.Find(id);
            if (tbLogin == null)
            {
                return NotFound();
            }

            db.TbLogin.Remove(tbLogin);
            db.SaveChanges();

            return Ok(tbLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TbLoginExists(int id)
        {
            return db.TbLogin.Count(e => e.IdUsuario == id) > 0;
        }
    }
}