using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabManagerController : Controller
{
    private readonly LabManagerContext _context;

    public LabManagerContext(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Labs);

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if (lab == null)
        {
            return RedirectToAction("Index");
        }

        return View(lab);
    }

    public IActionResult Create([FromForm] int id, [FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        Lab identificacao = _context.Labs.Find(id);

        if (identificacao == null)
        {
            lab lab = new Lab(id, number, name, block );
            _context.Labs.Add(lab);
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

        Lab identificacao = _context.Labs.Find(id);
        _context.Labs.Remove(identificacao);

        return View();
    }

    public IActionResult Atualizar()
    {
        return View();
    }

    public IActionResult Atualizando([FromForm] int id, [FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        Lab identificacao = _context.Labs.Find(id);
        if (identificacao == null)
        {
            return View();
        }
        else
        {
            identificacao.Number = number;
            identificacao.Name = name;
            identificacao.Block = block;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}