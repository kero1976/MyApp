using MyApp.Domain.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.Repositories
{
    public interface IReaderRepository : IDisposable
    {
        bool Open();

        void Close();

        LoopEntity GetLine();
    }
}
