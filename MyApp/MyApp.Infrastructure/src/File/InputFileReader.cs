using MyApp.Domain.src.Entities;
using MyApp.Domain.src.Exceptions;
using MyApp.Domain.src.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.src.File
{
    public class InputFileReader : IReaderRepository
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

        public bool Open()
        {
            reader = new RandomFileReader(InputFileName);
            return reader.Open();
        }

        public void Close()
        {
            reader.Close();
        }

        /// <summary>
        /// 1行のデータを取得する
        /// </summary>
        /// <returns></returns>
        public LoopEntity GetLine()
        {
            reader.Save();

            foreach (var data in Config.DataLists)
            {
                data.Value = reader.ReadString(data.Size);

            }
            return Config;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
