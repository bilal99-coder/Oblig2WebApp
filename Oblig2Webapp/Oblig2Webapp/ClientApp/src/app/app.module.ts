import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavMenyComponent } from './nav-meny/nav-meny.component';
import { AppRoutingModule } from './app-routing.module';
import { LogginnComponent } from './logginn/logginn.component';
import { ListeComponent } from './admin/liste/liste.component';
import { EndreComponent } from './admin/endre/endre.component';
import { LagreComponent } from './admin/lagre/lagre.component';
import { Modal } from './admin/liste/sletteModal';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
@NgModule({
  declarations: [
    AppComponent,
    NavMenyComponent,
    LogginnComponent,
    ListeComponent,
    EndreComponent,
    LagreComponent,
    Modal
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [], //SharedService
  bootstrap: [AppComponent],
  entryComponents: [Modal] // merk!  
})
export class AppModule { }
