using MyApp.Domain.src.ValueObjects.SettinItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.ValueObjects.SettingItems
{
    public sealed　class InitValue : SettingItem
    {
        private InitValue(string value) : base(value, "初期値")
        {

        }

        public InitValue(string value, Attribute attr) : base(value, "初期値")
        {
            AttributeValue = attr;
        }

        Attribute AttributeValue { get;}
        public override string DisplayValue()
        {

            if (AttributeValue == Attribute.Number)
            {
                return Name + "=" + Value + Environment.NewLine;
            }
            else if(AttributeValue == Attribute.String)
            {
                return Name + "=\"" + Value + "\"" +  Environment.NewLine;
            }
            else
            {
                return Name + "=" + Value + Environment.NewLine;
            }

        }
    }
}
