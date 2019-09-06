using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;
using receitas.Models;
using receitas.Services;
using System.Collections.Generic;
using System;

namespace receitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        IReceitaService _service;
        public ReceitaController(IReceitaService service)
        {
            _service = service;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Receita>> FindAll()
        {
            return Ok(_service.FindAll());

        }

        [HttpPost]
        public ActionResult<Receita> Add([FromBody] Receita receita)
        {
           return Created("",_service.Add(receita));    

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            try
            {
                return Ok(_service.DeleteById(id));
            }catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Receita> FindById(int id)
        {
            return _service.findById(id);
        }
        [HttpPut]
        public ActionResult<Receita> UpdateStatus(Receita receita)
        {
            var resultado = _service.UpdateStatus(receita);
            if(resultado == null)
            {
                return NotFound(resultado);

            }else{
                return Ok(resultado);
            }
            
        }
       
    }
}