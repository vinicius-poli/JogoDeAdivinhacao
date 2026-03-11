//v.2
//Requisito 1: Escolha de dificuldade
//Requisito 2: Validação tentativas repetidas
//Requisito 3: Pontuação do Jogador

using System;
using System.Reflection.Metadata.Ecma335;




//Eu quero usar a biblioteca padrão de sistema relacionada a criptografia
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        while(true == true)
        {   
            //1. Desenha a tela de Menu (dificuldade) e espera o input do usuário 
            string? dificuldadeEscolhida =  ExibirMenuDificuldade();

            // 2. Configuração do Jogo
            int[] configuracoes = ConfigurarPartida(dificuldadeEscolhida);

            int numeroMaximo = configuracoes[0];
            int tentativasMaximas = configuracoes[1];

            //3. Execução do jogo
            ExecutarPartida(numeroMaximo, tentativasMaximas);

            //4. Pergunta se o jogador vai continuar o jogo
            if (!DesejaContinuar() == true)
                break;          

        }
    }
    static string? ExibirMenuDificuldade()
    {
        Console.Clear();

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Jogo de Adivinhação");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Escolha o nível de dificuldade:");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1- Fácil (10 tentativas)");
        Console.WriteLine("2- Médio (5 tentativas)");
        Console.WriteLine("3- Difícil (3 tentativas)");
        Console.WriteLine("--------------------------------");

        Console.WriteLine("Digite sua escolha: ");
        string? dificuldade = Console.ReadLine();
        return dificuldade;
    }

    static int[] ConfigurarPartida(string? dificuldadeEscolhida)
    {
        int numeroMaximo = 0;
        int tentativasMaximas = 0;

        if (dificuldadeEscolhida == "1")
        {
            numeroMaximo = 20;
            tentativasMaximas = 10;
        }
        else if (dificuldadeEscolhida == "2")
        {
            numeroMaximo = 50;
            tentativasMaximas = 5;
        }
        else if (dificuldadeEscolhida == "3")
        {
            numeroMaximo = 100;
            tentativasMaximas = 3;
        }
        else
        {
            Console.WriteLine("Opção inválida! Tecle [ENTER] para retornar.");
            Console.ReadLine();
        }
        
        int[] configuracoes = new int[2];

        configuracoes[0] = numeroMaximo;
        configuracoes[1] = tentativasMaximas;

        return configuracoes;
    }

    static void ExecutarPartida(int numeroMaximo, int tentativasMaximas)
    {
        int[] numerosDigitados =  new int [tentativasMaximas];
        int contadorNumerosDigitados = 0;
        int pontuacao = 1000;

        int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);
        
        for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}.");
            Console.WriteLine("--------------------------------");  
            
            Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
            string? chute = Console.ReadLine();

            int numeroDigitado = Convert.ToInt32(chute);

            bool numeroEstaRepetido = false;

            for( int contadorNumeros = 0; contadorNumeros < numerosDigitados.Length; contadorNumeros++)
            {
                if (numerosDigitados[contadorNumeros] == numeroDigitado)
                {
                    numeroEstaRepetido = true;
                    break;
                }
            }

            if (numeroEstaRepetido == true)
            {
                Console.WriteLine("Você já tentou esse número! Tecle [ENTER] para retornar.");
                Console.ReadLine();
                tentativa--;
                continue;
            }

            if (contadorNumerosDigitados < numerosDigitados.Length)
            {
                numerosDigitados[contadorNumerosDigitados] = numeroDigitado;
                contadorNumerosDigitados++;
            }

            

            if (numeroDigitado == numeroAleatorio)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Parabéns, você acertou!");
                Console.WriteLine("----------------------");
                break;
            }

            else if (numeroDigitado > numeroAleatorio)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("O número digitado é maior que o número secreto!");
                Console.WriteLine("----------------------");
            }

            else
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("O número digitado é menor que o número secreto!");
                Console.WriteLine("----------------------");
            }

            int diferencaNumerica = Math.Abs(numeroAleatorio - numeroDigitado);

            if (diferencaNumerica >= 10)
            {
                pontuacao -= 100;
            }
            else if (diferencaNumerica >= 5)
            {
                pontuacao -= 50;
            }
            else
            {
                pontuacao -= 20;
            }

            Console.WriteLine("Sua pontuação é : " + pontuacao);
            Console.WriteLine("----------------------");
            Console.WriteLine("Digite ENTER para continuar...");  
            Console.ReadLine();

            if (tentativa ==  tentativasMaximas)
            {
                Console.WriteLine($"Você usou todas as suas tentativas. O número aleatório era {numeroAleatorio}.");
                Console.WriteLine("----------------------"); 
            }    
        }
    }

    static bool DesejaContinuar()
    {
        Console.Write("Deseja continuar? (S/N) ");
        string? opcaoContinuar = Console.ReadLine(); //nullabe (Pode conter nada(null))

        if (opcaoContinuar?.ToUpper() != "S") // ? => Só executa a ação ToUpper() se a variavel nao for null
        {                                     // ! => Força a execução de ToUpper() mesmo se for null
            return false;
        }
        return true;
    }        
}