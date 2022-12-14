using UnityEngine;
using UnityEngine.Events;

public class Mining : BehaviourFSM
{
    #region EXPOSED_FIELDS
    [SerializeField] private float miningTime = 5.0f;
    [SerializeField] private float currentMiningTime = 0.0f;
    [SerializeField] private UnityEvent onMinedOre = null;
    #endregion

    #region OVERRIDES
    public override void UpdateBehaviour()
    {
        if (currentMiningTime < miningTime)
        {
            currentMiningTime += Time.deltaTime;
        }
        else
        {
            Debug.Log("Minig gold");
            onMinedOre?.Invoke();
            endOnState?.Invoke(endStates[0]);
            currentMiningTime = 0.0f;
        }
    }
    #endregion
}
