using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oblig2Webapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2Webapp.DAL
{   
    [ApiController]
    // dekoratøren over må være med; dersom ikke må post og put bruke [FromBody] som deoratør inne i prameterlisten
    [Route("api/[controller]")]
    public class BrukerController : ControllerBase
    {
        private readonly IBrukerRepository _db;
        private readonly ILogger<BrukerController> _log; 
       public  BrukerController(IBrukerRepository db, ILogger<BrukerController> log)
        {
            _db = db;
            _log = log; 
        }
        /*public async Task <bool> Lagre(Bruker innBruker)
        {
        // Server validering må puttes her!!!
            return await _db.Lagre(innKunde); 
        }*/


        // metoden for innlogging 
        [HttpPost]
        public async Task<ActionResult> LoggInn([FromBody]Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returOk = await _db.LoggInn(bruker);
                if (!returOk)
                {
                    _log.LogInformation("Bruker ble ikke logget inn");
                    return Ok(false); 
                }

                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        [HttpGet]
        public async Task<ActionResult> hentAlleReiser()
        {
            List<Reiser> alleHavner_Reiser = await _db.hentAlleReiser();
            return Ok(alleHavner_Reiser) ; 
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Slett(int id)
        {
            bool returOK = await _db.Slett(id) ; 
            if (!returOK)
            {
                _log.LogInformation("Sletting av Reisen ble ikke utført");
                return NotFound();
            }
            return Ok();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult> HentEn(int id)
        {
            if (ModelState.IsValid)
            {
                Reise reisen = await _db.HentEn(id);
                if (reisen == null)
                {
                    _log.LogInformation("Fant ikke reisen");
                    return NotFound();
                }
                return Ok(reisen);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }


    }
}
