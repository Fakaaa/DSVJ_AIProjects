using System;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class StateFSM
{
    #region EXPOSED_FIELDS
    [SerializeField] private string stateName = null;
    [SerializeField] private string nextState = null;
    [SerializeField] private BehaviourFSM mainBehaviour = null;
    [SerializeField] private List<BehaviourFSM> otherBehaviours = new List<BehaviourFSM>();
    #endregion

    #region PRIVATE_FIELDS
    private List<string> endStates = new List<string>();
    #endregion

    #region PROPERTIES
    public string StateName { get { return stateName; } }
    public string NextStateName { get { return nextState; } }
    #endregion

    #region CONSTRUCTOR
    public StateFSM()
    {
    }
    #endregion

    #region PUBLIC_METHODS
    public void Init(Action<string> onGoNextState, List<Agent> agentsInvolved)
    {
        string[] nextStates = nextState.Split("|");
        endStates.AddRange(nextStates);

        if (mainBehaviour != null)
        {
            mainBehaviour.SetBehaviourTargets(agentsInvolved);
            mainBehaviour.SetPosibbleEndStates(endStates);
            mainBehaviour.SetOnEndMainBehaviour(onGoNextState);
        }
    }

    public void SetOtherStateBehaviour(BehaviourFSM behaviour)
    {
        if(!otherBehaviours.Contains(behaviour))
            otherBehaviours.Add(behaviour);
    }

    public void UpdateBehaviour()
    {
        if(mainBehaviour != null)
        {
            mainBehaviour.UpdateBehaviour();
        }

        if (otherBehaviours != null)
        {
            for (int i = 0; i < otherBehaviours.Count; i++)
            {
                if (otherBehaviours[i] != null)
                {
                    otherBehaviours[i].UpdateBehaviour();
                }
            }
        }
    }
    #endregion
}
