using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public class MultyThreadGoDeposit : BehaviourFSM
{
    #region ENUMS
    [System.Serializable]
    public enum END_STATES_DEPOSIT
    {
        MINE_EMPTY,
        GO_TOMINE
    }
    #endregion

    #region EXPOSED_FIELDS
    [SerializeField] private List<Transform> agentsTransforms;
    [SerializeField] private Transform target;
    [SerializeField] private int mineUses = 2;
    #endregion

    #region PRIVATE_FIELDS
    private ConcurrentBag<Transform> agentsWithBehaviour = new ConcurrentBag<Transform>();
    private ParallelOptions parallelOptions = null;
    #endregion

    private void Start()
    {
        for (int i = 0; i < agentsTransforms.Count; i++)
        {
            agentsWithBehaviour.Add(agentsTransforms[i]);
        }

        parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 6 };
    }

    public override void UpdateBehaviour()
    {
        Parallel.ForEach(agentsWithBehaviour, parallelOptions, (agent) =>
        {
            ExecuteMovementOn(ref agent, target);
        });
    }

    private void ExecuteMovementOn(ref Transform agent, Transform target)
    {
        Vector3 dir = (target.transform.position - agent.position).normalized;

        if (Vector3.Distance(target.transform.position, agent.position) > 1.0f)
        {
            agent.rotation = Quaternion.Slerp(agent.rotation, Quaternion.LookRotation(dir.normalized), 10f * Time.deltaTime);
            agent.position = Vector3.MoveTowards(agent.position, target.transform.position, 10.0f * Time.deltaTime);
        }
        else
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
    }
}
