using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    #region ENUMS
    public enum MINER_STATE
    {
        IDLE,
        MINING,
        GO_STORING,
        GO_MINE
    }
    #endregion

    #region SERIALIZED_FIELDS
    [SerializeField] private Transform ore = null;
    [SerializeField] private Transform storage = null;
    [SerializeField] private float minerSpeed = 0.0f;
    #endregion

    #region PRIVATE_FIELDS
    private MINER_STATE actualState = default;

    private int actualAmountGold = 0;
    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        actualState = MINER_STATE.IDLE;

    }

    private void Updte()
    {
        switch (actualState)
        {
            case MINER_STATE.IDLE:

                break;
            case MINER_STATE.MINING:

                break;
            case MINER_STATE.GO_STORING:

                break;
            case MINER_STATE.GO_MINE:

                break;
        }
    }
    #endregion

    #region PRIVATE_METHODS
    private void GoToTarget(Vector3 position)
    {
        transform.position = Vector3.Lerp(transform.position, position, minerSpeed * Time.deltaTime);
    }

    private void MineOre()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 2, transform.forward);

        foreach (var hit in hits)
        {
            if(hit.collider.gameObject.TryGetComponent(out IMineable ore))
            {
                ore.Mine(out int gainedOre);

                actualAmountGold += gainedOre;
            }
        }
    }

    private void SwitchState(MINER_STATE state)
    {
        actualState = state;
    }
    #endregion
}
