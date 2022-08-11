using System;

public class FSM
{
    private short currentState = -1;
    private short[,] relations = null;

    public FSM(short states, short flags)
    {
        relations = new short[states, flags];
    }
}
