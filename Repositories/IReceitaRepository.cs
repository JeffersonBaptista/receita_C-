using System.Collections.Generic;
using receitas.Models;

namespace receitas.Repositories
{
    public interface IReceitaRepository
    {
         IEnumerable<Receita> FindAllTrue();
         IEnumerable<Receita> FindAllFalse();
         Receita Add(Receita receita);
         Receita DeleteById(int id);
         Receita findById(int ParametroId);
         Receita UpdateStatus(Receita receita);

    }
}