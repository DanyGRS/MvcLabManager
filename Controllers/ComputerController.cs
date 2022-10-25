using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Computers);

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound(); // RedirectToAction("Index");
        }

        return View(computer);
    }

    public IActionResult Create([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
    {
        Computer computer = new Computer(id, ram, processor);
        _context.Computers.Add(computer);
        _context.SaveChanges();

        return View("Cadastro");
    }

    public IActionResult Cadastro()
    {
        return View();
    }

     public IActionResult Delete(int id){

        Computer identificacao = _context.Computers.Find(id);
        _context.Computers.Remove(identificacao);

        return View();
    }

    public IActionResult Atualizar(int id, [FromForm] string ram, [FromForm] string processor )
    {
        Computer identificacao = _context.Computers.Find(id);
        

        return View();
    }



}