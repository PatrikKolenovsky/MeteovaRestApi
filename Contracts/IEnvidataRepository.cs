using Entities.Models;
using MeteovaRestApi.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IEnvidataRepository : IRepositoryBase<Envidata>
    {
        PagedList<Envidata> GetEnvidata(DeviceParameters deviceParameters);
    }
}
