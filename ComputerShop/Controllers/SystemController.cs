using ComputerShop.Models;
using ComputerShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Controllers
{
    [Route("osystem")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpPost]
        public object AddNewOsystem([FromBody] AddNewOsystemDto addNewOsystemDto)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                name = addNewOsystemDto.name,
                Version = addNewOsystemDto.Version,
                RegisterTime = DateTime.Now,
                UpDateTime = DateTime.Now
            };


            return Ok(osystem);
        }
    }
}
