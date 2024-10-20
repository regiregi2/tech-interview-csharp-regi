using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using Models;
using System.Net.Http.Json;
using System.Reflection;
using System.Collections.Generic;

namespace Vehicles.Api.Repositories
{
    public class VehiclesRepository
    {
        List<Vehicle> _vehicles;
        public VehiclesRepository()
        {
            using (StreamReader r = new StreamReader("Repositories/vehicles.json"))
            {
                string json = r.ReadToEnd();
                _vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
            }
        }

        public RepositoryResponse<IEnumerable<Vehicle>> GetAll()
        {
            return new RepositoryResponse<IEnumerable<Vehicle>>(_vehicles);
        }

        public RepositoryResponse<IEnumerable<Vehicle>> GetCarsByMake(string make)
        {
            try
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>(_vehicles.Where(c => c.Make == make));
            }
            catch (Exception e)
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>(e);
            }
        }

        public RepositoryResponse<IEnumerable<Vehicle>> GetCarsByModel(string model)
        {
            try
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>(_vehicles.Where(c => c.Model == model));
            }
            catch (Exception e)
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>(e);
            }
        }

        public RepositoryResponse<IEnumerable<Vehicle>> GetCarsByPrice(int minPrice = int.MinValue, int maxPrice = int.MaxValue)
        {
            if(minPrice > maxPrice)
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>("Max Price Greater Than Minimum Price");
            }

            try
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>(_vehicles.Where(c => c.Price <= maxPrice && c.Price >= minPrice));
            }
            catch (Exception e)
            {
                return new RepositoryResponse<IEnumerable<Vehicle>>(e);
            }
        }
    }
}
