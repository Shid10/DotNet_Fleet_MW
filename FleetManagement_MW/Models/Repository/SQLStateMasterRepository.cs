using FleetManagement_MW.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLStateMasterRepository : IStateMasterRepository
    {
        private readonly AppDbContext _context;

        public SQLStateMasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public StateMaster GetStateById(long stateId)
        {
            return _context.StateMasters.FirstOrDefault(s => s.stateId == stateId);
        }

        public IEnumerable<StateMaster> GetAllStates()
        {
            return _context.StateMasters.ToList();
        }
    }

}

    
