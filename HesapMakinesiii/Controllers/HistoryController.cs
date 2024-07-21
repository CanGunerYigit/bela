using Microsoft.AspNetCore.Mvc;
using HesapMakinesiii.Data;
using System.Linq;

public class HistoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public HistoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult History()
    {
        var historyItems = _context.CalculationHistories.ToList();
        if (historyItems == null || !historyItems.Any())
        {
            // Log veya hata mesajı ekleyebilirsiniz
            return View("Error");
        }
        return View(historyItems);
    }
}
