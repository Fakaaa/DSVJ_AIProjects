using UnityEngine;

public class GoToTarget : BehaviourFSM
{
    #region ENUMS
    [System.Serializable]
    public enum END_STATES_DEPOSIT
    {
        MINE_EMPTY,
        GO_TOMINE
    }
    public enum END_STATES_MINE
    {
        GO_TODEPOSIT
    }
    #endregion

    #region EXPOSED_FIELDS
    [SerializeField] private Transform target;
    [SerializeField] private int mineUses = 2;
    [SerializeField] private bool isMine = false;
    #endregion

    #region OVERRIDES
    public override void UpdateBehaviour()
    {
        Vector3 dir = (target.transform.position - mainEntity.position).normalized;

        if (Vector3.Distance(target.transform.position, mainEntity.position) > 1.0f)
        {
            mainEntity.rotation = Quaternion.Slerp(mainEntity.rotation, Quaternion.LookRotation(dir.normalized), 10f * Time.deltaTime);
            mainEntity.position = Vector3.MoveTowards(mainEntity.position, target.transform.position, 10.0f * Time.deltaTime);
        }
        else
        {
            if(!isMine)
            {
                if (mineUses <= 0)
                {
                    endOnState?.Invoke(endStates[(int)END_STATES_DEPOSIT.MINE_EMPTY]);
                }
                else
                {
                    endOnState?.Invoke(endStates[(int)END_STATES_DEPOSIT.GO_TOMINE]);
                }
            }
            else
            {
                endOnState?.Invoke(endStates[(int)END_STATES_MINE.GO_TODEPOSIT]);
            }
        }
    }

    public void DecreaseMineUses()
    {
        mineUses--;
    }
    #endregion
}
