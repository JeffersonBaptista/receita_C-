

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
        public IEnumerable<Receita> FindAll()
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = " SELECT id, nome, ingredientes, modo_de_preparar, status FROM receita" ;
              
                dbConnection.Open();
                return dbConnection.Query<Receita>(sQuery);
            }
            
        }
        public Receita DeleteById(int ParametroId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                var receitaD = findById(ParametroId);

                string sQuery = "DELETE FROM receita WHERE id = @id";
                dbConnection.Open();

                dbConnection.Execute(sQuery, new {id = ParametroId});   

                return receitaD;
            }
        }
        public Receita findById(int ParametroId)        
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
                string sQuery = "SELECT id, nome, ingredientes, modo_de_preparar , status FROM receita WHERE id = @id"; 

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
                string sQuery = "INSERT INTO receita(nome, ingredientes, modo_de_preparar,status) VALUES(@nome, @ingredientes, @modo_de_preparar, @status)";
                
                receita.status = true;

                dbConnection.Open();

                dbConnection.Execute(sQuery, receita);   

                receita.id = dbConnection.QueryFirst<int>(sQueryS);   

                return receita;
               

            }

        }

        public Receita UpdateStatus(Receita receita)
        {
            using (IDbConnection dbConnection = new MySqlConnection(ConnectionString))
            {
            string sQuery = "UPDATE receita SET status = @status WHERE id = @id";   
            
            
            var id = receita.id;
            var existe = findById(id);   

            if(existe != null)
            {
                dbConnection.Open();

                dbConnection.Execute(sQuery, receita);
                
            }          

            return existe = findById(id);
            }

        }
  
        
    }
}