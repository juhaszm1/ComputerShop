using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Models.DTOs
{
    public class AddNewOsystemDto
    {
        public string name { get; set; }
        public int Version { get; set; }
    }
}
