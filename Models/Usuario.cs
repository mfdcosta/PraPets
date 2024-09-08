namespace PraPets.Models
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string email;
        private Endereco endereco; // Endereço agora é uma classe
        private TipoUsuario tipo; // "Tutor" ou "Prestador"

        public Usuario()
        {
                
        }
        public Usuario(int id, string nome, string email, Endereco endereco, TipoUsuario tipo)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.endereco = endereco;
            this.tipo = tipo;
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

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public Endereco getEndereco()
        {
            return endereco;
        }

        public void setEndereco(Endereco endereco)
        {
            this.endereco = endereco;
        }

        public TipoUsuario getTipo()
        {
            return tipo;
        }

        public void setTipo(TipoUsuario tipo)
        {
            this.tipo = tipo;
        }
    }
}
