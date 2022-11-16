import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OfferComponentComponent } from './offer.component/offer.component.component';

const routes: Routes = [

  {path: '**', component: OfferComponentComponent, pathMatch: 'full'},
  {path: '', component: OfferComponentComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
