//v.2
//Requisito 1: Escolha de dificuldade
//Requisito 2: Validação tentativas repetidas
//Requisito 3: Pontuação do Jogador

using System;
using System.Data.Common;


//Eu quero usar a biblioteca padrão de sistema relacionada a criptografia
using System.Security.Cryptography;

bool deveContinuar = true;

int pontuacao = 0;

while(deveContinuar == true)
{   
    int[] numerosDigitados =  new int [100];
    int contadorNumerosDigitados = 0;

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

    int numeroMaximo;
    int tentativasMaximas;

    if (dificuldade == "1")
    {
        numeroMaximo = 20;
        tentativasMaximas = 10;
    }
    else if (dificuldade == "2")
    {
        numeroMaximo = 50;
        tentativasMaximas = 5;
    }
    else if (dificuldade == "3")
    {
        numeroMaximo = 100;
        tentativasMaximas = 3;
    }
    else
    {
        Console.WriteLine("Opção inválida! Tecle [ENTER] para retornar.");
        Console.ReadLine();
        continue;
    }

    //dinâmico
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

    Console.Write("Deseja continuar? (S/N) ");
    string? opcaoContinuar = Console.ReadLine(); //nullabe (Pode conter nada(null))

    if (opcaoContinuar?.ToUpper() != "S") // ? => Só executa a ação ToUpper() se a variavel nao for null
    {                                     // ! => Força a execução de ToUpper() mesmo se for null
        break;
    }

}



