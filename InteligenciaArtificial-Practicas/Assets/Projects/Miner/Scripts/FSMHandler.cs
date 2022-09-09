using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMHandler : MonoBehaviour
{
	#region EXPOSED_FIELDS
	[SerializeField] private List<FSM> fsms = new List<FSM>();
	[SerializeField] private List<Agent> allAffectedAgents = null;
    #endregion

    #region PUBLIC_METHODS
    public void Start()
	{
		if(fsms.Count > 0 && allAffectedAgents.Count > 0)
		{
			for (int i = 0; i < allAffectedAgents.Count; i++)
			{
				allAffectedAgents[i].SetFSM(fsms[0], allAffectedAgents);
            }
		}

		fsms[0].EnableFSM();
    }
	#endregion
}
