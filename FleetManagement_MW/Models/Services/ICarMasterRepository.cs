using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace FleetManagement_MW.Models.Services
{
    
        public interface ICarMasterRepository
        {
            CarMaster GetCarById(long carId);
            IEnumerable<CarMaster> GetAllCars();
            void AddCar(CarMaster car);
            void UpdateCar(CarMaster car);
            void RemoveCar(long carId);
            void SaveChanges();
        }
}



