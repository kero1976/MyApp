using MyApp.Domain.src.Entities;
using MyApp.Domain.src.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyApp.Infrastructure.src.File
{
    public class ConfigReader : ILoopRepository
    {
        /// <summary>
        /// 設定ファイル
        /// </summary>
        public string FilePathName { get; }


        public ConfigReader(string filePathName)
        {
            FilePathName = filePathName;
        }


        public LoopEntity GetLoopEntity()
        {
            XDocument xDocument = XDocument.Load(FilePathName);
            XElement xElement = xDocument.Element("LOOP");
            return  new LoopEntity(xElement.Elements("DATA"));
        }
    }
}
