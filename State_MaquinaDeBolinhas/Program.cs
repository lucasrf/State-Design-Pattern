using System;

namespace State_MaquinaDeBolinhas
{
    class Program
    {
        static void Main(string[] args)
        {
            int response;

            var context = new Maquina(new SemCredito());

            Console.WriteLine("Bem-vindo ao teste da máquina de bolinhas, selecione e sua ação:");
            Console.WriteLine("\n1. Inserir Moeda.");
            Console.WriteLine("\n2. Ejetar Moeda");
            Console.WriteLine("\n3. Virar manivela\n\n");

            for (; ; ) //Loop infinito
            {
                response = int.Parse(Console.ReadLine()); //Converte string em int

                switch (response)
                {
                    case 1:
                        context.InserirMoeda();
                        break;
                    case 2:
                        context.EjetarMoeda();
                        break;
                    case 3:
                        context.VirarManivela();
                        break;

                }

                Console.WriteLine("Estoque: " + context.estoque);
            }
        }
    }
}
