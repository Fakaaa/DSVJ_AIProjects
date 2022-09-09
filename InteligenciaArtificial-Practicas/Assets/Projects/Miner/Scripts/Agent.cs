using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Agent : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private FSM fsm;
    #endregion

    #region UNITY_CALLS
    void Update()
    {
        if (fsm == null)
            return;

        fsm.UpdateFSM();
    }
    #endregion

    #region PUBLIC_METHODS
    public void SetFSM(FSM fsm, List<Agent> agentsInvolved = null)
    {
        this.fsm = fsm;

        this.fsm.InitFSM(agentsInvolved);
    }
    #endregion
}
