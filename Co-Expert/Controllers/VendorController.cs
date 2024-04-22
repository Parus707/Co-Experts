using BusinessLogics.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Co_Expert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _Vendorservice;

        public VendorController(IVendorService Vendorservice)
        {
            _Vendorservice = Vendorservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetAllVendors()
        {
            var Vendors = await _Vendorservice.GetAllVendorsAsync();
            return Ok(Vendors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(Guid id)
        {
            var Vendor = await _Vendorservice.GetVendorByIdAsync(id);
            if (Vendor == null)
            {
                return NotFound();
            }
            return Ok(Vendor);
        }

        [HttpPost]
        public async Task<ActionResult<Vendor>> CreateVendor(Vendor Vendor)
        {
            await _Vendorservice.AddVendorAsync(Vendor);
            return CreatedAtAction(nameof(GetVendor), new { id = Vendor.VendorId }, Vendor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(Guid id, Vendor Vendor)
        {
            if (id != Vendor.VendorId)
            {
                return BadRequest();
            }
            await _Vendorservice.UpdateVendorAsync(Vendor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(Guid id)
        {
            await _Vendorservice.DeleteVendorAsync(id);
            return NoContent();
        }
    }
}
