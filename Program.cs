using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer? ");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    System.Environment.Exit(0);     // Esse comando é para sair do ambiente que em que estou, no caso, ambiente de console.
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    Menu();
                    break;
            }

            static void Abrir()
            {
                Console.Clear();
                Console.WriteLine("Qual o caminho do arquivo?");
                string path = Console.ReadLine();

                using (var file = new StreamReader(path))    // using vai se encarregar de abrir o arquivo que será lido e fechar automaticamente depois. O método StreamWriter pede o caminho que o arquivo será salvo, no nosso caso, será o path.
                {
                    string text = file.ReadToEnd();     // nessa linha o arquivo será lido até o final e será atribuído a variável text.
                    Console.WriteLine(text);
                }
                Console.WriteLine();
                Console.ReadLine();
                Menu();
            }

            static void Editar()
            {
                Console.Clear();
                Console.WriteLine("Digite seu texto abaixo (ESC para sair): ");
                Console.WriteLine("------------------------");
                string text = "";

                do
                {
                    text += Console.ReadLine();
                    text += Environment.NewLine;    // estou quebrando a linha no final de cada leitura
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);   // o laço de repetição repete até que a tecla ESC seja apertada

                Salvar(text);
            }

            static void Salvar(string text)
            {
                Console.Clear();
                Console.WriteLine("Qual o caminho para salvar o arquivo? ");
                var path = Console.ReadLine();

                using (var file = new StreamWriter(path))    // using vai se encarregar de abrir o arquivo que será escrito e fechar automaticamente depois. O método StreamWriter pede o caminho que o arquivo será salvo, no nosso caso, será o path.
                {
                    file.Write(text);   // nessa linha, a variavel file recebe o que foi armazenado na string text, ou seja, é aqui que o arquivo é escrito de verdade.
                }
                Console.WriteLine($"Arquivo {path} salvo com sucesso!");
                Console.ReadLine();
                Menu();
            }
        }
    }
}