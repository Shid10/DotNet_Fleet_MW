    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FleetManagement_MW.Models;
    using global::FleetManagement_MW.Models.Services;
    using Microsoft.EntityFrameworkCore;

    namespace FleetManagement_MW.Models.Repository
    {
        public class SQLCarMasterRepository : ICarMasterRepository
        {
            private readonly AppDbContext _context;

            public SQLCarMasterRepository(AppDbContext context)
            {
                _context = context;
            }

            public CarMaster GetCarById(long carId)
            {
                return _context.CarMasters
                    .Include(c => c.carType)
                    .Include(c => c.hub)
                    .FirstOrDefault(c => c.carId == carId);
            }

            public IEnumerable<CarMaster> GetAllCars()
            {
                return _context.CarMasters
                    .Include(c => c.carType)
                    .Include(c => c.hub)
                    .ToList();
            }

            public void AddCar(CarMaster car)
            {
                _context.CarMasters.Add(car);
            }

            public void UpdateCar(CarMaster car)
            {
                _context.CarMasters.Update(car);
            }

            public void RemoveCar(long carId)
            {
                var car = _context.CarMasters.Find(carId);
                if (car != null)
                {
                    _context.CarMasters.Remove(car);
                }
            }

            public void SaveChanges()
            {
                _context.SaveChanges();
            }
        }
    }


