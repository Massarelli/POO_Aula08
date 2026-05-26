namespace POO_Aula08.Classes
{
    // [ABSTRAÇÃO]: A palavra-chave 'abstract' define que esta classe serve apenas como um "molde" ou "contrato".
    // Ela NUNCA poderá ser instanciada diretamente (ex: new Conteudo() resultará em erro).
    public abstract class Conteudo
    {
        // [ENCAPSULAMENTO]: Atributos marcados como 'private'. 
        // Eles estão escondidos do mundo externo e só podem ser alterados diretamente por esta própria classe.
        private int id;
        private string titulo;
        private string categoria;
        private int anoLancamento;

        // [CONSTRUTOR]: Método especial executado no momento da criação do objeto.
        // Como a classe é abstrata, este construtor será chamado pelas classes filhas (Filme, Serie, etc.) através do 'base'.
        public Conteudo(int id, string titulo, string categoria, int anoLancamento)
        {
            this.id = id;
            this.titulo = titulo;
            this.categoria = categoria;
            this.anoLancamento = anoLancamento;
        }

        // [ENCAPSULAMENTO]: Métodos Getters e Setters (no C# usamos Propriedades).
        // Eles atuam como "porteiros", permitindo ler (get) ou gravar (set) os atributos privados de forma segura.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; } // Mais para frente, podemos colocar as validações de "título vazio" aqui!
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public int AnoLancamento
        {
            get { return anoLancamento; }
            set { anoLancamento = value; }
        }

        // [POLIMORFISMO / ABSTRAÇÃO]: Método abstrato (sem corpo).
        // Isso obriga que toda classe que herdar de 'Conteudo' implemente obrigatoriamente a sua própria versão deste método.
        public abstract void ExibirInformacoes();
    }
}