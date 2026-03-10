using System;

//Eu quero usar a biblioteca padrão de sistema relacionada a criptografia
using System.Security.Cryptography;

bool deveContinuar = true;

while(deveContinuar == true)
{
    Console.Clear();

    Console.WriteLine("----------------------");
    Console.WriteLine("Jogo de Adivinhação");
    Console.WriteLine("----------------------");

    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);

    Console.Write("Digite um número entre 1 e 20: ");
    string? chute = Console.ReadLine();

    int numeroDigitado = Convert.ToInt32(chute);

    if (numeroDigitado == numeroAleatorio)
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Parabéns, você acertou!");
        Console.WriteLine("----------------------");
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

    Console.Write("Deseja continuar? (S/N) ");
    string? opcaoContinuar = Console.ReadLine(); //nullabe (Pode conter nada(null))

    if (opcaoContinuar?.ToUpper() != "S") // ? => Só executa a ação ToUpper() se a variavel nao for null
    {                                     // ! => Força a execução de ToUpper() mesmo se for null
        break;
    }

}



