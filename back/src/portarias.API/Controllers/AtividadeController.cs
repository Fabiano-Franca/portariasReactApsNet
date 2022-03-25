using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace portarias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Meu primeiro método get";
        }

        [HttpPost]
        public string Post()
        {
            return "Meu primeiro método post";
        }

        [HttpPut]
        public string Put()
        {
            return "Meu primeiro método put";
        }


        
        [HttpDelete]
        public string Delete()
        {
            return "Meu primeiro método delete";
        }

    }
}