using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Models;
using TagHelpers.Service;

namespace TagHelpers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientService _ClientService;
        public ClientesController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        => Ok(_ClientService.Get(Id));

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_ClientService.GetAll());

        [HttpPost]
        public IActionResult Create(Cliente cliente) =>
            Ok(_ClientService.Create(cliente));

        [HttpPut]
        public IActionResult Update(Cliente cliente) =>
            Ok(_ClientService.Update(cliente));
    }
}
