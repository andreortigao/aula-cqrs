using Microsoft.AspNetCore.Mvc;
using ExemploCamadas.Modelo;
using ExemploCamadas.Negocio;

namespace ExemploCamadas.Apresentacao.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public IActionResult Index()
        {
            var servico = new ClienteService();
            var clientes = servico.Listar();
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = new ClienteService();
            var cliente = servico.Ler(id.Value);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            var servico = new ClienteService();
            servico.Salvar(cliente);

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = new ClienteService();
            var cliente = servico.Ler(id.Value);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            try
            {
                var servico = new ClienteService();
                servico.Atualizar(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(cliente);
            }
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var servico = new ClienteService();
            var cliente = servico.Ler(id.Value);

            try
            {
                servico.Excluir(id.Value);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {

                return View(cliente);
            }
        }
    }
}
