using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EFSalon;
using ASPEFSalon;
using Microsoft.EntityFrameworkCore;

namespace DockerMVCTest.Controllers
{
    public class HomeController : Controller
    {
        ApplContext db;
        public HomeController(ApplContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Clients.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("{Create}")]
        public async Task<IActionResult> Create(Client client)
        {
            if (client != null)
            {
                await db.Clients.AddAsync(client);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IndexM()
        {
            return View(await db.Masters.ToListAsync());
        }
        public IActionResult CreateM()
        {
            return View();
        }

        [HttpPost("{CreateM}")]
        public async Task<IActionResult> CreateM(Master master)
        {
            if (master != null)
            {
                await db.Masters.AddAsync(master);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("IndexM");
        }
    }
}
