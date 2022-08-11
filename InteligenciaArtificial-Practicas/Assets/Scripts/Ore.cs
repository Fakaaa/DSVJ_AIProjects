using System;
using UnityEngine;

public class Ore : MonoBehaviour, IMineable
{
    #region EXPOSED_FIELDS
    [SerializeField] private int sizeMena = 10;
    [SerializeField] private float minAmountPerAttack = 1;
    [SerializeField] private float maxAmountPerAttack = 4;
    #endregion

    #region ACTIONS
    public Action onMineExpire = null;
    #endregion

    #region INTERFACES
    public void Mine(out int amountGained)
    {
        amountGained = (int)UnityEngine.Random.Range(minAmountPerAttack, maxAmountPerAttack);

        if(sizeMena > amountGained)
        {
            sizeMena -= amountGained;
        }
        else
        {
            sizeMena = 0;
            onMineExpire?.Invoke();
        }
    }
    #endregion
}
