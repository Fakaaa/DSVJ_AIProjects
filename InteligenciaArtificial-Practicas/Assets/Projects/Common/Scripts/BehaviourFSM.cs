using System;
using System.Collections.Generic;

using UnityEngine;

public abstract class BehaviourFSM : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] protected Transform mainEntity = null;
    #endregion

    #region PROTECTED_FIELDS
    protected bool hasEnded = false;
    protected List<Action> normalEndActions;

    protected List<string> endStates;
    protected Action<string> endOnState;
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

    public virtual void SetActionsOnEndOfBehaviour(params Action [] atEndBehaviour)
    {
        if(normalEndActions == null)
        {
            normalEndActions = new List<Action>();
        }

        normalEndActions.AddRange(atEndBehaviour);
    }
    #endregion
}
