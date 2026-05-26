namespace POO_Aula08.Classes
{
    // [HERANÇA]: O símbolo ':' indica que a classe 'Filme' herda da classe abstrata 'Conteudo'.
    // Com isso, um Filme "é um" Conteudo e automaticamente ganha Id, Titulo, Categoria e AnoLancamento.
    public class Filme : Conteudo
    {
        // [ENCAPSULAMENTO]: Atributo privado que é específico e exclusivo da classe Filme.
        private int duracaoMinutos;

        // [CONSTRUTOR]: Ao criar um Filme, precisamos passar todas as informações.
        // A palavra-chave 'base' pega os 4 primeiros parâmetros e repassa para o construtor da classe pai (Conteudo) resolver.
        public Filme(int id, string titulo, string categoria, int anoLancamento, int duracaoMinutos) 
            : base(id, titulo, categoria, anoLancamento)
        {
            this.duracaoMinutos = duracaoMinutos;
        }

        // [ENCAPSULAMENTO]: Propriedade para ler e gravar a duração de forma segura.
        public int DuracaoMinutos
        {
            get { return duracaoMinutos; }
            set { duracaoMinutos = value; } 
        }

        // [POLIMORFISMO]: A palavra-chave 'override' indica que estamos sobrescrevendo o método abstrato 
        // da classe pai, dando a ele um comportamento específico e único para a classe Filme.
        public override void ExibirInformacoes()
        {
            Console.WriteLine("===== FILME =====");
            Console.WriteLine("");
            
            // Usamos as Propriedades (com letra maiúscula) herdadas de 'Conteudo' para ler os valores.
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Ano: {AnoLancamento}");
            Console.WriteLine($"Duração: {DuracaoMinutos} minutos");
            
            Console.WriteLine("");
            Console.WriteLine("Filme disponível para assistir.");
            Console.WriteLine("");
        }
    }
}