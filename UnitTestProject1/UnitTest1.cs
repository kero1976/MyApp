
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Domain.src.Entities;
using MyApp.Domain.src.ValueObjects.SettingItems;
using MyApp.Domain.src.ValueObjects.SettinItems;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VariableEntity entity = new VariableEntity(
                new ItemName("SysLpCnt1"),
                new Attribute("数値"),
                new InitValue("1"),
                new Comment("\"Aループ\" ループカウンタ(入力側)")

                );
            System.Console.WriteLine(entity.OutputValue());
        }
    }
}
