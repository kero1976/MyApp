using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.Entities
{
    public sealed class AreaEntity
    {
        public List<VariableEntity> VariableEntities { get; }
        public AreaEntity(List<VariableEntity> variables)
        {
            VariableEntities = variables;
        }

        public string OutputValue()
        {
            string result = "[変数開始]" + Environment.NewLine; ;
            foreach(var item in VariableEntities){
                result += item.OutputValue();
            }
            result += "[変数終了]";
            return result;
        }

    }
}
