using Contracts;
using Entities;
using Entities.Models;
using MeteovaRestApi.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class EnvidataRepository : RepositoryBase<Envidata>, IEnvidataRepository
    {
        public EnvidataRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public PagedList<Envidata> GetEnvidata(DeviceParameters deviceParameters)
        {
            var envidata = FindAll();

            return PagedList<Envidata>.ToPagedList(envidata, deviceParameters.PageNumber, deviceParameters.PageSize);
        }
    }
}
