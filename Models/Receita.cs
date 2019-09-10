namespace receitas.Models
{
    public class Receita
    {
        public int Id { get; set; }
	    public string Nome { get; set; }
	    public string Ingredientes { get; set; } 	
	    public string ModoPreparar { get; set; }
        public bool Status {get; set;}
        public Receita(){}

        
    }
}