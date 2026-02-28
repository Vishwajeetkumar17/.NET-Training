D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Controllers\FlightController.cs
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

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Data\DatabaseHelper.cs
using System.Data;
using Microsoft.Data.SqlClient;


public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // -----------------------------
    // Get Sources (Disconnected)
    // -----------------------------
    public async Task<List<string>> GetSourcesAsync()
    {
        List<string> sources = new List<string>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetSources", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            await Task.Run(() => adapter.Fill(ds));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sources.Add(row["Source"].ToString());
            }
        }

        return sources;
    }

    // -----------------------------
    // Get Destinations (Disconnected)
    // -----------------------------
    public async Task<List<string>> GetDestinationsAsync()
    {
        List<string> destinations = new List<string>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetDestinations", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            await Task.Run(() => adapter.Fill(ds));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                destinations.Add(row["Destination"].ToString());
            }
        }

        return destinations;
    }

    // -----------------------------
    // Search Flights (Disconnected)
    // -----------------------------
    public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
    {
        List<FlightResult> list = new List<FlightResult>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_SearchFlights", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Source", source);
            cmd.Parameters.AddWithValue("@Destination", destination);
            cmd.Parameters.AddWithValue("@Persons", persons);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            await Task.Run(() => adapter.Fill(ds));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new FlightResult
                {
                    FlightId = Convert.ToInt32(row["FlightId"]),
                    FlightName = row["FlightName"].ToString(),
                    FlightType = row["FlightType"].ToString(),
                    Source = row["Source"].ToString(),
                    Destination = row["Destination"].ToString(),
                    TotalCost = Convert.ToDecimal(row["TotalCost"])
                });
            }
        }

        return list;
    }

    // -----------------------------
    // Search Flights + Hotels (Disconnected)
    // -----------------------------
    public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
    {
        List<FlightHotelResult> list = new List<FlightHotelResult>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand("sp_SearchFlightsWithHotels", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Source", source);
            cmd.Parameters.AddWithValue("@Destination", destination);
            cmd.Parameters.AddWithValue("@Persons", persons);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            await Task.Run(() => adapter.Fill(ds));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new FlightHotelResult
                {
                    FlightId = Convert.ToInt32(row["FlightId"]),
                    FlightName = row["FlightName"].ToString(),
                    Source = row["Source"].ToString(),
                    Destination = row["Destination"].ToString(),
                    HotelName = row["HotelName"].ToString(),
                    TotalCost = Convert.ToDecimal(row["TotalCost"])
                });
            }
        }

        return list;
    }
}

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Models\FlightHotelResult.cs
public class FlightHotelResult
{
    public int FlightId { get; set; }
    public string FlightName { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public string HotelName { get; set; }
    public decimal TotalCost { get; set; }
}

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Models\FlightResult.cs
public class FlightResult
{
    public int FlightId { get; set; }
    public string FlightName { get; set; }
    public string FlightType { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public decimal TotalCost { get; set; }
}

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Models\SearchViewModel.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SearchViewModel
{
    [Required]
    public string Source { get; set; }

    [Required]
    public string Destination { get; set; }

    [Required]
    [Range(1,10)]
    public int NumberOfPersons { get; set; }

    public SelectList SourceList { get; set; }
    public SelectList DestinationList { get; set; }
}

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Views\Flight\Index.cshtml
@model SearchViewModel

<form asp-controller="Flight">
    @Html.AntiForgeryToken()

    <div>
        <label>Source</label>
        <select asp-for="Source" asp-items="Model.SourceList" class="form-control"></select>
        <span asp-validation-for="Source" class="text-danger"></span>
    </div>

    <div>
        <label>Destination</label>
        <select asp-for="Destination" asp-items="Model.DestinationList" class="form-control"></select>
        <span asp-validation-for="Destination" class="text-danger"></span>
    </div>

    <div>
        <label>Number of Persons</label>
        <input asp-for="NumberOfPersons" type="number" class="form-control" />
        <span asp-validation-for="NumberOfPersons" class="text-danger"></span>
    </div>

    <br />

    <button type="submit" asp-action="SearchFlights"
            class="btn btn-success">
        Search Flights Only
    </button>

    <button type="submit" asp-action="SearchFlightsWithHotels"
            class="btn btn-warning">
        Search Flight + Hotel
    </button>
</form>

@section Scripts{
    <partial name="_ValidationScriptsPartial" />

    <script>
        document.querySelector("form").addEventListener("submit", function (e) {
            var source = document.querySelector("#Source").value;
            var destination = document.querySelector("#Destination").value;

            if (source === destination) {
                alert("Source and Destination cannot be the same.");
                e.preventDefault();
            }
        });
    </script>
}

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Views\Flight\Results.cshtml
@model IEnumerable<object>

<h3>Search Results</h3>

@if (Model == null || !Model.Any())
{
    <h4>No results found</h4>
}
else
{
    if (ViewBag.SearchType == "FlightOnly")
    {
        var flights = Model.Cast<FlightResult>();

        <table class="table table-bordered">
            <tr>
                <th>FlightId</th>
                <th>FlightName</th>
                <th>FlightType</th>
                <th>Source</th>
                <th>Destination</th>
                <th>TotalCost</th>
            </tr>

            @foreach (var item in flights)
            {
                <tr>
                    <td>@item.FlightId</td>
                    <td>@item.FlightName</td>
                    <td>@item.FlightType</td>
                    <td>@item.Source</td>
                    <td>@item.Destination</td>
                    <td>@item.TotalCost</td>
                </tr>
            }
        </table>
    }
    else
    {
        var packages = Model.Cast<FlightHotelResult>();

        <table class="table table-bordered">
            <tr>
                <th>FlightId</th>
                <th>FlightName</th>
                <th>Source</th>
                <th>Destination</th>
                <th>HotelName</th>
                <th>TotalCost</th>
            </tr>

            @foreach (var item in packages)
            {
                <tr>
                    <td>@item.FlightId</td>
                    <td>@item.FlightName</td>
                    <td>@item.Source</td>
                    <td>@item.Destination</td>
                    <td>@item.HotelName</td>
                    <td>@item.TotalCost</td>
                </tr>
            }
        </table>
    }
}

<br />
<a asp-action="Index" class="btn btn-primary">Back to Search</a>

D:\Pratham\Capgemini Training\WebApplication\FlightSearchEngine\Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Flight}/{action=Index}/{id?}");


app.Run();
