using BusinessLibrary.Entity;
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

namespace BtTraining.Controllers
{
    public class ClientesController : ApiController
    {
        private BTServiceContext db = new BTServiceContext();

        // GET: api/Clientes
        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        
        public HttpResponseMessage PutCliente(int id, [FromBody]Cliente cliente)
        {
            try
            {
                using (db)
                {
                    var entity = db.Clientes.FirstOrDefault(e => e.clie_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Cliente com clie_id " + id.ToString() + " Nao foi encontrado");
                    }
                    else
                    {
                        entity.clie_nm_nome = cliente.clie_nm_nome;
                        entity.clie_nr_matricula = cliente.clie_nr_matricula;

                        db.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage PostCliente([FromBody] Cliente cliente)
        {
            try
            {
                using (var entities = db)
                {
                    entities.Clientes.Add(cliente);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, cliente);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        cliente.clie_id.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.clie_id == id) > 0;
        }
    }
}