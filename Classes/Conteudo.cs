using POO_Aula08.Interfaces; // 👈 PONTO 1: Adicionado para o arquivo reconhecer a interface

namespace POO_Aula08.Classes
{
    // [ABSTRAÇÃO]: A palavra-chave 'abstract' define que esta classe serve apenas como um "molde" ou "contrato".
    // Ela NUNCA poderá ser instanciada diretamente (ex: new Conteudo() resultará em erro).
    // 👈 PONTO 2: Adicionado ": IReproduzivel" para dizer que todo Conteúdo agora é reproduzível!
    public abstract class Conteudo : IReproduzivel
    {
        // [ENCAPSULAMENTO]: Atributos marcados como 'private'. 
        // Eles estão escondidos do mundo externo e só podem ser alterados diretamente por esta própria classe.
        private int _id;
        private string _titulo;
        private string _categoria;
        private int _anoLancamento;

        // [CONSTRUTOR]: Método especial executado no momento da criação do objeto.
        // Como a classe é abstrata, este construtor será chamado pelas classes filhas (Filme, Serie, etc.) através do 'base'.
        public Conteudo(int id, string titulo, string categoria, int anoLancamento)
        {
            _id = id;
            _titulo = titulo;
            _categoria = categoria;
            _anoLancamento = anoLancamento;
        }

        // [ENCAPSULAMENTO]: Métodos Getters e Setters (no C# usamos Propriedades).
        // Eles atuam como "porteiros", permitindo ler (get) ou gravar (set) os atributos privados de forma segura.
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // Nota: O C# aceita perfeitamente essa sua propriedade para cumprir o contrato da interface,
        // pois ela possui o 'get' que a interface exige!
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; } 
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public int AnoLancamento
        {
            get { return _anoLancamento; }
            set { _anoLancamento = value; }
        }

        // Nova propriedade: Uma lista para guardar todas as notas recebidas
        public List<double> Avaliacoes { get; private set; } = new List<double>();

        // Propriedade calculada: Retorna a média de todas as notas usando LINQ
        // Se não houver avaliações, retorna 0.
        public double MediaAvaliacoes => Avaliacoes.Any() ? Avaliacoes.Average() : 0;

        // Método para adicionar uma nova nota com validação
        public void AdicionarAvaliacao(double nota)
        {
            if (nota >= 0 && nota <= 10)
            {
                Avaliacoes.Add(nota);
            }
            else
            {
                Console.WriteLine("A nota deve estar entre 0 e 10.");
            }
        }        
        
        // [POLIMORFISMO / ABSTRAÇÃO]: Método abstrato (sem corpo).
        // Isso obriga que toda classe que herdar de 'Conteudo' implemente obrigatoriamente a sua própria versão deste método.
        public abstract void ExibirInformacoes();

        // 👈 PONTO 3: Métodos abstratos vindos da interface IReproduzivel.
        // Como 'Conteudo' é uma classe abstrata, nós repassamos essa obrigação para os filhos (Filme, Serie, Podcast).
        public abstract void Play();
        public abstract void Pause();
    }
}