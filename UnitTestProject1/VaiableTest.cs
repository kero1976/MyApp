
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Domain.src.Entities;
using MyApp.Domain.src.ValueObjects.SettingItems;
using MyApp.Domain.src.ValueObjects.SettinItems;

namespace UnitTestProject1
{
    [TestClass]
    public class VaiableTest
    {
        [TestMethod]
        public void 全項目あり()
        {
            VariableEntity entity = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("数値"),
                new InitValue("1", new Attribute("数値")),
                new Comment("コメントです")

                );
            entity.OutputValue().Is(
                "項目名=\"ABC\"" + "\r\n" +
                "属性=数値" + "\r\n" +
                "初期値=1" + "\r\n" +
                "コメント=\"コメントです\"" + "\r\n"
                );
        }

        [TestMethod]
        public void コメントなし()
        {
            VariableEntity entity = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("数値"),
                new InitValue("1", new Attribute("数値")),
                new Comment(null)

                );
            entity.OutputValue().Is(
                "項目名=\"ABC\"" + "\r\n" +
                "属性=数値" + "\r\n" +
                "初期値=1" + "\r\n" 
                );
        }

        [TestMethod]
        public void 文字()
        {
            VariableEntity entity = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("文字"),
                new InitValue("1", new Attribute("文字")),
                new Comment(null)

                );
            entity.OutputValue().Is(
                "項目名=\"ABC\"" + "\r\n" +
                "属性=文字" + "\r\n" +
                "初期値=\"1\"" + "\r\n"
                );
        }

        [TestMethod]
        public void 文字16進数()
        {
            VariableEntity entity = new VariableEntity(
                new ItemName("ABC"),
                new Attribute("文字",true),
                new InitValue("0x1234", new Attribute("文字", true)),
                new Comment(null)

                );
            entity.OutputValue().Is(
                "項目名=\"ABC\"" + "\r\n" +
                "属性=文字" + "\r\n" +
                "初期値=0x1234" + "\r\n"
                );
        }
    }
}
