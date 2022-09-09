using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class FSM : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private List<StateFSM> states = null;
    [SerializeField] private UnityEvent onAbruptInterrupt;
    [SerializeField] private bool isActive = false;
    #endregion

    #region PRIVATE_FIELDS
    protected List<Agent> agentsInvolved = new List<Agent>();

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

    public void InitFSM(List<Agent> agentsInvolved = null)
    {
        for (int i = 0; i < states.Count; i++)
        {
            if (states[i] != null)
            {
                states[i].Init(ChangeToNextState, agentsInvolved);
            }
        }

        currentState = states[0];

        onAbruptInterrupt.AddListener(ToggleFSM);

        isActive = false;
    }

    public void EnableFSM()
    {
        isActive = true;
    }

    public void UpdateFSM()
    {
        if (!isActive)
            return;

        currentState.UpdateBehaviour();
    }
    #endregion

    #region PRIVATE_METHODS
    private void ToggleFSM()
    {
        isActive = !isActive;
    }
    #endregion
}
