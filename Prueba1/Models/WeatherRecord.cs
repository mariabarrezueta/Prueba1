using SQLite;

namespace Prueba1.Models
{
    public class WeatherRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}

