using ComputeShopApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace ComputeShopApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("computers")]
    [ApiController]

    public class ComputerController : ControllerBase
    {
        public ComputerShopDbContext context = new();
        private object osystem;

        [HttpGet("getAllComputer")]

        public object GetAllComputer()
        {
            var computers = context.Computers.ToList();
            if (computers.Count > 0)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés.", result = computers });
            }
            else
            {
                return StatusCode(404, new { message = "Üres a tábla.", result = computers });
            }
        }
     [HttpGet("getComputerById/{id}")]
        public object GetComputerById(Guid id)
        {
            var computer = context.Computers.FirstOrDefault(c => c.Id == id);
            if (computer != null)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés.", result = computer });
            }
            else
            {
                return StatusCode(404, new { message = "Nincs ilyen számítógép az adatbázisban.", result = computer });
            }

        }

        [HttpPost("addNewComputer")]
        public object AddNewComputer(AddNewComputerDto newComputer)
        {
            var computer = new Computer
            {
                Id = Guid.NewGuid(),
                Brand = newComputer.Brand,
                Type = newComputer.Type,
                Display = newComputer.Display,
                Memory = newComputer.Memory,
                CreatedTime = DateTime.Now,
                OsId = newComputer.OsId
            };
            if (computer != null)
            {
                context.Computers.Add(computer);
                context.SaveChanges();
                return StatusCode(201, new { message = "Sikeres hozzáadás.", result = computer });

            }
            else
            {
                return StatusCode(400, new { message = "Nem sikerült hozzáadni", result = computer });
            }
        }

        [HttpPut("updateComputer/{id}")]
        public object UpdateComputer(Guid id, AddNewComputerDto updatedComputer)
        {
            var computer = context.Computers.FirstOrDefault(c => c.Id == id);
            if (computer != null)
            {
                computer.Brand = updatedComputer.Brand;
                computer.Type = updatedComputer.Type;
                computer.Display = updatedComputer.Display;
                computer.Memory = updatedComputer.Memory;
                computer.OsId = updatedComputer.OsId;
                context.SaveChanges();
                return StatusCode(200, new { message = "Sikeres frissítés.", result = computer });
            }
            else
            {
                return StatusCode(404, new { message = "Nincs ilyen számítógép az adatbázisban.", result = computer });
            }
        }

        [HttpDelete("deleteComputer/{id}")]
        public object DeleteComputer([FromRoute] Guid id)
        {
            var computer = context.Computers.Find(id);


            if (computer != null)
            {
                context.Computers.Remove(computer);
                context.SaveChanges();

                return StatusCode(204);
            }

            return StatusCode(404, new { message = "nincs ilyen id" });
        }


    }
}