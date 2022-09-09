using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;

public class MultyThreadMining : BehaviourFSM
{
    #region EXPOSED_FIELDS
    [SerializeField] private List<Mining> minersMining = null;

    [SerializeField] private float miningTime = 5.0f;
    [SerializeField] private float currentMiningTime = 0.0f;
    [SerializeField] private UnityEvent onMinedOre = null;
    #endregion

    public override void UpdateBehaviour()
    {
        Debug.Log("Minig gold");

        if (currentMiningTime < miningTime)
        {
            currentMiningTime += Time.deltaTime;
        }
        else
        {
            onMinedOre?.Invoke();
            endOnState?.Invoke(endStates[0]);
            currentMiningTime = 0.0f;
        }
    }
}
