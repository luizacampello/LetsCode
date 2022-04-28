using System;
using System.Collections.Generic;

namespace exercicioNumerosPrimos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //aplicação que receba inteiros e faça operações com eles

            List<int> numerosInteiros = new List<int>();
            bool primeNumber = false;

            do
            {
                Console.WriteLine("Digite um número inteiro:");
                string inputUsuario = Console.ReadLine();
                int numeroInput;

                if (!int.TryParse(inputUsuario, out numeroInput))
                {
                    Console.WriteLine($"O valor inserido - {inputUsuario} - não é um número inteiro. Tente novamente.");
                    continue;
                }

                if (numeroInput <= 1)
                {
                    numerosInteiros.Add(numeroInput);
                }
                else if (numeroInput == 2 || numeroInput == 3)
                {
                    primeNumber = true;
                    numerosInteiros.Add(numeroInput);
                    Console.WriteLine("Parabéns! Você encontrou um número primo!");

                }
                else if (numeroInput % 2 == 0)
                {
                    numerosInteiros.Add(numeroInput);
                }
                else
                {
                    primeNumber = true;
                    for (int i = 3; i * i < numeroInput; i += 2)
                    {
                        if (numeroInput % i == 0)
                        {
                            primeNumber = false;
                            numerosInteiros.Add(numeroInput);
                            break;
                        }
                    }
                    if (primeNumber)
                    {
                        numerosInteiros.Add(numeroInput);
                        Console.WriteLine("Parabéns! Você encontrou um número primo!");
                    }


                }
            }
            while (!primeNumber);

            int evenNumbers = 0;
            int oddNumbers = 0;
            int sumListNumbers = 0;
            int higherNumber = numerosInteiros[0];
            int smallestNumber = numerosInteiros[0];

            foreach (int num in numerosInteiros)
            {
                sumListNumbers += num;

                if (num % 2 == 0)
                {
                    evenNumbers++;
                }
                else
                {
                    oddNumbers++;
                }

                if (num > higherNumber)
                {
                    higherNumber = num;
                }

                if (num < smallestNumber)
                {
                    smallestNumber = num;
                }

            }
            Console.WriteLine($"Contagem de Números Pares: {evenNumbers}");
            Console.WriteLine($"Contagem de Números Impares: {oddNumbers}");
            Console.WriteLine($"Soma dos valores inseridos: {sumListNumbers}");
            Console.WriteLine($"Maior número inserido: {higherNumber}");
            Console.WriteLine($"Menor número inserido: {smallestNumber}");

            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < (numerosInteiros.Count / 3); i++)
            {
                int random_number = new Random().Next(smallestNumber, higherNumber);
                randomNumbers.Add(random_number);
            }

            List<int> duplicateNumbers = new List<int>();
            foreach (int num in numerosInteiros)
            {
                foreach (int randomNum in randomNumbers)
                {
                    if (num == randomNum)
                    {
                        duplicateNumbers.Add(num);
                    }
                }
            }

            if (numerosInteiros.Count >= 3)
            {

                if (duplicateNumbers.Count > 0)
                {
                    duplicateNumbers.Sort();
                    Console.WriteLine($"Existe(m) {duplicateNumbers.Count} número(s) duplicado(s).");
                    Console.WriteLine($"O(s) número(s) {String.Join(", ", duplicateNumbers)} da lista randômica estão presentes no input do usuário.");
                }

            }

            if (duplicateNumbers.Count > 0)
            {
                foreach (int duplicate in duplicateNumbers)
                {
                    numerosInteiros.Remove(duplicate);
                }
                Console.WriteLine($"Retirando números randômicos encontrados, a sua lista de input agora é: {String.Join(", ", numerosInteiros)}.");
            }
            else
            {
                Console.WriteLine($"Não foram encontrados números randômicos na lista de input({String.Join(", ", numerosInteiros)}).");
            }
        }
    }
}
