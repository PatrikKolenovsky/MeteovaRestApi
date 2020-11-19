using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMakerRepository
    {
        List<Maker> GetMakers();
        Maker GetMakerById(int id);
        void CreateMaker(Maker maker);
        void UpdateMaker(Maker maker);
        void DeleteMaker(Maker maker);
    }
}
