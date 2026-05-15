using Microsoft.AspNetCore.Mvc;
using Petshop.Application.Services;
using Petshop.Application.DTOs;

namespace Petshop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
    }
    
}