import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Bruker } from "./Bruker";
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: "app-root",
  templateUrl: "app.component.html"
})
export class AppComponent {

  Skjema: FormGroup;

  constructor(private fb: FormBuilder, private _http: HttpClient ) {
    this.Skjema = fb.group({
      brukernavn: ["", Validators.required],
      passord: ["", Validators.pattern("[0-9]{6,15}")]
    });
  }

  onSubmit() {
    const enBruker = new Bruker();
    enBruker.Brukernavn = this.Skjema.value.brukernavn;
    enBruker.Passord = this.Skjema.value.passord;
    const headers: HttpHeaders = new HttpHeaders();

    headers.set('Content-Type', 'application/x-www-form-urlencoded');

    this._http.post("api/Bruker/", enBruker, { headers: headers })
      .subscribe(
        ok => {
          if (ok){
            console.log("Innlogging succeded")
          }
          else {
            console.log("Innlogging not succeded")
          }
      },
        error => alert(error),
        () => console.log("ferdig innlogging")
      );

    console.log("***********");
    console.log("Modellbasert skjema submitted:");
    console.log(this.Skjema);
    console.log(this.Skjema.value.brukernavn);
    console.log(this.Skjema.touched);
    console.log(this.Skjema.value.passord); 
  }
}

