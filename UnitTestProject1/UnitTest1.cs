using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MyApp.Infrastructure.src.File;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 設定ファイル読み込み()
        {
            var conf = new ConfigReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\設定ファイル.txt");
            var loop = conf.GetLoopEntity();
            var dataList = loop.DataLists;
            dataList.Count.Is(3);
            System.Console.WriteLine(loop.ToString());
        }

        [TestMethod]
        public void 設定ファイルと入力ファイル読み込み()
        {
            var conf = new ConfigReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\設定ファイル.txt");

            var input = new InputFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt",
                conf.GetLoopEntity());

            input.Open();
            var line = input.GetLine();

            foreach(var data in line.DataLists)
            {
                Console.WriteLine(data.Value);
            }
            line.IsNotNull();
        }

        [TestMethod]
        public void intのサイズ()
        {

            long max = long.MaxValue;
            max.Is (9223372036854775807);
            long G = max / 1024 / 1024 /1024;
            G.Is(2);
        }

    }
}
