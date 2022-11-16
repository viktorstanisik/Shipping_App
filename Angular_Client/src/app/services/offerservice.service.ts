import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CheckPriceModel } from '../models/checkpricemodel';
import { Offers } from '../models/offers';
import { UserOffersDTO } from '../models/useroffersdto';

@Injectable({
  providedIn: 'root',
})
export class OfferserviceService {
  offers: Offers[] = [];
  userOffersDTO!: UserOffersDTO;

  checkpricemodel!: CheckPriceModel;

  constructor(private http: HttpClient) {}

  submitDimensions(model: CheckPriceModel) {
    return this.http
      .post<Offers[]>(environment.API_URL + 'checkprice', model)
      .pipe(
        map((response) => {
          return (this.offers = response);
        })
      );
  }

  saveOrder(userOffer: UserOffersDTO) {
    return this.http.post(environment.API_URL + 'saveoffer', userOffer).pipe(
      map((response) => {
        if (response) console.log(response);
        else console.log('there was an error please try again');
      })
    );
  }
}
