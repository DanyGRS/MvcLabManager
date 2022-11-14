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

        if (computer == null)
        {
            return RedirectToAction("Index");
        }

        return View(computer);
    }

    public IActionResult Create([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
    {
        Computer computer = new Computer(id, ram, processor);

        if (computer == null)
        {
            _context.Computers.Add(computer);
            _context.SaveChanges();
            return View("Cadastro");
        }
        else
        {
            return View();
        }
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Delete(int id)
    {

        Computer identificacao = _context.Computers.Find(id);
        _context.Computers.Remove(identificacao);

        return View();
    }

    public IActionResult Atualizar()
    {
        return View();
    }

    public IActionResult Atualizando([FromForm] int id, [FromForm] string ram, [FromForm] string processor)
    {
        Computer identificacao = _context.Computers.Find(id);
        if (identificacao == null)
        {
            return View();
        }
        else
        {
            identificacao.Ram = ram;
            identificacao.Processor = processor;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}