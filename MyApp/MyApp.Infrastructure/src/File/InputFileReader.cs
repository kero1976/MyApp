using MyApp.Domain.src.Entities;
using MyApp.Domain.src.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.src.File
{
    public class InputFileReader
    {
        /// <summary>
        /// 入力ファイル
        /// </summary>
        public string InputFileName { get; }

        /// <summary>
        /// 入力ファイル設定情報
        /// </summary>
        public LoopEntity Config { get; }

        private RandomFileReader reader;

        private int position = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <param name="config"></param>
        public InputFileReader(string inputFileName, LoopEntity config)
        {
            InputFileName = inputFileName;
            Config = config;
        }

        public void Open()
        {
            reader = new RandomFileReader(InputFileName);
        }

        public void Close()
        {
            //reader.Close();
        }

        /// <summary>
        /// 1行のデータを取得する
        /// </summary>
        /// <returns></returns>
        public LoopEntity GetLine()
        {


            foreach(var data in Config.DataLists)
            {


            }
            return Config;
        }

    }
}
