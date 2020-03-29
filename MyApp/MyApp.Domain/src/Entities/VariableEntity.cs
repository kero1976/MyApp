using MyApp.Domain.src.ValueObjects.SettingItems;
using MyApp.Domain.src.ValueObjects.SettinItems;
using System;

namespace MyApp.Domain.src.Entities
{
    /// <summary>
    /// 変数エンティティ
    /// </summary>
    /// 以下の項目を持つ
    /// ・項目名
    /// ・属性
    /// ・初期値
    /// ・コメント
    public sealed class VariableEntity
    {
        public ItemName ItemName { get; }
        public ValueObjects.SettingItems.Attribute Attribute { get; }
        public InitValue InitValue { get; }
        public Comment Comment { get; }

        public VariableEntity(
            ItemName itemName,
            ValueObjects.SettingItems.Attribute attribute,
            InitValue initValue,
            Comment comment)
        {
            ItemName = itemName;
            Attribute = attribute;
            InitValue = initValue;
            Comment = comment;
        }

        public string OutputValue()
        {
            string result =
                ItemName.DisplayValue() +
                Attribute.DisplayValue() +
                InitValue.DisplayValue() +
                Comment.DisplayValue();
            return result;
        }
    }
}
