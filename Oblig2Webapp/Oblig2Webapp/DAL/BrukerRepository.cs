using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oblig2Webapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Oblig2Webapp.DAL.BrukerContext;

namespace Oblig2Webapp.DAL
{
    public class BrukerRepository : IBrukerRepository
    {
        private readonly BrukerContext _db;
        private readonly ILogger<BrukerController> _log;
        public BrukerRepository(BrukerContext db, ILogger<BrukerController> log)
        {
            _db = db;
            _log = log;
        }
        public static byte[] LagHash(string passord, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: passord,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 32);
        }
        public static byte[] LagSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }


        public async Task<bool> LoggInn(Bruker bruker)
        {
            try
            {

                Brukere funnetBruker = await _db.Brukere.FirstOrDefaultAsync(b => b.Brukernavn == bruker.Brukernavn);

                if (funnetBruker != null)
                {
                    byte[] hash = LagHash(bruker.Passord, funnetBruker.Salt);
                    bool ok = hash.SequenceEqual(funnetBruker.Passord);
                    if (ok)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
        /*
        public async Task<List<Havner>> hentAlleReiser() 
        {
            try
            {
                List<Havner> alleHavner = await _db.Havner.ToListAsync();
            /*
            List<Havner> alleHavner_Reiser1 = new List<Havner>();
            List<ankomstHavner> ankomstHavners = new List<ankomstHavner>();
            ankomstHavners.Add(new ankomstHavner { HavnId = 2, HavnNavn = "porto", pris = 1000 });
            alleHavner_Reiser1.Add(new Havner { HavnId = 1, HavnNavn = "Oslo", AnkomstHavner = ankomstHavners });
            //return Ok(alleHavner_Reiser);
            
                return alleHavner; 
            }
            catch
            {
                return null;
            }

        }*/

        public async Task<List<Reiser>> hentAlleReiser()
        {
            try
            {
                List<Reiser> alleReiser = await _db.Reiser.ToListAsync();
                /*
                List<Havner> alleHavner_Reiser1 = new List<Havner>();
                List<ankomstHavner> ankomstHavners = new List<ankomstHavner>();
                ankomstHavners.Add(new ankomstHavner { HavnId = 2, HavnNavn = "porto", pris = 1000 });
                alleHavner_Reiser1.Add(new Havner { HavnId = 1, HavnNavn = "Oslo", AnkomstHavner = ankomstHavners });
                //return Ok(alleHavner_Reiser);
                */
                return alleReiser;
            }
            catch
            {
                return null;
            }

        }



        public async Task<bool> Slett(int id)
        {
            try
            {

                Reiser enDBReise = await _db.Reiser.FindAsync(id);
                _db.Reiser.Remove(enDBReise);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<Reise> HentEn(int id)
        {
            Reiser enReise = await _db.Reiser.FindAsync(id);
            var hentetReise = new Reise()
            {
                ReiseId = enReise.ReiseId,
                fra = enReise.Fra,
                til = enReise.Til,
                pris = enReise.Pris
            };

            return hentetReise;
        }
    }
}
