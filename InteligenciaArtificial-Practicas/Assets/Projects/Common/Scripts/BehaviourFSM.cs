using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Video;

public abstract class BehaviourFSM : MonoBehaviour
{
    #region PROTECTED_FIELDS
    protected List<Agent> agentsInvolved = new List<Agent>();

    protected bool hasEnded = false;
    protected List<Action> normalEndActions;

    protected List<string> endStates;
    protected Action<string> endOnState;
    protected Action onAbruptStopBehaviou;
    #endregion

    #region PROPERTIES
    public bool HasEnded { get { return hasEnded; } }
    #endregion

    #region PUBLIC_METHODS
    public abstract void UpdateBehaviour();

    public virtual void SetPosibbleEndStates(List<string> endStates)
    {
        this.endStates = endStates;
    }

    public virtual void SetOnEndMainBehaviour(Action<string> onNextState)
    {
        endOnState = onNextState;
    }

    public virtual void SetOnAbruptStop(Action onAbruptStop)
    {
        onAbruptStopBehaviou = onAbruptStop;
    }

    public virtual void SetActionsOnEndOfBehaviour(params Action [] atEndBehaviour)
    {
        if(normalEndActions == null)
        {
            normalEndActions = new List<Action>();
        }

        normalEndActions.AddRange(atEndBehaviour);
    }

    public virtual void SetBehaviourTargets(List<Agent> agentsInvolved)
    {
        this.agentsInvolved = agentsInvolved;
    }
    #endregion
}
