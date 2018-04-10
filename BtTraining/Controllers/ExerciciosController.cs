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
using BusinessLibrary.Entity;


namespace BtTraining.Controllers
{
    public class ExerciciosController : ApiController
    {
        private BTServiceContext db = new BTServiceContext();

        // GET: api/Exercicios
        public IQueryable<Exercicio> Getexercicios()
        {
            var exercicios = db.Exercicios.Include(e => e.Cliente).Include(e => e.professor);
            return exercicios;
        }

        // GET: api/Exercicios/5
        [ResponseType(typeof(Exercicio))]
        public IHttpActionResult GetExercicio(int id)
        {
            //Exercicio exercicio = db.Exercicios.Find(id);
            var exercicio = db.Exercicios
                .Include(e => e.Cliente)
                .Include(e => e.professor);
            var exercicioobj = exercicio.FirstOrDefault(e => e.Exer_id == id);

            if (exercicio == null)
            {
                return NotFound();
            }

            return Ok(exercicioobj);
        }

        // PUT: api/Exercicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercicio(int id, Exercicio exercicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercicio.Exer_id)
            {
                return BadRequest();
            }

            db.Entry(exercicio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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

        // POST: api/Exercicios
        [ResponseType(typeof(Exercicio))]
        public IHttpActionResult PostExercicio(Exercicio exercicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercicios.Add(exercicio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercicio.Exer_id }, exercicio);
        }

        // DELETE: api/Exercicios/5
        [ResponseType(typeof(Exercicio))]
        public IHttpActionResult DeleteExercicio(int id)
        {
            Exercicio exercicio = db.Exercicios.Find(id);

            if (exercicio == null)
            {
                return NotFound();
            }

            db.Exercicios.Remove(exercicio);
            db.SaveChanges();

            return Ok(exercicio);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExercicioExists(int id)
        {
            return db.Exercicios.Count(e => e.Exer_id == id) > 0;
        }
    }
}