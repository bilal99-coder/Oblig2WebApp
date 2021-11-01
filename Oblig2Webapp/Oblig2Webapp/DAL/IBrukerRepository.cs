using Oblig2Webapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2Webapp.DAL
{
    public interface IBrukerRepository
    {
      
        Task<bool> LoggInn(Bruker bruker);
        Task<List<Reiser>> hentAlleReiser();
        Task<bool> Slett(int id);
        Task<Reise> HentEn(int id);
    }
}
