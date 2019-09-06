namespace receitas.Models
{
    public class Receita
    {
        public int id { get; set; }
	    public string nome { get; set; }
	    public string ingredientes { get; set; } 	
	    public string modo_de_preparar { get; set; }
        public bool status {get; set;}
        public Receita(){}

        
    }
}