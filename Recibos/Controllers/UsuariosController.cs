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
    public class UsuariosController : ApiController
    {
        private PruebaGioEntities db = new PruebaGioEntities();

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuario.Add(usuario);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = usuario.idUsuario }, usuario);
            return Ok("JALO");
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        [HttpDelete]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.idUsuario == id) > 0;
        }
        public UsuarioDTO UsuarioExists(string user, string contra)
        {
            return db.Usuario.Where(w => (w.usuario1 == user && w.contra == contra) || (w.correo == user && w.contra == contra)).Select(s => new UsuarioDTO
                {
                    idUsuario = s.idUsuario,
                    nombre = s.nombre,
                    apellido = s.apellido,
                    usuario1 = s.usuario1,
                    correo = s.correo,
                    contra = s.contra
            }).FirstOrDefault();
        }
    }
}