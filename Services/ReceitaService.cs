using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using receitas.Models;
using receitas.Repositories;

namespace receitas.Services
{
    public class ReceitaService : IReceitaService
    {
        IReceitaRepository _repository;
        public ReceitaService(IReceitaRepository  repository)
        {
            _repository = repository;
        }      
        
        public IEnumerable<Receita> FindAllTrue()
        {
            return _repository.FindAllTrue();
        }

        public IEnumerable<Receita> FindAllFalse()
        {
            return _repository.FindAllFalse();
        }

        public Receita Add(Receita receita)
        {
            return _repository.Add(receita);
        }
        public Receita DeleteById(int id)
        {
            return _repository.DeleteById(id);
           
        }
        public Receita findById(int id)
        {
            return  _repository.findById(id);
        }

        public Receita UpdateStatus(Receita receita)
        {
            return _repository.UpdateStatus(receita);
        }
        
    }
}