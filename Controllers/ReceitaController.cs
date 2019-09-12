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
        public ActionResult<IEnumerable<Receita>> FindAllTrue()
        {
            return Ok(_service.FindAllTrue());

        }
        [HttpGet("false")]
        public ActionResult<IEnumerable<Receita>> FindAllFalse()
        {
            return Ok(_service.FindAllFalse());
        }

        [HttpPost]
        public ActionResult<Receita> Add([FromBody] Receita receita)
        {
           return Created("",_service.Add(receita));    

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {

            var resposta = _service.DeleteById(id);

            if( resposta != null)
            {
                return Ok(resposta);
            }else
            {
                return NotFound(resposta);
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
            var resultado = _service.findById(receita.Id);
            if(resultado == null)
            {
                return NotFound(resultado);

            }else{
                _service.UpdateStatus(receita);
                return Ok(_service.findById(receita.Id));
            }
            
        }
       
    }
}