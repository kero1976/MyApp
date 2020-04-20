using MyApp.Domain.src.Entities;
using MyApp.Domain.src.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyApp.Infrastructure.src.File
{
    public class OutputXMLFile : IWriterRepository
    {
        public string OutputFilePathName { get; }

        private StreamWriter writer;


        public OutputXMLFile(string outputFilePathName)
        {
            OutputFilePathName = outputFilePathName;
        }

        public void Dispose()
        {
            Close();
        }

        public bool Open()
        {
            // ファイルが存在する場合は上書き
            try
            {
                writer = new StreamWriter(OutputFilePathName, false);
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }

        public void Close()
        {
            writer.Close();
        }

        public void SetLine(LoopEntity loopEntity)
        {
            XmlSerializer se = new XmlSerializer(typeof(LoopEntity));
            se.Serialize(writer, loopEntity);
        }
    }
}
