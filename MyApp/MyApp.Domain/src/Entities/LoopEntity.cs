using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyApp.Domain.src.Entities
{
    /// <summary>
    /// Loopエンティティ
    /// </summary>
    /// Dataエンティティのリストを持つ
    public sealed class LoopEntity
    {
        public List<DataEntity> DataLists {get;}

        public LoopEntity(List<DataEntity> dataLists)
        {
            DataLists = dataLists;
        }

        public LoopEntity(IEnumerable<XElement> datas)
        {
            List<DataEntity> temp = new List<DataEntity>();
            foreach (XElement data in datas)
            {
                temp.Add(new DataEntity(data));
            }
            DataLists = temp;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach(var data in DataLists)
            {
                result.Append(data.ToString() + Environment.NewLine);
            }
            return result.ToString();
        }
    }
}
