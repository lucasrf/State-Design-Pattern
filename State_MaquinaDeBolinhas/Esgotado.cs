using System;
using System.Collections.Generic;
using System.Text;

namespace State_MaquinaDeBolinhas
{
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
}
