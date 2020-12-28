using System;
using System.Collections.Generic;
using System.Text;

namespace State_MaquinaDeBolinhas
{
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
}
