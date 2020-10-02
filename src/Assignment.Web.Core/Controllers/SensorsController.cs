using Abp.Domain.Repositories;
using Assignment.Cows;
using Assignment.Sensors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("[controller]")]
    public class SensorsController : AssignmentControllerBase
    {
        private readonly IRepository<Sensor, int> _sensorsRepository;
        public SensorsController(IRepository<Sensor, int> sensorsRepository)
        {
            _sensorsRepository = sensorsRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<int> Get(string state, int month)
        {
            return await _sensorsRepository.CountAsync(c => c.State == state && c.CreationTime.Month == month);
        }

        [HttpGet]
        [Route("deployed")]
        public async Task<List<Output>> GetDeployedSensors()
        {
            var records = await _sensorsRepository.GetAllListAsync(s => s.State == "Deployed");

            var sensors =
                        records
                        .GroupBy(x => new { x.CreationTime.Month })
                        .Select(x => new Output
                        {
                            Month = x.Key.Month,
                            Total = x.Count()
                        })
                        .ToList();

            return sensors;
        }

        public class Output
        {
            public int Month { get; set; }
            public int Total { get; set; }
        }
    }
}
