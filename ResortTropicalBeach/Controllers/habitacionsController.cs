using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResortTropicalBeach.Data;
using ResortTropicalBeach.Models;

namespace ResortTropicalBeach.Controllers
{
    public class habitacionsController : Controller
    {
        private readonly resortDbContext _context;

        public habitacionsController(resortDbContext context)
        {
            _context = context;
        }

        // GET: habitacions
        public async Task<IActionResult> Index()

        { 
            var codigoSQL = await _context.habitacions.ToListAsync();

            IEnumerable<habitacion> HabitacionQuery = await
                                                (from habitacion in _context.habitacions
                                                where habitacion.Id > 20
                                                select habitacion).ToListAsync();

            return View(await _context.habitacions.ToListAsync());
        }

        // GET: habitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            //forma  1 sp
            var response = new List<habitacion>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "PRC_CRUD_SelectById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                
                _context.Database.OpenConnection();

                //var dataReader = command.ExecuteReader();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        // response.Add(new Registros { Id=reader[0].va,Usuario= reader[1], Password =reader[2]});
                        response.Add(new habitacion
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            nHabitacion = reader.GetInt32(reader.GetOrdinal("nHabitacion")),
                            detalles = reader.GetString(reader.GetOrdinal("detalles")),
                            disponible = reader.GetBoolean(reader.GetOrdinal("disponible")),
                            piso = reader.GetInt32(reader.GetOrdinal("piso")),
                            tipo = reader.GetString(reader.GetOrdinal("tipo"))

                        });

                    }
                }
             
               // return View(response);
            }

            _context.Database.CloseConnection();

            var habitacion = await _context.habitacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: habitacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: habitacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,piso,nHabitacion,tipo,detalles,disponible")] habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitacion);
        }

        // GET: habitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return View(habitacion);
        }

        // POST: habitacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,piso,nHabitacion,tipo,detalles,disponible")] habitacion habitacion)
        {

          
                var registros_afectados =
                    await _context.Database.ExecuteSqlCommandAsync(
                        "UPDATE habitacions SET piso = 2, nHabitacion = 201 Where Id = @id",
                        new SqlParameter("@Id", id));
           


            if (id != habitacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!habitacionExists(habitacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(habitacion);
        }

        // GET: habitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.habitacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: habitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacion = await _context.habitacions.FindAsync(id);
            _context.habitacions.Remove(habitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool habitacionExists(int id)
        {
            return _context.habitacions.Any(e => e.Id == id);
        }
    }
}
