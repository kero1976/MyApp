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
        /// 数値
        /// </summary>
        public static readonly Attribute Number = new Attribute("数値");

        public Attribute(string value) : base(value, "属性")
        {

        }


    }
}
