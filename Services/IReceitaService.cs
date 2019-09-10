using System.Collections.Generic;
using receitas.Models;

namespace receitas.Services
{
    public interface IReceitaService
    {
        IEnumerable<Receita> FindAllTrue();
        Receita Add(Receita receita);
        Receita DeleteById(int id);
        Receita findById(int ParametroId);
        Receita UpdateStatus(Receita receita);
    }
}