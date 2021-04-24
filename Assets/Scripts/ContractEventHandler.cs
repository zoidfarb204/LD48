using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractEventHandler : MonoBehaviour
{
    private ContractHandler _contractHandler;
    void Start()
    {
        _contractHandler = GameObject.Find("GameUi").GetComponent<ContractHandler>();
    }
    
    public void AcceptContract()
    {
        _contractHandler.AcceptContract();
    }

    public void RejectContract()
    {
        _contractHandler.RejectContract();
    }
}
