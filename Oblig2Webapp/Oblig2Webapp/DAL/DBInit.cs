using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Oblig2Webapp.DAL
{
    public static class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var db = serviceScope.ServiceProvider.GetService<BrukerContext>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();


            //Lage en ny påloggingsbruker
            var bruker = new Brukere();
            bruker.Brukernavn = "Admin";
            string passord = "123456789";
            byte[] salt = BrukerRepository.LagSalt();
            byte[] hash = BrukerRepository.LagHash(passord, salt);
            bruker.Passord = hash;
            bruker.Salt = salt;
            db.Brukere.Add(bruker);
            // db.SaveChanges();

            var bruker1 = new Brukere();
            bruker1.Brukernavn = "Admin1";
            string passord1 = "987654321";
            byte[] salt1 = BrukerRepository.LagSalt();
            byte[] hash1 = BrukerRepository.LagHash(passord1, salt1);
            bruker1.Passord = hash1;
            bruker1.Salt = salt1;
            db.Brukere.Add(bruker1);
            //  db.SaveChanges();


            //Havner som skal være i fra select på frontend
            //Og Tilsværende reiser sonm eventuelt blir brukt på admin side 


            var nyHavn4 = new Havner();
            nyHavn4.HavnNavn = "Stavanger";
            var nyHavn5 = new Havner();
            nyHavn5.HavnNavn = "Kiel";
            var nyHavn6 = new Havner();
            nyHavn6.HavnNavn = "Arendal";
            var nyHavn7 = new Havner();
            nyHavn7.HavnNavn = "Barcelone ";
            var nyHavn8 = new Havner();
            nyHavn8.HavnNavn = "Monaco";



            /************* ************** Oslo og distinasjoner fra Oslo sin havn ************** **************/
            var nyHavn1 = new Havner();
            nyHavn1.HavnNavn = "Oslo";



            var ankomstHavn1 = new ankomstHavner { HavnNavn = "Portofino, Italia", pris = 3190 };
            var reise1 = new Reiser();
            reise1.Fra = "Oslo";
            reise1.Til = "Portofino, Italia";
            reise1.Pris = 3190;
            db.Reiser.Add(reise1);

            var ankomstHavn2 = new ankomstHavner { HavnNavn = "Livorno, Italia", pris = 4190 };
            var reise2 = new Reiser();
            reise2.Fra = "Oslo";
            reise2.Til = "Livorno, Italia";
            reise2.Pris = 4190;
            db.Reiser.Add(reise2);


            var ankomstHavn3 = new ankomstHavner { HavnNavn = "Bergen, Norge", pris = 490 };
            var reise3 = new Reiser();
            reise3.Fra = "Oslo";
            reise3.Til = "Bergen, Norge";
            reise3.Pris = 490;
            db.Reiser.Add(reise3);


            var ankomstHavn4 = new ankomstHavner { HavnNavn = "Corfu, Hellas", pris = 6599 };
            var reise4 = new Reiser();
            reise4.Fra = "Oslo";
            reise4.Til = "Corfu, Hellas";
            reise4.Pris = 6599;
            db.Reiser.Add(reise4);


            var ankomstHavn5 = new ankomstHavner { HavnNavn = "Kiel, Tyskland", pris = 899 };
            var reise5 = new Reiser();
            reise5.Fra = "Oslo";
            reise5.Til = "Kiel, Tyskland";
            reise5.Pris = 899;
            db.Reiser.Add(reise5);



            //En liste over mulige distinasjoner hvis du reiser fra Olso
            var oslo_ankomsthavner = new List<ankomstHavner>();
            oslo_ankomsthavner.Add(ankomstHavn1);
            oslo_ankomsthavner.Add(ankomstHavn2);
            oslo_ankomsthavner.Add(ankomstHavn3);
            oslo_ankomsthavner.Add(ankomstHavn4);
            oslo_ankomsthavner.Add(ankomstHavn5);



            nyHavn1.AnkomstHavner = oslo_ankomsthavner;
            db.Havner.Add(nyHavn1);



            /************* ************** Bergen og distinasjoner fra Oslo sin havn ************** **************/
            var nyHavn2 = new Havner();
            nyHavn2.HavnNavn = "Bergen";



            var ankomstHavn6 = new ankomstHavner { HavnNavn = "Marseille, Frankrike", pris = 2450 };
            var reise6 = new Reiser();
            reise6.Fra = "Bergen";
            reise6.Til = "Marseille, Frankrike";
            reise6.Pris = 2450;
            db.Reiser.Add(reise6);

            var ankomstHavn7 = new ankomstHavner { HavnNavn = "Venice, Italia", pris = 3190 };
            var reise7 = new Reiser();
            reise7.Fra = "Bergen";
            reise7.Til = "Venice, Italia";
            reise7.Pris = 3190;
            db.Reiser.Add(reise7);

            var ankomstHavn8 = new ankomstHavner { HavnNavn = "San Juan, Puerto Rico", pris = 8900 };
            var reise8 = new Reiser();
            reise8.Fra = "Bergen";
            reise8.Til = "San Juan, Puerto Rico";
            reise8.Pris = 8900;
            db.Reiser.Add(reise8);

            var ankomstHavn9 = new ankomstHavner { HavnNavn = "Piraeus, Hellas", pris = 6790 };
            var reise9 = new Reiser();
            reise9.Fra = "Bergen";
            reise9.Til = "Piraeus, Hellas";
            reise9.Pris = 6790;
            db.Reiser.Add(reise9);

            var ankomstHavn10 = new ankomstHavner { HavnNavn = "Barcelona, Spania", pris = 2190 };
            var reise10 = new Reiser();
            reise10.Fra = "Bergen";
            reise10.Til = "Barcelona, Spania";
            reise10.Pris = 2190;
            db.Reiser.Add(reise10);


            //En liste over mulige distinasjoner hvis du reiser fra Bergen
            var bergen_ankomsthavner = new List<ankomstHavner>();
            bergen_ankomsthavner.Add(ankomstHavn6);
            bergen_ankomsthavner.Add(ankomstHavn7);
            bergen_ankomsthavner.Add(ankomstHavn8);
            bergen_ankomsthavner.Add(ankomstHavn9);
            bergen_ankomsthavner.Add(ankomstHavn10);






            nyHavn2.AnkomstHavner = bergen_ankomsthavner;
            db.Havner.Add(nyHavn2);



            /************* ************** Oslo og distinasjoner fra Oslo sin havn ************** **************/
            var nyHavn3 = new Havner();
            nyHavn3.HavnNavn = "Kristiansand";



            var ankomstHavn11 = new ankomstHavner { HavnNavn = "PortMiami, USA", pris = 10090 };
            var reise11 = new Reiser();
            reise11.Fra = "Kristiansand";
            reise11.Til = "PortMiami, USA";
            reise11.Pris = 10090;
            db.Reiser.Add(reise11);

            var ankomstHavn12 = new ankomstHavner { HavnNavn = "Port Canaveral, USA", pris = 9990 };
            var reise12 = new Reiser();
            reise12.Fra = "Kristiansand";
            reise12.Til = "Port Canaveral, USA";
            reise12.Pris = 9990;
            db.Reiser.Add(reise12);


            var ankomstHavn13 = new ankomstHavner { HavnNavn = "Cozumel, Mexico", pris = 6750};
            var reise13 = new Reiser();
            reise13.Fra = "Kristiansand";
            reise13.Til = "Cozumel, Mexico";
            reise13.Pris = 6750;
            db.Reiser.Add(reise13);

            var ankomstHavn14 = new ankomstHavner { HavnNavn = "Port Everglades, USA", pris = 2190 };
            var reise14 = new Reiser();
            reise14.Fra = "Kristiansand";
            reise14.Til = "Port Everglades, USA";
            reise14.Pris = 2190;
            db.Reiser.Add(reise14);

            var ankomstHavn15 = new ankomstHavner { HavnNavn = "Prince George Wharf, Bahamas", pris = 4790 };
            var reise15 = new Reiser();
            reise15.Fra = "Kristiansand";
            reise15.Til = "Prince George Wharf, Bahamas";
            reise15.Pris = 4790;
            db.Reiser.Add(reise15);


            //En liste over mulige distinasjoner hvis du reiser fra Kristiansand
            var kristiansand_ankomsthavner = new List<ankomstHavner>();
            kristiansand_ankomsthavner.Add(ankomstHavn11);
            kristiansand_ankomsthavner.Add(ankomstHavn12);
            kristiansand_ankomsthavner.Add(ankomstHavn13);
            kristiansand_ankomsthavner.Add(ankomstHavn14);
            kristiansand_ankomsthavner.Add(ankomstHavn15);



            nyHavn3.AnkomstHavner = kristiansand_ankomsthavner;
            db.Havner.Add(nyHavn3);

            db.SaveChanges();
        }
    }
}
