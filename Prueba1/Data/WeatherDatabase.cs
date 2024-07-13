using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prueba1.Models;

namespace Prueba1.Data
{
    public class WeatherDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public WeatherDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WeatherRecord>().Wait();
        }

        public Task<List<WeatherRecord>> GetWeatherRecordsAsync()
        {
            return _database.Table<WeatherRecord>().ToListAsync();
        }

        public Task<int> SaveWeatherRecordAsync(WeatherRecord weatherRecord)
        {
            if (weatherRecord.Id != 0)
            {
                return _database.UpdateAsync(weatherRecord);
            }
            else
            {
                return _database.InsertAsync(weatherRecord);
            }
        }

        public Task<int> DeleteWeatherRecordAsync(WeatherRecord record)
        {
            return _database.DeleteAsync(record);
        }

        public Task<int> UpdateWeatherRecordAsync(WeatherRecord record)
        {
            return _database.UpdateAsync(record);
        }
    }
}
