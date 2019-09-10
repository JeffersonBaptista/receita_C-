

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using receitas.Models;

namespace receitas.Repositories
{
    
    public class ReceitaRepository : IReceitaRepository
    {
        public string ConnectionString ="Server=localhost;Port=3306;Database=receitas;Uid=jefferson;Pwd=jefferson23";
        public IEnumerable<Receita> FindAllTrue()
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = " SELECT id, nome, ingredientes, modo_de_preparar as ModoPreparar, status FROM receita WHERE status = true" ;
              
                dbConnection.Open();
                return dbConnection.Query<Receita>(sQuery);
            }
            
        }
        public Receita DeleteById(int ParametroId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                var receitaD = findById(ParametroId);
                
                if(receitaD != null)
                {
                     string sQuery = "DELETE FROM receita WHERE id = @id";
                    dbConnection.Open();

                    dbConnection.Execute(sQuery, new {id = ParametroId});  

                }
                return receitaD;
            }
        }
        public Receita findById(int ParametroId)        
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "SELECT id, nome, ingredientes, modo_de_preparar as ModoPreparar , status FROM receita WHERE id = @id"; 

                try
                {
                    dbConnection.Open();
                    return dbConnection.Query<Receita>(sQuery, new {id = ParametroId}).Last();
                }catch(Exception){
                    return null;

                }                       
            }
        }

        public Receita Add(Receita receita)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {       
                string sQueryS = "SELECT LAST_INSERT_ID()";
                string sQuery = "INSERT INTO receita(nome, ingredientes, modo_de_preparar,status) VALUES(@Nome, @Ingredientes, @ModoPreparar, @Status)";
                
                receita.Status = true;

                dbConnection.Open();

                dbConnection.Execute(sQuery, receita);   

                //receita.id = dbConnection.QueryFirst<int>(sQueryS);   

                return findById(dbConnection.QueryFirst<int>(sQueryS));
               

            }

        }

        public Receita UpdateStatus(Receita receita)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
            string sQuery = "UPDATE receita SET status = @status WHERE id = @id";   
            
            
            var id = receita.Id;
            var existe = findById(id);   

            if(existe != null)
            {
                dbConnection.Open();

                dbConnection.Execute(sQuery, receita);
                
            }          

            return existe;
            }

        }
  
        
    }
}