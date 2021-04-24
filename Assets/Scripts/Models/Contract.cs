using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using Enums;
using Singletons;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Models
{
    public class Contract
    {
        public string Title { get; set; }
        public ContractAttribute GoodAttribute { get; set; }
        public ContractAttribute BadAttribute { get; set; }
        public ContractAttribute RejectAttribute { get; set; }

        public Contract(List<ContractAttribute> attributes)
        {
            this.Title = "New Title";
            this.GoodAttribute = SelectAttribute(ContractType.Good, attributes);
            this.BadAttribute = SelectAttribute(ContractType.Bad, attributes);
            this.RejectAttribute = SelectAttribute(ContractType.Reject, attributes);
        }

        public void SetContract(GameObject contractObject)
        {
            contractObject.transform.Find("Title").GetComponent<Text>().text = this.Title;
            contractObject.transform.Find("Accept").Find("GoodText").GetComponent<Text>().text =
                $"{GoodAttribute.Text.Replace("{0}", GoodAttribute.GetModifiedValue().ToString())}, but...";
            contractObject.transform.Find("Accept").Find("BadText").GetComponent<Text>().text =
                BadAttribute.Text.Replace("{0}", BadAttribute.GetModifiedValue().ToString());
            contractObject.transform.Find("Reject").Find("RejectionText").GetComponent<Text>().text =
                RejectAttribute.Text.Replace("{0}",
                    RejectAttribute.GetModifiedValue().ToString());
        }

        public void AcceptContract()
        {
            RunAttribute(GoodAttribute);
            RunAttribute(BadAttribute);
        }

        public void RejectContract()
        {
            RunAttribute(RejectAttribute);
        }

        private void RunAttribute(ContractAttribute attribute)
        {
            switch (attribute.AttributeType)
            {
                case AttributeType.GoodQualityPercent:
                    new GoodQualityPercent().PerformAction(attribute);
                    break;
                case AttributeType.BadQualityPercent:
                    new BadQualityPercent().PerformAction(attribute);
                    break;
                case AttributeType.Money:
                    new MoneyAmount().PerformAction(attribute);
                    break;
                case AttributeType.MoneySubtract:
                    new MoneyAmount().PerformAction(attribute, true);
                    break;
                case AttributeType.ContractTimePercentDecrease:
                    new ContractTimePercent().PerformAction(attribute, true);
                    break;
                case AttributeType.ContractTimePercentIncrease:
                    new ContractTimePercent().PerformAction(attribute);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private ContractAttribute SelectAttribute(ContractType contractType, List<ContractAttribute> attributes)
        {
            var l = attributes.Where(x => x.ContractType == contractType).ToList();
            return l[Random.Range(0, l.Count)];
        }
    }
}