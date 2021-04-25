using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEventHandler : MonoBehaviour
{
    private ContractHandler _contractHandler;
    void Start()
    {
        _contractHandler = GameObject.Find("GameUi").GetComponent<ContractHandler>();
    }

    public void AcceptMessage()
    {
        _contractHandler.AcceptMessage();
    }
}
