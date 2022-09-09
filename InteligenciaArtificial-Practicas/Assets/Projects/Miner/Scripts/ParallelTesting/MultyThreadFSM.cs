using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyThreadFSM : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private FSM mainFSM = null;
    #endregion
    void Start()
    {
        //mainFSM.InitFSM();
    }

    void Update()
    {
        //mainFSM.UpdateFSM();
    }
}
