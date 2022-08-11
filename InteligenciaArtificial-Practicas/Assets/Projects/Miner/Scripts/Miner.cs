using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] private FSM fsm;

    void Start()
    {
        fsm.InitFSM();
    }

    void Update()
    {
        fsm.UpdateFSM();
    }
}
