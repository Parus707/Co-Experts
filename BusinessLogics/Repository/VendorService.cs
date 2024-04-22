using BusinessLogics.Interfaces;
using DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.Repository
{
    public class VendorService : IVendorService
    {
        private readonly AppDBContext _context;

        public VendorService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Vendor>> GetAllVendorsAsync()
        {
            return await _context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorByIdAsync(Guid id)
        {
            return await _context.Vendors.FindAsync(id);
        }

        public async Task AddVendorAsync(Vendor Vendor)
        {
            _context.Vendors.Add(Vendor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVendorAsync(Vendor Vendor)
        {
            _context.Entry(Vendor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVendorAsync(Guid id)
        {
            var Vendor = await _context.Vendors.FindAsync(id);
            if (Vendor != null)
            {
                _context.Vendors.Remove(Vendor);
                await _context.SaveChangesAsync();
            }
        }
    }

}
