using Abp.Domain.Repositories;
using Assignment.Cows;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("[controller]")]
    public class CowsController : AssignmentControllerBase
    {
        private readonly IRepository<Cow, int> _cowsRepository;
        public CowsController(IRepository<Cow, int> cowsRepository)
        {
            _cowsRepository = cowsRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<int> Get(string farmId, string state, DateTime date)
        {
            return await _cowsRepository.CountAsync(c => c.FarmId == farmId && c.State == state && c.CreationTime.Date == date.Date);
        }
    }
}
