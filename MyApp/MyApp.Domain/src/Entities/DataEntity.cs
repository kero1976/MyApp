using System.Xml.Linq;

namespace MyApp.Domain.src.Entities
{
    public sealed class DataEntity
    {
        public string Name { get; }
        public int Size { get; }

        public string Value { set; get; }

        public DataEntity(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public DataEntity(XElement element)
        {
            Name = element.Element("NAME").Value;
            Size = int.Parse(element.Element("SIZE").Value);
        }
        public override string ToString()
        {
            return $"Name:{Name},Size:{Size}";
        }

        public void DataClear()
        {
            Value = string.Empty;
        }
        public DataEntity()
        {

        }
    }
}