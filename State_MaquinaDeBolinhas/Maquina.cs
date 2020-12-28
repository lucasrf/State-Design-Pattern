using System;
using System.Collections.Generic;
using System.Text;

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
}
