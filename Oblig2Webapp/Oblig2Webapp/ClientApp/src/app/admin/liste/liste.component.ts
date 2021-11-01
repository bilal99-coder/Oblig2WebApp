import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Reise } from '../../Reise';
import { Modal } from './sletteModal';
import { Havner } from '../../Havner';


@Component({
  selector: 'app-liste',
  templateUrl: './liste.component.html',
  styleUrls: ['./liste.component.css']
})
export class ListeComponent {
  alleHavner: Array<Havner>;
  alleReiser: Array<Reise>; 
  laster: boolean;
  reiseTilSletting: string;
  slettingOK: boolean;

  constructor(private http: HttpClient, private router: Router, private modalService: NgbModal) { }

  ngOnInit() {
    this.laster = true;
    this.hentAlleReiser();
  }

  hentAlleReiser1() {
    const headers: HttpHeaders = new HttpHeaders();

    headers.set('Content-Type', 'application/x-www-form-urlencoded');

    this.http.get<Havner[]>("api/bruker/", { headers: headers })
      .subscribe(havnene => {
        this.formaterReiser(havnene);
        this.laster = false;
      },
        error => console.log(error),
          () => console.log("ferdig get-api/kunde")
      );
  };

  hentAlleReiser() {
    const headers: HttpHeaders = new HttpHeaders();

    headers.set('Content-Type', 'application/x-www-form-urlencoded');

    this.http.get<Reise[]>("api/bruker/", { headers: headers })
      .subscribe(reisene => {
        this.alleReiser = reisene; 
        this.laster = false;
      },
        error => console.log(error),
        () => console.log("ferdig get-api/kunde")
      );
  };



  sletteReise1(id: number) {
    const headers: HttpHeaders = new HttpHeaders();

    headers.set('Content-Type', 'application/x-www-form-urlencoded');
    const reiseTilSletting = this.alleReiser[id];
    console.log("ønsket slettet " + reiseTilSletting.reiseId + " " + reiseTilSletting.fra + " " + reiseTilSletting.til + " " + reiseTilSletting.pris)


    this.http.post("api/bruker", reiseTilSletting, { headers: headers })
      .subscribe(retur => {
        this.router.navigate(['/liste']);
      },
        error => console.log(error)
      );
  };






  sletteReise2(id: number) {
    // we get first the reise from the id
    const reiseTilSletting = this.alleReiser[id];
     // we send a get call to api to register the avgangHavn(fra)/ or reise  on the backend
    this.http.post("api/bruker/", reiseTilSletting).subscribe(retur => {
      if (retur) { // if true 
        // kall til server for sletting
        this.http.delete("api/kunde/" + id)
          .subscribe(retur => {
            this.hentAlleReiser();
          },
            error => console.log(error)
          );
      }
     
    },
      error => console.log(error)
    );
    // And then we make a delete call to api server
  }




  // denne slette funksjonen blir litt komplisert da vi har to asynkrone kall inne i hverandre
  sletteReise(id: number) {

   // var reiseTilSletting = this.alleReiser[id]; 
   // console.log("ønsket slettet " + this.reiseTilSletting.reiseId + " " + this.reiseTilSletting.fra + " " + reiseTilSletting.til + " " + reiseTilSletting.pris)


    /*var reiseId = id;
    console.log(id);
    console.log(this.alleReiser[id]);*/

    /*for (var reise of this.alleReiser) {
      console.log(reise); 
    }
    */
    const headers: HttpHeaders = new HttpHeaders();

    headers.set('Content-Type', 'application/x-www-form-urlencoded');


    // først hent navnet på kunden
    this.http.get<Reise>("api/bruker/" + id, { headers: headers })
      .subscribe(reise => {
        this.reiseTilSletting = reise.fra + " - " + reise.til;
        // så vis modalen og evt. kall til slett
        this.visModalOgSlett(id);
      },
        error => console.log(error)
      );
  }


  visModalOgSlett(id: number) {
    const modalRef = this.modalService.open(Modal);

    modalRef.componentInstance.navn = this.reiseTilSletting;

    modalRef.result.then(retur => {
      console.log('Lukket med:' + retur);
      if (retur == "Slett") {

        // kall til server for sletting
        this.http.delete("api/bruker/" +  id)
          .subscribe(retur => {
            this.hentAlleReiser();
          },
            error => console.log(error)
          );
      }
      this.router.navigate(['/liste']);
    });
  }

  formaterReiser(Havner: Array<Havner>) {
    this.alleReiser = [];
    var reise_indeks = 0; 
    //Get a list of all ports and distinations. (each port has a list of distinations)
    for (var Havn of Havner) {
      // Reise skal ha attributter fra(Avgang havn), til(ankomstHavn), og pris
      for (var index in Havn.ankomstHavner) {
        var enReise = new Reise();
        enReise.reiseId = reise_indeks++;
        enReise.fra = Havn.havnNavn;
        enReise.til = Havn.ankomstHavner[index].havnNavn;
        enReise.pris = Havn.ankomstHavner[index].pris;
        this.alleReiser.push(enReise);
      }   
    }
  }




}
