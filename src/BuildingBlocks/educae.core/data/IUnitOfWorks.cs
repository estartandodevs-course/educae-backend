using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educae.core.data
{
    public interface IUnitOfWorks
    {
        Task<bool> Commit();
    }
}