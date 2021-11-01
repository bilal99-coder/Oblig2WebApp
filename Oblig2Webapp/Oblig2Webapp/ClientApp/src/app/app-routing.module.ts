import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LagreComponent } from './admin/lagre/lagre.component';
import { ListeComponent } from './admin/liste/liste.component';
import { NavMenyComponent } from './nav-meny/nav-meny.component';
import { LogginnComponent } from './logginn/logginn.component';
import { EndreComponent } from './admin/endre/endre.component'

const appRoots: Routes = [
  { path: 'liste', component: ListeComponent },
  { path: 'lagre', component: LagreComponent },
  { path: 'navMeny', component: NavMenyComponent },
  { path: 'logginn', component: LogginnComponent },
  { path: 'endre/:id', component: EndreComponent },
  { path: '', redirectTo: '/logginn', pathMatch: 'full' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoots)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
