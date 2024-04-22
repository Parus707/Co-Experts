using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.Interfaces
{
    public interface IVendorService
    {
        Task<List<Vendor>> GetAllVendorsAsync();
        Task<Vendor> GetVendorByIdAsync(Guid id);
        Task AddVendorAsync(Vendor category);
        Task UpdateVendorAsync(Vendor category);
        Task DeleteVendorAsync(Guid id);
    }
}
