using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Infrastructure.src.File;

namespace UnitTestProject1
{
    [TestClass]
    public class RandomReaderTest
    {
        [TestMethod]
        public void ファイル読み込み正常系()
        {
            RandomFileReader reader = new RandomFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt");
            reader.Open().IsTrue();
            reader.Position = 5;
            reader.ReadString(3).Is("123");
            reader.Save();
            reader.ReadString(2).Is("FG");
            reader.ReadString(2).Is("HI");
            reader.RollBack();
            reader.ReadString(2).Is("FG");
            reader.Position = 1;
            reader.ReadString(3).Is("BCD");
            reader.Close();
        }

        [TestMethod]
        public void 二重オープン()
        {
            RandomFileReader reader = new RandomFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt");
            reader.Open().IsTrue();
            RandomFileReader reader2 = new RandomFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt");
            reader2.Open().IsFalse();
            reader.Close();
        }

        [TestMethod]
        public void オープンクローズオープン()
        {
            RandomFileReader reader = new RandomFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt");
            reader.Open().IsTrue();
            reader.Close();
            RandomFileReader reader2 = new RandomFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt");
            reader2.Open().IsTrue();
            reader2.Close();
        }
    }
}
