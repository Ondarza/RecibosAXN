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
using Recibos.Models;

namespace Recibos.Controllers
{
    public class RecibosController : ApiController
    {
        private PruebaGioEntities db = new PruebaGioEntities();

        // GET: api/Recibos
        public List<ReciboDTO> GetRecibo()
        {
            return db.Recibo.Select(s => new ReciboDTO
            {
                idRecibo = s.idRecibo,
                idUsuario = s.idUsuario,
                proveedor = s.proveedor,
                monto = s.monto,
                moneda = s.moneda,
                fecha = s.fecha,
                comentario = s.comentario
            }).ToList();
        }

        // GET: api/Recibos/5
        [ResponseType(typeof(Recibo))]
        public IHttpActionResult GetRecibo(int id)
        {
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return NotFound();
            }

            return Ok(recibo);
        }

        // PUT: api/Recibos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecibo(int id, Recibo recibo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recibo.idRecibo)
            {
                return BadRequest();
            }

            db.Entry(recibo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciboExists(id))
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

        // POST: api/Recibos
        [ResponseType(typeof(Recibo))]
        public IHttpActionResult PostRecibo(Recibo recibo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recibo.Add(recibo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recibo.idRecibo }, recibo);
        }

        // DELETE: api/Recibos/5
        [ResponseType(typeof(Recibo))]
        public IHttpActionResult DeleteRecibo(int id)
        {
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return NotFound();
            }

            db.Recibo.Remove(recibo);
            db.SaveChanges();

            return Ok(recibo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReciboExists(int id)
        {
            return db.Recibo.Count(e => e.idRecibo == id) > 0;
        }

        [ResponseType(typeof(List<Recibo>))]
        public List<ReciboDTO> GetRecibos(int id, bool x)
        {
            return db.Recibo.Where(w => (w.idUsuario == id)).Select(s => new ReciboDTO
            {
                idRecibo = s.idRecibo,
                idUsuario = s.idUsuario,
                proveedor = s.proveedor,
                monto = s.monto,
                moneda = s.moneda,
                fecha = s.fecha,
                comentario = s.comentario
            }).ToList();
        }
    }
}