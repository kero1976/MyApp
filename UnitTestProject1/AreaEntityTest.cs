using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Domain.src.Entities;
using MyApp.Domain.src.ValueObjects.SettingItems;
using MyApp.Domain.src.ValueObjects.SettinItems;
using Attribute = MyApp.Domain.src.ValueObjects.SettingItems.Attribute;

namespace UnitTestProject1
{
    [TestClass]
    public class AreaEntityTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            VariableEntity entity1 = new VariableEntity(
    new ItemName("ABC"),
    new Attribute("数値"),
    new InitValue("1", new Attribute("数値")),
    new Comment("コメントです")

    );

            VariableEntity entity2 = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("数値"),
                new InitValue("1", new Attribute("数値")),
                new Comment(null)

                );

            VariableEntity entity3 = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("文字"),
                new InitValue("1", new Attribute("文字")),
                new Comment(null)

                );

            VariableEntity entity4 = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("文字", true),
                new InitValue("0x1234", new Attribute("文字", true)),
                new Comment(null)

                );
            List<VariableEntity> list = new List<VariableEntity>();
            list.Add(entity1);
            list.Add(entity2);
            list.Add(entity3);
            list.Add(entity4);
            AreaEntity obj = new AreaEntity(list);
            obj.OutputValue().Is("A");
        }
    }
}
