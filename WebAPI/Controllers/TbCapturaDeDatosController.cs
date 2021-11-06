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
    public class TbCapturaDeDatosController : ApiController
    {
        private ProyJenkinsEntities db = new ProyJenkinsEntities();

        // GET: api/TbCapturaDeDatos
        public IQueryable<TbCapturaDeDatos> GetTbCapturaDeDatos()
        {
            return db.TbCapturaDeDatos;
        }

        // GET: api/TbCapturaDeDatos/5
        [ResponseType(typeof(TbCapturaDeDatos))]
        public IHttpActionResult GetTbCapturaDeDatos(int id)
        {
            TbCapturaDeDatos tbCapturaDeDatos = db.TbCapturaDeDatos.Find(id);
            if (tbCapturaDeDatos == null)
            {
                return NotFound();
            }

            return Ok(tbCapturaDeDatos);
        }

        // PUT: api/TbCapturaDeDatos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbCapturaDeDatos(int id, TbCapturaDeDatos tbCapturaDeDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbCapturaDeDatos.IdRegistro)
            {
                return BadRequest();
            }

            db.Entry(tbCapturaDeDatos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCapturaDeDatosExists(id))
                {
                    return NotFound();
                    //Este es un cambio del dia 05/11/2021 21:32pm
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TbCapturaDeDatos
        [ResponseType(typeof(TbCapturaDeDatos))]
        public IHttpActionResult PostTbCapturaDeDatos(TbCapturaDeDatos tbCapturaDeDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TbCapturaDeDatos.Add(tbCapturaDeDatos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbCapturaDeDatos.IdRegistro }, tbCapturaDeDatos);
        }

        // DELETE: api/TbCapturaDeDatos/5
        [ResponseType(typeof(TbCapturaDeDatos))]
        public IHttpActionResult DeleteTbCapturaDeDatos(int id)
        {
            TbCapturaDeDatos tbCapturaDeDatos = db.TbCapturaDeDatos.Find(id);
            if (tbCapturaDeDatos == null)
            {
                return NotFound();
            }

            db.TbCapturaDeDatos.Remove(tbCapturaDeDatos);
            db.SaveChanges();

            return Ok(tbCapturaDeDatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TbCapturaDeDatosExists(int id)
        {
            return db.TbCapturaDeDatos.Count(e => e.IdRegistro == id) > 0;
        }
    }
}