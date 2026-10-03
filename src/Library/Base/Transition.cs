public class Transition
{

    /*
    las transiciones tienen un input que las dispara y el
    estado siguiente al que se llega por esa transición
    */
    public Input TriggerInput{get;set;}
    public State NextState {get;set;}

    public Transition(Input triggerInput, State nextState)
    {
        this.TriggerInput = triggerInput;
        this.NextState = nextState;
    }

    public bool IsTriggeredBy(Input input)
    {
        /*
        con este método se valida si un input que llega
        por parámetro activa una transición. Si el input
        que activa la transición (TriggerInput) coincide con el
        input que llega por parámetro, entonces esta transición
        es activada por ese input
        */
        
        if (this.TriggerInput.Name == input.Name)
        {
            return true;
        }

        return false;
    }
}