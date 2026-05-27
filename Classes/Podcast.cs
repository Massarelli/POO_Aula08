namespace POO_Aula08.Classes
{
    // [HERANÇA]: Assim como Filme e Serie, a classe Podcast "é um" Conteudo.
    public class Podcast : Conteudo
    {
        // [ENCAPSULAMENTO]: Atributos privados e exclusivos de um podcast.
        private string _nomeApresentador;
        private int _quantidadeEpisodios;

        // [CONSTRUTOR]: O construtor recebe os dados gerais (enviados ao 'base') e os dados específicos.
        public Podcast(int id, string titulo, string categoria, int anoLancamento, string nomeApresentador, int quantidadeEpisodios) 
            : base(id, titulo, categoria, anoLancamento)
        {
            _nomeApresentador = nomeApresentador;
            _quantidadeEpisodios = quantidadeEpisodios;
        }

        // [ENCAPSULAMENTO]: Nossas propriedades garantindo o acesso seguro (Getters e Setters).
        public string NomeApresentador
        {
            get { return _nomeApresentador; }
            set { _nomeApresentador = value; }
        }

        public int QuantidadeEpisodios
        {
            get { return _quantidadeEpisodios; }
            set { _quantidadeEpisodios = value; }
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

        public override void Play() => Console.WriteLine($"▶️ Dando play no Podcast: '{Titulo}'. Pronto para ouvir!");
        public override void Pause() => Console.WriteLine($"⏸️ Podcast '{Titulo}' pausado.");
    }
}