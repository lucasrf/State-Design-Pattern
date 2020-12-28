using System;
using System.Collections.Generic;
using System.Text;

namespace State_MaquinaDeBolinhas
{
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
}
