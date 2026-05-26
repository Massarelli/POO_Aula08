namespace POO_Aula08.Classes
{
    // [HERANÇA]: Assim como Filme, a classe Serie também herda da classe abstrata Conteudo.
    public class Serie : Conteudo
    {
        // [ENCAPSULAMENTO]: Atributos privados específicos de uma série.
        private int quantidadeTemporadas;
        private int episodiosPorTemporada;

        // [CONSTRUTOR]: Recebemos todos os dados necessários para criar uma série.
        // Novamente, usamos o 'base' para delegar as informações comuns para a classe pai (Conteudo).
        public Serie(int id, string titulo, string categoria, int anoLancamento, int quantidadeTemporadas, int episodiosPorTemporada) 
            : base(id, titulo, categoria, anoLancamento)
        {
            this.quantidadeTemporadas = quantidadeTemporadas;
            this.episodiosPorTemporada = episodiosPorTemporada;
        }

        // [ENCAPSULAMENTO]: Propriedades (Getters e Setters) para os atributos específicos da série.
        public int QuantidadeTemporadas
        {
            get { return quantidadeTemporadas; }
            set { quantidadeTemporadas = value; }
        }

        public int EpisodiosPorTemporada
        {
            get { return episodiosPorTemporada; }
            set { episodiosPorTemporada = value; }
        }

        // [POLIMORFISMO]: Sobrescrita do método abstrato. 
        // Veja como o comportamento muda: enquanto o Filme exibe os minutos totais, a Série foca em temporadas e episódios.
        public override void ExibirInformacoes()
        {
            Console.WriteLine("===== SÉRIE =====");
            Console.WriteLine("");
            
            // Lendo as propriedades herdadas
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Ano: {AnoLancamento}");
            Console.WriteLine("");
            
            // Lendo as propriedades exclusivas da Série
            Console.WriteLine($"Temporadas: {QuantidadeTemporadas}");
            Console.WriteLine($"Episódios por temporada: {EpisodiosPorTemporada}");
            
            Console.WriteLine("");
            Console.WriteLine("Série com múltiplas temporadas.");
            Console.WriteLine("");
        }
    }
}