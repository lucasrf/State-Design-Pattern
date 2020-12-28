using System;
using System.Collections.Generic;
using System.Text;

namespace State_MaquinaDeBolinhas
{
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
}
