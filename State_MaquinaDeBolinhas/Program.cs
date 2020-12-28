using System;

namespace State_MaquinaDeBolinhas
{
    class Maquina
    {
        // A reference to the current state of the Context.
        private State _state = new SemCredito();
        public int estoque = 2;

        public Maquina(State state)
        {
            this.TransitionTo(_state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(State state)
        {
            Console.WriteLine($"Máquina: Alterando estado para {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public void InserirMoeda()
        {
            this._state.InserirMoeda();
        }

        public void EjetarMoeda()
        {
            this._state.EjetarMoeda();
        }
        public void VirarManivela()
        {
            this._state.VirarManivela();
        }
        public void Entregar()
        {
            this._state.Entregar();
        }
    }
    abstract class State
    {
        protected Maquina _context;

        public void SetContext(Maquina context)
        {
            this._context = context;
        }

        public abstract void InserirMoeda();
        public abstract void EjetarMoeda();
        public abstract void VirarManivela();
        public abstract void Entregar();
    }
    class SemCredito : State
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("SemCredito: Moeda inserida.");
            this._context.TransitionTo(new ComCredito());
        }

        public override void EjetarMoeda()
        {
            Console.WriteLine("SemCredito: Não é possível ejetar moeda.");
        }

        public override void VirarManivela()
        {
            Console.WriteLine("SemCredito: Não é possível virar a manivela.");
        }

        public override void Entregar()
        {
            Console.WriteLine("SemCredito: Não é possível entregar.");
        }
    }
    class ComCredito : State
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("ComCredito: Não é possível inserir moeda.");
        }

        public override void EjetarMoeda()
        {
            Console.WriteLine("ComCredito: Moeda ejetada.");
            this._context.TransitionTo(new SemCredito());
        }

        public override void VirarManivela()
        {
            Console.WriteLine("ComCredito: Manivela virada.");
            if (new Random().Next(1, 10) == 1 && _context.estoque >= 2)
            {
                this._context.TransitionTo(new Vencedor());
            }
            else
            {
                this._context.TransitionTo(new Vendido());
            }
            this._context.Entregar();
        }

        public override void Entregar()
        {
            Console.WriteLine("ComCredito: Não é possível entregar.");
        }
    }
    class Esgotado : State
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("Esgotado: Não é possível inserir moeda.");
        }

        public override void EjetarMoeda()
        {
            Console.WriteLine("Esgotado: Ejetando moeda.");
            this._context.TransitionTo(new SemCredito());
        }

        public override void VirarManivela()
        {
            Console.WriteLine("Esgotado: Não é possível virar a manivela.");
        }

        public override void Entregar()
        {
            Console.WriteLine("Esgotado: Não é possível entregar.");
        }
    }
    class Vendido : State
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("Vendido: Não é possível inserir moeda.");
        }

        public override void EjetarMoeda()
        {
            Console.WriteLine("Vendido: Não é possível ejetar moeda.");
        }

        public override void VirarManivela()
        {
            Console.WriteLine("Vendido: Não é possível inserir moeda.");
        }

        public override void Entregar()
        {
            Console.WriteLine("Vendido: Bolinha entregue.");
            _context.estoque -= 1;
            if (_context.estoque > 0)
            {
                this._context.TransitionTo(new SemCredito());
            }
            else
            {
                this._context.TransitionTo(new Esgotado());
            }
        }
    }
    class Vencedor : State
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("Vencedor: Não é possível inserir moeda.");
        }

        public override void EjetarMoeda()
        {
            Console.WriteLine("Vencedor: Não é possível ejetar moeda.");
        }

        public override void VirarManivela()
        {
            Console.WriteLine("Vencedor: Não é possível inserir moeda.");
        }

        public override void Entregar()
        {
            Console.WriteLine("Vencedor: Bolinha dupla premiada entregue.");
            _context.estoque -= 2;
            if (_context.estoque > 0)
            {
                this._context.TransitionTo(new SemCredito());
            }
            else
            {
                this._context.TransitionTo(new Esgotado());
            }
        }
    }
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
