using System.Collections.Generic;

public class State
{
    public List<Transition> Transitions {get;set;}


    public State()
    {
        /*
        al crear un estado, se inicializa una lista vacía
        de transiciones que se le van a poder agregar
        */
        this.Transitions = new List<Transition>();
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
        /*
        lógica que se ejecuta al entrar a un estado
        */

        // no aplica en maquina de estados genérica
    }

    public void OnExit()
    {
        /*
        lógica que se ejecuta al entrar a un estado
        */

        // no aplica en maquina de estados genérica
    }
}