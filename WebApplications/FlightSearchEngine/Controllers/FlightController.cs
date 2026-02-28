using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class FlightController : Controller
{
    private readonly DatabaseHelper _db;

    public FlightController(IConfiguration configuration)
    {
        _db = new DatabaseHelper(configuration);
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var model = new SearchViewModel();
        await PopulateDropdowns(model);
        return View(model);
    }

    // Helper method
    private async Task PopulateDropdowns(SearchViewModel model)
    {
        model.SourceList = new SelectList(await _db.GetSourcesAsync());
        model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
    }

    // POST – Flights Only
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchFlights(SearchViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns(model);
            return View("Index", model);
        }

        var results = await _db.SearchFlightsAsync(
            model.Source,
            model.Destination,
            model.NumberOfPersons
        );

        ViewBag.SearchType = "FlightOnly";
        return View("Results", results);
    }

    // POST – Flights + Hotel
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns(model);
            return View("Index", model);
        }

        var results = await _db.SearchFlightsWithHotelsAsync(
            model.Source,
            model.Destination,
            model.NumberOfPersons
        );

        ViewBag.SearchType = "FlightHotel";
        return View("Results", results);
    }
}