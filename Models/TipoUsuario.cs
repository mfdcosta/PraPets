namespace PraPets.Models
{
    public class TipoUsuario
    {       
        private int id;
        private string nome;

        public TipoUsuario()
        {
            
        }
        public TipoUsuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }
    }
}
