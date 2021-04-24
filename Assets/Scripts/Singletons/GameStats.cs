using System;
using System.Runtime.CompilerServices;
using Enums;

namespace Singletons
{
    public sealed class GameStats
    {
        private static GameStats instance = null;
        private static readonly object padlock = new object();

        public event OnChangeDelegate OnChange;

        public delegate void OnChangeDelegate(StatType type, float value);

        public float Money { get; private set; }
        public float GoodMultiplier { get; private set; }
        public float BadMultiplier { get; private set; }
        public float TimeLeftInDay { get; private set; }
        public float TimePerContract { get; private set; }
        public int Contracts { get; private set; }

        public static GameStats Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameStats();
                    }
                }

                return instance;
            }
        }

        public void ChangeValue(StatType statType, float value)
        {
            switch (statType)
            {
                case StatType.Money:
                    this.Money = value;
                    break;
                case StatType.GoodMultiplier:
                    this.GoodMultiplier = value;
                    break;
                case StatType.BadMultiplier:
                    this.BadMultiplier = value;
                    break;
                case StatType.Time:
                    this.TimeLeftInDay = value;
                    break;
                case StatType.TimePerContract:
                    this.TimePerContract = value;
                    break;
            }

            if (OnChange != null)
            {
                OnChange(statType, value);
            }
        }

        public void UpdateContract(int value)
        {
            this.Contracts = this.Contracts + value;
            if (OnChange != null)
            {
                OnChange(StatType.Contract, value);
            }
        }
    }
}