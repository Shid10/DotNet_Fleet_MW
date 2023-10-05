using System;
using System.Collections.Generic;
using System.Linq;
using FleetManagement_MW.Models;
using global::FleetManagement_MW.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
   public class SQLCarTypeMasterRepository : ICarTypeMasterRepository
{
    private readonly AppDbContext _context;

    public SQLCarTypeMasterRepository(AppDbContext context)
    {
        _context = context;
    }
      
    public CarTypeMaster GetCarTypeById(long carTypeId)
    {
        return _context.CarTypeMasters
            .Include(ct => ct.hub)
            .FirstOrDefault(ct => ct.carTypeId == carTypeId);
    }

    public IEnumerable<CarTypeMaster> GetCarTypesByHubId(long hubId)
    {
        return _context.CarTypeMasters
            .Where(ct => ct.hubId == hubId)
            .ToList();
    }

    public IEnumerable<CarTypeMaster> GetAllCarTypes()
    {
        return _context.CarTypeMasters
            .Include(ct => ct.hub)
            .ToList();
    }

    public void AddCarType(CarTypeMaster carType)
    {
        _context.CarTypeMasters.Add(carType);
    }

    public void UpdateCarType(CarTypeMaster carType)
    {
        _context.CarTypeMasters.Update(carType);
    }

    public void RemoveCarType(long carTypeId)
    {
        var carType = _context.CarTypeMasters.Find(carTypeId);
        if (carType != null)
        {
            _context.CarTypeMasters.Remove(carType);
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

        
    }

}
