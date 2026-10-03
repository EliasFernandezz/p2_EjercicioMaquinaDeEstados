using System;
using System.Collections.Generic;

public class StateMachine
{
    /*
    una maquina de estados tiene una lista de estados y
    un estado actual
    */
    public List<State> States{get; set;}

    public State CurrentState{get; set;}

    public StateMachine(State initialState)
    {
        /*
        cuando se crea una maquina de estados, debe tener
        al menos un estado actual, por lo que se inicializa la lista de
        estados al crearla y se le agrega un estado inicial, que va a ser
        a su vez el estado actual de la maquina de estados
        */
        this.States = new List<State>();
        this.States.Add(initialState);

        this.CurrentState = this.States[0];
    }

    public void AddState(State state)
    {
        this.States.Add(state);
    }

    public bool ProcessInput(Input input)
    {
        /*
        para procesar un input, se busca obtener un nuevo estado actual
        buscando el estado siguiente del estado actual dado un input, si
        se obtiene un nuevo estado actual, se ejecuta la logica de salida
        del estado anterior (OnExit) y la logica de entrada del estado nuevo
        (OnEnter) y se retorna true, pero si no se encuentra un nuevo estado
        actual se retorna false
        */
        State newCurrentState = this.CurrentState.GetNextState(input);

        if (newCurrentState == null)
        {
            return false;
        }
        else
        {
            this.CurrentState.OnExit();
            this.CurrentState = newCurrentState;
            this.CurrentState.OnEnter();
            return true;
        }
    }

    public bool ProcessInputs(List<Input> inputs)
    {
        /*
        Con este método se busca ejecutar una secuencia, dada una lista
        de inputs, se va a ejecutar el método ProcessInput de cada uno,
        si en algún caso ocurriera de que un input no es valido para el
        estado actual en ese momento, se marca una bandera booleana que
        indica que la secuencia no fue perfecta, si la secuencia no es
        perfecta se retorna false, pero en caso de que lo sea se retorna true
        */
        bool areAllInputsValid = true;
        foreach(Input i in inputs)
        {
            bool processResult = ProcessInput(i);

            if (!processResult)
            {
                areAllInputsValid = false;
            }
        }

        if (areAllInputsValid)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}