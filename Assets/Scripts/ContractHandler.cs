using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Enums;
using Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ContractHandler : MonoBehaviour
{
    public GameObject contractPrefab;
    private GameObject currentContract;
    private List<ContractAttribute> ContractAttributes;

    public float GoodMultiplier;

    public float BadMultiplier;

    public Text GoodMultiplierText;

    public Text BadMultiplierText;

    // Start is called before the first frame update
    void Start()
    {
        this.GoodMultiplierText.text = GoodMultiplier.ToString();
        this.BadMultiplierText.text = BadMultiplier.ToString();

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DrawContact()
    {
        if (currentContract == null)
        {
            this.currentContract =
                Instantiate(contractPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
            this.currentContract.transform.localPosition = new Vector3(0, 0, 0);

            SetContract(this.currentContract);
        }
    }

    private void SetContract(GameObject gameObject)
    {
        gameObject.transform.Find("Title").GetComponent<Text>().text = "New Title";

        var goodAttribute = SelectAttribute(ContractType.Good);
        gameObject.transform.Find("Accept").Find("GoodText").GetComponent<Text>().text = $"{goodAttribute.Text}, but...";
            

        var badAttribue = SelectAttribute(ContractType.Bad);
        gameObject.transform.Find("Accept").Find("BadText").GetComponent<Text>().text = badAttribue.Text;
        
        var rejectAttribue = SelectAttribute(ContractType.Reject);
        gameObject.transform.Find("Reject").Find("RejectionText").GetComponent<Text>().text = rejectAttribue.Text;

    }

    private ContractAttribute SelectAttribute(ContractType contractType)
    {
        var l = this.ContractAttributes.Where(x => x.ContractType == contractType).ToList();
        return l[Random.Range(0,l.Count)];
    }

    private void LoadData()
    {
        using (StreamReader r = new StreamReader("./Assets/Data/CardAttributes.json"))
        {
            string json = r.ReadToEnd();
            this.ContractAttributes = JsonConvert.DeserializeObject<List<ContractAttribute>>(json);
        }
    }
}