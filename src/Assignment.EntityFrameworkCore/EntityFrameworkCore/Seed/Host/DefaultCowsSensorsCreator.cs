using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.EntityFrameworkCore.Seed.Host
{
    public class DefaultCowsSensorsCreator
    {
        private readonly AssignmentDbContext _context;

        public DefaultCowsSensorsCreator(AssignmentDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCows();
            CreateSensors();
        }

        private void CreateCows()
        {
            var cows = _context.Cows.Count();
            Random rnd = new Random();

            var farms = new string[] { "A", "B", "C" };
            var states = new string[] { "Open", "Inseminated", "Pregnant", "Dry" };

            if (cows <= 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    _context.Cows.Add(new Cows.Cow
                    {
                        FarmId = farms[rnd.Next(farms.Length)],
                        State = states[rnd.Next(states.Length)]
                    }) ;
                }
                _context.SaveChanges();
            }
        }

        private void CreateSensors()
        {
            var sensors = _context.Sensors.Count();
            Random rnd = new Random();

            var farms = new string[] { "A", "B", "C" };
            var states = new string[] { "Inventory", "Deployed", "FarmerTriage", "Returned", "Dead", "Refurbished" };

            if (sensors <= 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    _context.Sensors.Add(new Sensors.Sensor
                    {
                        FarmId = farms[rnd.Next(farms.Length)],
                        State = states[rnd.Next(states.Length)]
                    });
                }
                _context.SaveChanges();
            }
        }
    }
}
