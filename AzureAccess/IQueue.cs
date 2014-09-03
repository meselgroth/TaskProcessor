using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAccess
{
    public interface IQueue
    {
        Hashtag Dequeue();
    }
}
