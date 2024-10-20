using Microsoft.AspNetCore.Mvc;
using Models;
using System.Reflection;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private VehiclesRepository _vehiclesRepository;

        public VehiclesController(ILogger<VehiclesController> logger)
        {
            _vehiclesRepository = new VehiclesRepository();
            _logger = logger;
        }

        // GET: api/GetAllCars
        [HttpGet]
        public IActionResult GetAllCars()
        {
            try
            {
                RepositoryResponse<IEnumerable<Vehicle>> result = _vehiclesRepository.GetAll();
                if (result != null && result.Success)
                {
                    return Ok(result.Result);
                }
                else if (result.Ex == null)
                {
                    _logger.Log(LogLevel.Error, result.Message);
                    return Problem(result.Message);
                }
                else
                {
                    throw result.Ex;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Failed Loading Cars");
                return Problem("Failed Loading All Cars");
            }
        }

        // GET: api/GetCarsByMake
        [HttpGet("{make}")]
        public IActionResult GetCarsByMake(string make)
        {
            try
            {
                RepositoryResponse<IEnumerable<Vehicle>> result = _vehiclesRepository.GetCarsByMake(make);
                if (result != null && result.Success)
                {
                    return Ok(result.Result);
                }
                else if (result.Ex == null)
                {
                    _logger.Log(LogLevel.Error, result.Message);
                    return Problem(result.Message);
                }
                else
                {
                    throw result.Ex;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Failed Loading Cars By Given Make");
                return Problem("Failed Loading Cars By Given Make");
            }
        }

        // GET: api/GetCarsByModel
        [HttpGet("{model}")]
        public IActionResult GetCarsByModel(string model)
        {
            try
            {
                RepositoryResponse<IEnumerable<Vehicle>> result = _vehiclesRepository.GetCarsByModel(model);
                if (result != null && result.Success)
                {
                    return Ok(result.Result);
                }
                else if (result.Ex == null)
                {
                    _logger.Log(LogLevel.Error, result.Message);
                    return Problem(result.Message);
                }
                else
                {
                    throw result.Ex;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Failed Loading Cars By Given Model");
                return Problem("Failed Loading Cars By Given Model");
            }
        }

        // GET: api/GetCarsByModel
        [HttpGet("{minPrice}/{maxPrice}")]
        public IActionResult GetCarsByPrice(int minPrice, int maxPrice)
        {
            try
            {
                RepositoryResponse<IEnumerable<Vehicle>> result = _vehiclesRepository.GetCarsByPrice(minPrice, maxPrice);
                if (result != null && result.Success)
                {
                    return Ok(result.Result);
                }
                else if(result.Ex == null)
                {
                    _logger.Log(LogLevel.Error, result.Message);
                    return Problem(result.Message);
                }
                else
                {
                    throw result.Ex;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Failed Loading Cars By Given Prices");
                return Problem("Failed Loading Cars By Given Prices");
            }
        }
    }
}