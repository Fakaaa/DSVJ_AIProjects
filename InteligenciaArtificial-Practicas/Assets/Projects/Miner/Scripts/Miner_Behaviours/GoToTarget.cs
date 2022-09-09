using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    #region PRIVATE_FIELDS
    private float timeBetweenAgents = 2f;
    private float timer = 0f;
    #endregion

    #region OVERRIDES

    public override void UpdateBehaviour()
    {
        if(timer < timeBetweenAgents)
        {
            timer += Time.deltaTime;
        }
        else
        {
            StartCoroutine(GoTargetInTime(1f));

            timer = 0;
        }
    }

    public void DecreaseMineUses()
    {
        mineUses--;
    }
    #endregion

    #region PRIVATE_CORUTINES
    private IEnumerator GoTargetInTime(float delayPerAgent)
    {
        for (int i = 0; i < agentsInvolved.Count; i++)
        {
            Vector3 dir = (target.transform.position - agentsInvolved[i].transform.position).normalized;

            while (Vector3.Distance(target.transform.position, agentsInvolved[i].transform.position) > 1.0f)
            {
                agentsInvolved[i].transform.rotation = Quaternion.Slerp(agentsInvolved[i].transform.rotation, Quaternion.LookRotation(dir.normalized), 10f * Time.deltaTime);
                agentsInvolved[i].transform.position = Vector3.MoveTowards(agentsInvolved[i].transform.position, target.transform.position, 10.0f * Time.deltaTime);

                yield return null;
            }
            
            yield return new WaitForSeconds(delayPerAgent);

            if (!isMine)
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
    #endregion
}
