using System;
using System.Collections.Generic;
using System.Text;

namespace State_MaquinaDeBolinhas
{
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
}
