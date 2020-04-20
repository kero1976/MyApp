using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MyApp.Infrastructure.src.File;
using MyApp.Domain.src.Repositories;

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
        public void 設定ファイルと入力ファイル読み込み出力する()
        {
            var conf = new ConfigReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\設定ファイル.txt");

            IReaderRepository input = new InputFileReader("C:\\Users\\kero\\source\\repos\\MyApp\\UnitTestProject1\\テストデータ\\入力データ\\INPUT.txt",
                conf.GetLoopEntity());

            IWriterRepository writer = new OutputXMLFile("d:\\test\\sample.xml");
            writer.Open().IsTrue();
            input.Open();
            var line = input.GetLine();

            foreach(var data in line.DataLists)
            {
                Console.WriteLine(data.Value);
            }
            line.IsNotNull();

            writer.SetLine(line);
            line = input.GetLine();

            foreach (var data in line.DataLists)
            {
                Console.WriteLine(data.Value);
            }
            writer.SetLine(line);
            writer.Close();
        }


    }
}
