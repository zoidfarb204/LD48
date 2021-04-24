using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Singletons;
using UnityEngine;
using UnityEngine.UI;

public class StatHandler : MonoBehaviour
{
    
    public Text MoneyText;
    public Text GoodMultiplierText;
    public Text BadMultiplierText;
    public Text TimeText;
    public Text ContractText;
    
    private GameStats _gameStats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _gameStats = GameStats.Instance;
        _gameStats.OnChange += UpdateValues;
        
        //UpdateValues();
        _gameStats.ChangeValue(StatType.Money, 1000);
        _gameStats.ChangeValue(StatType.GoodMultiplier, 1);
        _gameStats.ChangeValue(StatType.BadMultiplier, 1);
        _gameStats.ChangeValue(StatType.Time, 1000);
        _gameStats.ChangeValue(StatType.TimePerContract, 5);
        _gameStats.UpdateContract(5);
    }

    private void UpdateValues(StatType type, float value)
    {
        switch (type)
        {
            case StatType.Money:
                this.MoneyText.text = GameStats.Instance.Money.ToString();
                break;
            case StatType.GoodMultiplier:
                this.GoodMultiplierText.text = GameStats.Instance.GoodMultiplier.ToString();
                break;
            case StatType.BadMultiplier:
                this.BadMultiplierText.text = GameStats.Instance.BadMultiplier.ToString();
                break;
            case StatType.Time:
                this.TimeText.text = GameStats.Instance.TimeLeftInDay.ToString();
                break;
            case StatType.TimePerContract:
                //TODO Add Text Element for this
                break;
            case StatType.Contract:
                this.ContractText.text = GameStats.Instance.Contracts.ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
