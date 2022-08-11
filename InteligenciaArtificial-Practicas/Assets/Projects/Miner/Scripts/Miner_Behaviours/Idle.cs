using UnityEngine;

public class Idle : BehaviourFSM
{
    #region OVERRIDE
    public override void UpdateBehaviour()
    {
        Debug.Log("Miner is idle");
    }
    #endregion
}
