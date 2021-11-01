import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Bruker } from "../Bruker";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router'

@Component({
  selector: 'app-logginn',
  templateUrl: './logginn.component.html',
  styleUrls: ['./logginn.component.css']
})
export class LogginnComponent {


  Skjema: FormGroup;

  constructor(private fb: FormBuilder, private _http: HttpClient, private router: Router) {
    this.Skjema = fb.group({
      brukernavn: ["", Validators.required],
      passord: ["", Validators.pattern("[0-9]{6,15}")]
    });
  }
  onSubmit1() {
    console.log("Hei from loginnComponent.ts");
    this.router.navigate(['/navMeny']);
    // <button (click)="router.navigate(['/navMeny']);" type="submit" >Register</button>
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
          if (ok) {
            console.log("Innlogging succeded")
            this.router.navigate(['/navMeny']);
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

    this.router.navigate(['/liste']);
  }

}
