using System;
using System.Collections.Generic;

public class State
{
    public List<Transition> Transitions {get;set;}

    public String Name {get;set;}


    public State(String name)
    {
        /*
        al crear un estado, se inicializa una lista vacía
        de transiciones que se le van a poder agregar
        */
        this.Transitions = new List<Transition>();
        this.Name = name;
    }


    public void AddTransition(Input input, State state)
    {
        Transition newTransition = new Transition(input, state);
        this.Transitions.Add(newTransition);
    }

    public State GetNextState(Input input)
    {
        /*
        se obtiene el estado siguiente al estado actual dada
        una entrada recorriendo todas las transiciones del estado
        actual, de cada transición se verifica si es activada por ese
        input, si se encuentra una transición que cumpla esto, retorna
        el estado siguiente que tiene esa transición, pero si ninguna
        transición cumple esta condición, se retorna null
        */
        foreach(Transition t in this.Transitions)
        {
            if (t.IsTriggeredBy(input))
            {
                return t.NextState;
            }
        }
        return null;
    }

    public void OnEnter()
    {
        switch (this.Name)
        {
            case "playing":
                Console.WriteLine("se empezó a reproducir una canción");
                break;

            case "paused":
                Console.WriteLine("se pausó el reproductor");
                break;

            case "stopped":
                Console.WriteLine("se detuvo el reproductor");
                break;

            default:
                Console.WriteLine("caso default sin estado OnEnter");
                break;
        }
    }

    public void OnExit()
    {
        switch (this.Name)
        {
            case "playing":
                Console.WriteLine("se dejo de reproducir la canción");
                break;

            case "paused":
                Console.WriteLine("se despausó el reproductor");
                break;

            case "stopped":
                Console.WriteLine("el reproductor ya no esta detenido");
                break;

            default:
                Console.WriteLine("caso default sin estado OnExit");
                break;
        }
    }
}