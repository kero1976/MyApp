using MyApp.Domain.src.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.src.File
{
    public class RandomFileReader : IDisposable
    {
        /// <summary>
        /// 読み込むファイルパス名
        /// </summary>
        public string FilePathName { get; }

        private long position;

        private long savePosition;

        /// <summary>
        /// 読み込み位置。先頭からの絶対位置
        /// </summary>
        public long Position
        {
            get { return position; }
            set { 
                position = value;
                fs.Seek(Position, SeekOrigin.Begin);
            }
        }

        ~RandomFileReader()
        {
            Dispose();
        }

        /// <summary>
        /// FileStream
        /// </summary>
        private FileStream fs;

        public RandomFileReader(string filePathName)
        {
            FilePathName = filePathName;
        }
        public void Dispose()
        {
            fs.Close();
        }

        public void Close()
        {
            Dispose();
        }

        public bool Open()
        {
            if (System.IO.File.Exists(FilePathName))
            {
                return ReTryOpen(3);
            }
            return false;
        }

        private bool ReTryOpen(int i)
        {
            System.Console.WriteLine($"カウント：{i}");
            // 排他で開く。読み込みしかしないが、他プロセスからの読み込みも禁止する
            try
            {
                fs = new FileStream(FilePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                return true;
            }
            catch (Exception e)
            {
                if(i > 0)
                {
                    System.Threading.Thread.Sleep(500);
                    return ReTryOpen(--i);
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// ストリームからバイトのブロックを読み取り、バッファーに書き込む
        /// </summary>
        /// <param name="buffer">読み込んだデータを格納するバッファ</param>
        /// <param name="count">読み取る最大バイト数</param>
        /// <returns>バッファーに読み取られた合計バイト数。要求しただけのバイト数が読み取れなかった場合は、
        /// 要求バイト数より小さくなることがある</returns>
        public int Read(byte[] buffer, int count)
        {
            var result = fs.Read(buffer, 0, count);
            if (result < count)
            {
                throw new DataEndException();
            }
            Position += count;
            return result;
        }

        public string ReadString(int count)
        {
            byte[] buffer = new byte[count];
            var result = Read(buffer, count);

            return System.Text.Encoding.UTF8.GetString(buffer, 0, count);
        }

        public void Save()
        {
            savePosition = fs.Position;
        }


        public void RollBack()
        {
            Position = savePosition;
        }

    }
}
