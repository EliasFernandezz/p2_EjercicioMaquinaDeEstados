//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using Ucu.Poo.Fsm;
using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// El programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            Input stop = new Input("stop");
            Input play = new Input("play");
            Input pause = new Input("pause");

            State stopped = new State("stopped");
            State playing = new State("playing");
            State paused = new State("paused");

            stopped.AddTransition(play, playing);
            playing.AddTransition(stop, stopped);
            playing.AddTransition(pause, paused);
            paused.AddTransition(play, playing);
            paused.AddTransition(stop, stopped);

            StateMachine musicPlayer = new StateMachine(stopped);
            musicPlayer.AddState(playing);
            musicPlayer.AddState(paused);

            musicPlayer.ProcessInput(play);
            musicPlayer.ProcessInput(pause);
            musicPlayer.ProcessInput(stop);
            musicPlayer.ProcessInput(play);
            musicPlayer.ProcessInput(stop);
            musicPlayer.ProcessInput(pause);  
        }
    }
}
