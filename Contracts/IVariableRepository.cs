using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IVariableRepository : IRepositoryBase<Variable>
    {
        IEnumerable<Variable> VariableByModule(int moduleId);
    }
}
