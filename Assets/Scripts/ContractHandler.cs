using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractHandler : MonoBehaviour
{
    public GameObject contractPrefab;
    private GameObject currentContract;

    // Start is called before the first frame update
    void Start()
    {
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
        gameObject.transform.Find("Good").Find("GoodText").GetComponent<Text>().text = "Good Text Changed";
        gameObject.transform.Find("Bad").Find("BadText").GetComponent<Text>().text = "Bad Text Changed";
    }
}