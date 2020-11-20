using Contracts;
using Entities;
using Entities.Models;
using MeteovaRestApi.Extensions;
using Microsoft.EntityFrameworkCore;

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
            var envidata = FindAll().AsNoTracking();

            return PagedList<Envidata>.ToPagedList(envidata, deviceParameters.PageNumber, deviceParameters.PageSize);
        }
    }
}
