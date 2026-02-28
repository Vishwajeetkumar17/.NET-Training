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