using System;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class FSM : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private List<StateFSM> states = new List<StateFSM>();
    #endregion

    #region PRIVATE_FIELDS
    private StateFSM currentState;
    #endregion

    #region PUBLIC_METHODS
    public void ChangeToNextState(string nextState)
    {
        StateFSM toState = states.Find(fsmState => fsmState.StateName == nextState);
        currentState = toState;
    }

    public StateFSM GetCurrentState()
    {
        return currentState;
    }

    public void InitFSM()
    {
        for (int i = 0; i < states.Count; i++)
        {
            if (states[i] != null)
            {
                states[i].Init(ChangeToNextState);
            }
        }

        currentState = states[0];
    }

    public void UpdateFSM()
    {
        currentState.UpdateBehaviour();
    }
    #endregion
}
