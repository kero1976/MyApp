using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.ValueObjects.SettingItems
{
    public sealed class Attribute : SettingItem
    {
        /// <summary>
        /// 文字
        /// </summary>
        public static readonly Attribute String = new Attribute("文字");

        /// <summary>
        /// 文字(16進数)
        /// </summary>
        public static readonly Attribute String16 = new Attribute("文字",true);


        /// <summary>
        /// 数値
        /// </summary>
        public static readonly Attribute Number = new Attribute("数値");

        public Attribute(string value, bool is16flg = false) : base(value, "属性")
        {
            Is16Flg = is16flg;
        }

        public bool Is16Flg { get; }

        public override string DisplayValue()
        {
            return Name + "=" + Value + Environment.NewLine;
        }

        protected override bool EqualsCore(SettingItem other)
        {
            if(other is Attribute){
                Attribute attr = (Attribute)other;
                if(this.Value == attr.Value && this.Is16Flg == attr.Is16Flg)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
