using MyApp.Domain.src.ValueObjects.SettingItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.ValueObjects.SettinItems
{
    public sealed class ItemName : SettingItem
    {
        public ItemName(string value):base(value,"項目名")
        {

        }

        public override string DisplayValue()
        {
            return Name + "=\"" + Value + "\"" +  Environment.NewLine;
        }

    }
}
