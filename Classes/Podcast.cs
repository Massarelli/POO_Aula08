namespace POO_Aula08.Classes
{
    // [HERANÇA]: Assim como Filme e Serie, a classe Podcast "é um" Conteudo.
    public class Podcast : Conteudo
    {
        // [ENCAPSULAMENTO]: Atributos privados e exclusivos de um podcast.
        private string nomeApresentador;
        private int quantidadeEpisodios;

        // [CONSTRUTOR]: O construtor recebe os dados gerais (enviados ao 'base') e os dados específicos.
        public Podcast(int id, string titulo, string categoria, int anoLancamento, string nomeApresentador, int quantidadeEpisodios) 
            : base(id, titulo, categoria, anoLancamento)
        {
            this.nomeApresentador = nomeApresentador;
            this.quantidadeEpisodios = quantidadeEpisodios;
        }

        // [ENCAPSULAMENTO]: Nossas propriedades garantindo o acesso seguro (Getters e Setters).
        public string NomeApresentador
        {
            get { return nomeApresentador; }
            set { nomeApresentador = value; }
        }

        public int QuantidadeEpisodios
        {
            get { return quantidadeEpisodios; }
            set { quantidadeEpisodios = value; }
        }

        // [POLIMORFISMO]: Sobrescrevemos o método abstrato garantindo a exibição adequada para este tipo de mídia.
        public override void ExibirInformacoes()
        {
            Console.WriteLine("===== PODCAST =====");
            Console.WriteLine("");
            
            // Dados herdados
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Ano: {AnoLancamento}");
            Console.WriteLine("");
            
            // Dados exclusivos
            Console.WriteLine($"Apresentador: {NomeApresentador}");
            Console.WriteLine($"Quantidade de episódios: {QuantidadeEpisodios}");
            
            Console.WriteLine("");
            Console.WriteLine("Podcast disponível em áudio.");
            Console.WriteLine("");
        }
    }
}