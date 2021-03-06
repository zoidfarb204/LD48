using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Enums;
using Models;
using Newtonsoft.Json;
using Singletons;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ContractHandler : MonoBehaviour
{
    public GameObject contractPrefab;
    public GameObject messagePrefab;
    private GameObject currentContractObject;
    private GameObject currentMessageObject;
    private Contract currentContract;
    private List<ContractAttribute> ContractAttributes;


    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DrawContact()
    {
        if (currentContractObject == null)
        {
            if (GameStats.Instance.TimeLeftInDay <= 0)
            {
                //Game Over   
                this.currentMessageObject = Instantiate(messagePrefab, new Vector3(0, 0, 0), Quaternion.identity,
                    this.transform);
                this.currentMessageObject.transform.localPosition = new Vector3(0, 0, 0);
                currentMessageObject.transform.Find("Title").GetComponent<Text>().text = "Game Over";
                currentMessageObject.transform.Find("Text").GetComponent<Text>().text =
                    $"The game is over your final score is ${GameStats.Instance.Money}";
            }
            else if (GameStats.Instance.Contracts > 0)
            {
                var timeLeft = GameStats.Instance.TimeLeftInDay -
                               (GameStats.Instance.TimePerContract * GameStats.Instance.Contracts);
                GameStats.Instance.UpdateContract(-1);
                GameStats.Instance.ChangeValue(StatType.Time, timeLeft);
                this.currentContractObject =
                    Instantiate(contractPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
                this.currentContractObject.transform.localPosition = new Vector3(0, 0, 0);

                SetContract(this.currentContractObject);
            }
            else
            {
                this.currentMessageObject = Instantiate(messagePrefab, new Vector3(0, 0, 0), Quaternion.identity,
                    this.transform);
                this.currentMessageObject.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }

    private void SetContract(GameObject gameObject)
    {
        this.currentContract = new Contract(ContractAttributes);
        this.currentContract.SetContract(gameObject);
    }

    private void LoadData()
    {
        using (StreamReader r = new StreamReader("./Assets/Data/CardAttributes.json"))
        {
            string json = r.ReadToEnd();
            this.ContractAttributes = JsonConvert.DeserializeObject<List<ContractAttribute>>(json);
        }
    }

    public void AcceptContract()
    {
        this.currentContract.AcceptContract();
        RemoveCard();
    }

    public void RejectContract()
    {
        this.currentContract.RejectContract();
        RemoveCard();
    }

    private void RemoveCard()
    {
        Destroy(this.currentContractObject);
        this.currentContract = null;
    }

    public void AcceptMessage()
    {
        Destroy(this.currentMessageObject);
        GameStats.Instance.UpdateContract(5);
        var timeLeft = GameStats.Instance.TimeLeftInDay - 100;
        GameStats.Instance.ChangeValue(StatType.Time, timeLeft);
    }
}