using System;
using System.Collections.Generic;
using System.Text;

namespace State_MaquinaDeBolinhas
{
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
}
