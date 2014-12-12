using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infopulse.Core
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; set; }
    }
}
