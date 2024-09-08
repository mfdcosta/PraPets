namespace PraPets.Models
{
    public class Endereco
    {
        private int id;         // Identificador único
        private string rua;
        private string numero;
        private string cidade;
        private string estado;
        private string cep;

        public Endereco()
        {
                
        }
        // Construtor
        public Endereco(int id, string rua, string numero, string cidade, string estado, string cep)
        {
            this.id = id;
            this.rua = rua;
            this.numero = numero;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
        }

        // Getters e Setters
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getRua()
        {
            return rua;
        }

        public void setRua(string rua)
        {
            if (string.IsNullOrEmpty(rua))
            {
                throw new Exception("O campo rua não pode ser nulo ou vazio.");
            }
            this.rua = rua;
        }

        public string getNumero()
        {
            return numero;
        }

        public void setNumero(string numero)
        {
            if (string.IsNullOrEmpty(numero))
            {
                throw new Exception("O campo número não pode ser nulo ou vazio.");
            }
            this.numero = numero;
        }

        public string getCidade()
        {
            return cidade;
        }

        public void setCidade(string cidade)
        {
            if (string.IsNullOrEmpty(cidade))
            {
                throw new Exception("O campo cidade não pode ser nulo ou vazio.");
            }
            this.cidade = cidade;
        }

        public string getEstado()
        {
            return estado;
        }

        public void setEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                throw new Exception("O campo estado não pode ser nulo ou vazio.");
            }
            this.estado = estado;
        }

        public string getCep()
        {
            return cep;
        }

        public void setCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
            {
                throw new Exception("O campo CEP não pode ser nulo ou vazio.");
            }
            this.cep = cep;
        }
    }
}
