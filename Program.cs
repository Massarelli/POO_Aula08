using POO_Aula08.Classes; // Importa as classes que criamos na pasta
using POO_Aula08.Interfaces; // Para enxergar a interface IReproduzivel

namespace POO_Aula08
{
    class Program
    {
        // [POLIMORFISMO / ABSTRAÇÃO]: Nossa lista é do tipo 'Conteudo' (a classe pai/abstrata).
        // Graças a isso, a mesma lista tem a capacidade de armazenar Filmes, Séries e Podcasts juntos!
        static List<Conteudo> catalogo = new List<Conteudo>();

        static void Main(string[] args)
        {
            // [CARGA INICIAL]: Método que coloca dados de teste automaticamente.
            // Para DESATIVAR a carga automática, basta colocar duas barras (//) no início da linha abaixo:
            CargaInicialDados(); 

            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("===== PLATAFORMA DE STREAMING =====");
                Console.WriteLine("1 - Cadastrar conteúdo");
                Console.WriteLine("2 - Listar conteúdos");
                Console.WriteLine("3 - Buscar conteúdo por título");
                Console.WriteLine("4 - Exibir detalhes de um conteúdo");
                Console.WriteLine("5 - Remover conteúdo");
                Console.WriteLine("6 - Avaliar um conteúdo"); // DESAFIOS EXTRA: Implementar sistema de avaliação (notas) para cada conteúdo
                Console.WriteLine("7 - Ver Ranking (Top Avaliados)"); // DESAFIOS EXTRA: Criar um ranking dos conteúdos mais bem avaliados, mostrando título e média das avaliações
                Console.WriteLine("8 - Testar Player de Mídia (Interface)"); // Player
                Console.WriteLine("9 - Sair"); 
                Console.WriteLine("===================================");
                Console.Write("Escolha uma opção: ");
                
                string opcao = Console.ReadLine() ?? ""; // Garante que 'opcao' nunca seja nula, evitando erros de comparação

                switch (opcao)
                {
                    case "1":
                        CadastrarConteudo(); 
                        break;
                    case "2":
                        ListarConteudos();
                        break;
                    case "3":
                        BuscarPorTitulo();
                        break;
                    case "4":
                        ExibirDetalhes();
                        break;
                    case "5":
                        RemoverConteudo();
                        break;
                    case "6":
                        AvaliarConteudo();
                        break;
                    case "7":
                        ExibirRanking();
                        break;
                    case "8":
                        TestarPlayerMidia();
                        break;
                    case "9":
                        executando = false;
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ==========================================
        // MÉTODOS DE AÇÃO DO SISTEMA
        // ==========================================

        static void CargaInicialDados()
        {
            catalogo.Add(new Filme(1, "Interestelar", "Ficção Científica", 2014, 169));
            catalogo.Add(new Filme(2, "Matrix", "Ficção Científica", 1999, 136));
            catalogo.Add(new Serie(3, "Dark", "Mistério", 2017, 3, 10));
            catalogo.Add(new Serie(4, "Breaking Bad", "Drama", 2008, 5, 13));
            catalogo.Add(new Podcast(5, "Hipsters Ponto Tech", "Tecnologia", 2024, "Paulo Silveira", 200));
            catalogo.Add(new Podcast(6, "Podpah", "Entretenimento", 2023, "Igão e Mítico", 450));
        }

        static void CadastrarConteudo()
        {
            Console.Clear();
            Console.WriteLine("===== CADASTRAR NOVO CONTEÚDO =====");
            Console.WriteLine("1 - Filme");
            Console.WriteLine("2 - Série");
            Console.WriteLine("3 - Podcast");
            Console.Write("Escolha o tipo de conteúdo: ");
            string tipo = Console.ReadLine() ?? "";

            if (tipo != "1" && tipo != "2" && tipo != "3")
            {
                Console.WriteLine("Opção de conteúdo inválida!");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n--- Dados Gerais ---");

            // 1. VALIDAÇÃO: ID Duplicado
            int id = 0;
            while (true)
            {
                Console.Write("Digite o ID numérico: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    // O método .Any() verifica se existe ALGUM item na lista com a condição especificada.
                    if (catalogo.Any(c => c.Id == id))
                    {
                        Console.WriteLine("Erro: Já existe um conteúdo cadastrado com este ID. Tente outro.");
                    }
                    else
                    {
                        break; // Sai do laço se o ID for válido e não existir na lista
                    }
                }
                else
                {
                    Console.WriteLine("Erro: O ID deve ser um número inteiro válido.");
                }
            }

            // 2. VALIDAÇÃO: Título Vazio
            string titulo = "";
            while (string.IsNullOrWhiteSpace(titulo))
            {
                Console.Write("Digite o título: ");
                titulo = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(titulo)) 
                    Console.WriteLine("Erro: O título não pode ficar em branco.");
            }

            // 3. VALIDAÇÃO: Categoria Vazia
            string categoria = "";
            while (string.IsNullOrWhiteSpace(categoria))
            {
                Console.Write("Digite a categoria: ");
                categoria = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(categoria)) 
                    Console.WriteLine("Erro: A categoria não pode ficar em branca.");
            }

            // 4. VALIDAÇÃO: Ano Inválido (Ex: menor que o primeiro filme da história ou maior que o ano atual)
            int ano = 0;
            int anoAtual = DateTime.Now.Year;
            while (true)
            {
                Console.Write("Digite o ano de lançamento: ");
                if (int.TryParse(Console.ReadLine(), out ano) && ano >= 1888 && ano <= anoAtual)
                {
                    break;
                }
                Console.WriteLine($"Erro: Digite um ano válido (entre 1888 e {anoAtual}).");
            }

            Console.WriteLine("\n--- Dados Específicos ---");
            
            // [POLIMORFISMO E HERANÇA]: Declaramos uma variável do tipo "pai" (Conteudo), 
            // mas a instanciação real será de uma das classes filhas dependendo da escolha.
            Conteudo? novoConteudo = null;

            if (tipo == "1") // Cadastro de Filme
            {
                // 5. VALIDAÇÃO: Duração Negativa
                int duracao = 0;
                while (true)
                {
                    Console.Write("Digite a duração (em minutos): ");
                    if (int.TryParse(Console.ReadLine(), out duracao) && duracao > 0) break;
                    
                    Console.WriteLine("Erro: A duração deve ser um número positivo maior que zero.");
                }

                // Instancia o Filme (Filho) e guarda na variável novoConteudo (Pai)
                novoConteudo = new Filme(id, titulo, categoria, ano, duracao);
            }
            else if (tipo == "2") // Cadastro de Série
            {
                int temporadas = 0;
                while (true)
                {
                    Console.Write("Digite a quantidade de temporadas: ");
                    if (int.TryParse(Console.ReadLine(), out temporadas) && temporadas > 0) break;
                    
                    Console.WriteLine("Erro: A quantidade de temporadas deve ser no mínimo 1.");
                }

                // 6. VALIDAÇÃO: Episódios menor que 1
                int episodios = 0;
                while (true)
                {
                    Console.Write("Digite a quantidade de episódios por temporada: ");
                    if (int.TryParse(Console.ReadLine(), out episodios) && episodios > 0) break;
                    
                    Console.WriteLine("Erro: A quantidade de episódios deve ser no mínimo 1.");
                }

                novoConteudo = new Serie(id, titulo, categoria, ano, temporadas, episodios);
            }
            else if (tipo == "3") // Cadastro de Podcast
            {
                string apresentador = "";
                while (string.IsNullOrWhiteSpace(apresentador))
                {
                    Console.Write("Digite o nome do apresentador: ");
                    apresentador = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(apresentador)) 
                        Console.WriteLine("Erro: O nome do apresentador não pode ficar em branco.");
                }

                int episodiosPod = 0;
                while (true)
                {
                    Console.Write("Digite a quantidade de episódios lançados: ");
                    if (int.TryParse(Console.ReadLine(), out episodiosPod) && episodiosPod > 0) break;
                    
                    Console.WriteLine("Erro: A quantidade de episódios deve ser no mínimo 1.");
                }

                novoConteudo = new Podcast(id, titulo, categoria, ano, apresentador, episodiosPod);
            }

            // Salvando na lista
            if (novoConteudo != null)
            {
                catalogo.Add(novoConteudo);
                Console.WriteLine("\nConteúdo cadastrado com sucesso!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void ListarConteudos()
        {
            Console.Clear();
            Console.WriteLine("===== CATÁLOGO DE CONTEÚDOS =====");
            
            if (catalogo.Count == 0)
            {
                Console.WriteLine("Nenhum conteúdo cadastrado.");
            }
            else
            {
                // Percorremos a lista genérica.
                foreach (Conteudo c in catalogo)
                {
                    // O método GetType().Name descobre dinamicamente qual é a classe filha (Filme, Serie ou Podcast)
                    Console.WriteLine($"ID: {c.Id} | Título: {c.Titulo} | Categoria: {c.Categoria} | Tipo: {c.GetType().Name} | Ano: {c.AnoLancamento} | Duração/Temporadas/Episódios: " + 
                        (c is Filme f ? $"{f.DuracaoMinutos} min" : 
                        c is Serie s ? $"{s.QuantidadeTemporadas} temp / {s.EpisodiosPorTemporada} ep" : 
                        c is Podcast p ? $"Apresentador: {p.NomeApresentador} / {p.QuantidadeEpisodios} ep" : "N/A"));
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        // Método auxiliar focado apenas em mostrar os dados rapidamente para o usuário.
        // Retorna 'true' se houver itens, e 'false' se o catálogo estiver vazio.
        static bool MostrarListaSimples()
        {
            if (catalogo.Count == 0)
            {
                Console.WriteLine("Nenhum conteúdo cadastrado no momento.");
                return false;
            }

            Console.WriteLine("--- Conteúdos Disponíveis ---");
            foreach (Conteudo c in catalogo)
            {
                // Mostramos o básico para ajudar na escolha
                Console.WriteLine($"ID: {c.Id} | Título: {c.Titulo} | Categoria: {c.Categoria} | Tipo: {c.GetType().Name}");
            }
            Console.WriteLine("-----------------------------\n");
            return true;
        }

        static void BuscarPorTitulo()
        {
            Console.Clear();
            Console.WriteLine("===== BUSCAR CONTEÚDO =====");
            
            // Se não tiver nada na lista, ele avisa e já encerra o método usando o 'return'
            if (!MostrarListaSimples()) 
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return; 
            }

            Console.Write("Digite o título que deseja buscar: ");
            string termo = (Console.ReadLine() ?? "").ToLower();

            var resultados = catalogo.Where(c => c.Titulo.ToLower().Contains(termo)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("\nNenhum conteúdo encontrado com esse termo.");
            }
            else
            {
                Console.WriteLine("\n--- Resultados da Busca ---");
                foreach (Conteudo c in resultados)
                {
                    Console.WriteLine($"ID: {c.Id} | Título: {c.Titulo} | Categoria: {c.Categoria} | Tipo: {c.GetType().Name} | Ano: {c.AnoLancamento}");
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void ExibirDetalhes()
        {
            Console.Clear();
            Console.WriteLine("===== EXIBIR DETALHES =====");
            
            if (!MostrarListaSimples()) 
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o ID do conteúdo que deseja ver os detalhes: ");
            
            if(int.TryParse(Console.ReadLine(), out int idBusca))
            {
                Conteudo? encontrado = catalogo.FirstOrDefault(c => c.Id == idBusca);

                if (encontrado != null)
                {
                    Console.Clear();
                    encontrado.ExibirInformacoes(); 
                }
                else
                {
                    Console.WriteLine("Conteúdo não encontrado com esse ID.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Digite um número.");
            }
            
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void RemoverConteudo()
        {
            Console.Clear();
            Console.WriteLine("===== REMOVER CONTEÚDO =====");

            if (!MostrarListaSimples()) 
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o ID do conteúdo que deseja remover: ");
            
            if(int.TryParse(Console.ReadLine(), out int idRemover))
            {
                Conteudo? encontrado = catalogo.FirstOrDefault(c => c.Id == idRemover);

                if (encontrado != null)
                {
                    catalogo.Remove(encontrado);
                    Console.WriteLine($"\nConteúdo '{encontrado.Titulo}' removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nConteúdo não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido. Digite um número.");
            }
            
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        static void AvaliarConteudo()
        {
            Console.Clear();
            Console.WriteLine("===== AVALIAR CONTEÚDO =====");

            if (!MostrarListaSimples()) 
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o ID do conteúdo que deseja avaliar: ");
            
            if(int.TryParse(Console.ReadLine(), out int idAvaliar))
            {
                Conteudo? encontrado = catalogo.FirstOrDefault(c => c.Id == idAvaliar);

                if (encontrado != null)
                {
                    Console.Write($"Digite a nota para '{encontrado.Titulo}' (0 a 10): ");
                    
                    // Usamos double.TryParse para aceitar números quebrados (ex: 8.5)
                    if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 10)
                    {
                        encontrado.AdicionarAvaliacao(nota);
                        Console.WriteLine($"\nNota {nota} registrada com sucesso para '{encontrado.Titulo}'!");
                    }
                    else
                    {
                        Console.WriteLine("\nErro: A nota deve ser um número válido entre 0 e 10.");
                    }
                }
                else
                {
                    Console.WriteLine("\nConteúdo não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido. Digite um número.");
            }
            
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void ExibirRanking()
        {
            Console.Clear();
            Console.WriteLine("===== RANKING DOS MELHORES CONTEÚDOS =====");

            // Filtramos apenas os que têm alguma avaliação (Média > 0) 
            // e ordenamos do maior para o menor (OrderByDescending)
            var ranking = catalogo.Where(c => c.MediaAvaliacoes > 0)
                                  .OrderByDescending(c => c.MediaAvaliacoes)
                                  .ToList();

            if (ranking.Count == 0)
            {
                Console.WriteLine("Ainda não há conteúdos avaliados para montar o ranking.");
            }
            else
            {
                int posicao = 1;
                foreach (Conteudo c in ranking)
                {
                    // :F1 formata a nota para 1 casa decimal. Ex: 9.5
                    Console.WriteLine($"{posicao}º Lugar | Nota: {c.MediaAvaliacoes:F1} ★ | {c.Titulo} ({c.GetType().Name})");
                    posicao++;
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void TestarPlayerMidia()
        {
            Console.Clear();
            Console.WriteLine("===== PLAYER DE MÍDIA SIMULADO =====");
            Console.WriteLine("Criando uma fila de reprodução híbrida (Músicas e Vídeos)...\n");

            // [POLIMORFISMO POR INTERFACE]: A lista é do tipo da INTERFACE.
            // Ela não quer saber se é Música ou Vídeo, contanto que ambos saibam dar Play/Pause.
            List<IReproduzivel> filaReproducao = new List<IReproduzivel>();

            // Adicionando objetos completamente diferentes na mesma lista
            filaReproducao.Add(new Musica("Bohemian Rhapsody", "Queen"));
            filaReproducao.Add(new Video("Tutorial de C# Avançado", "1080p"));
            filaReproducao.Add(new Musica("As It Was", "Harry Styles"));
            filaReproducao.Add(new Video("Trailer do Filme Interestelar", "4K"));

            // Percorrendo a fila e controlando o uso
            foreach (IReproduzivel midia in filaReproducao)
            {
                // Note que o compilador só nos deixa acessar .Play() e .Pause() 
                // porque é o que está garantido no contrato da interface.
                midia.Play();
                midia.Pause();
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("\nFila de reprodução finalizada.");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

    }
}
