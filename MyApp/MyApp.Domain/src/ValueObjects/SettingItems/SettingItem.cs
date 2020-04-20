using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.ValueObjects.SettingItems
{
    public abstract class SettingItem : ValueObject<SettingItem> 
    {
        public SettingItem(string value, string name)
        {
            Value = value;
            Name = name;
        }
        public string Value { get; }
        public abstract string DisplayValue();

        protected string Name { get; }

        protected override bool EqualsCore(SettingItem other)
        {
            return this.Value == other.Value;
        }

        public static string DoubleQuote(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

    }
}
