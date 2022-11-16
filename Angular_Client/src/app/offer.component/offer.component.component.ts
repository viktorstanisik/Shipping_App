import { Component, OnInit } from '@angular/core';
import { Offers } from '../models/offers';
import { OfferserviceService } from '../services/offerservice.service';

@Component({
  selector: 'app-offer.component',
  templateUrl: './offer.component.component.html',
  styleUrls: ['./offer.component.component.css'],
})
export class OfferComponentComponent implements OnInit {
  model: any = {};
  offers!: Offers[];
  offerModel: any = {};
  isDisplayed = false;
  emptyResponse = false;
  isEnabled = true;
  constructor(private offerserviceService: OfferserviceService) {}

  ngOnInit(): void {}
  submitOffer() {
    this.isEnabled = false;
    this.offerserviceService.submitDimensions(this.model).subscribe(
      (response) => {
        console.log(response);
        this.offers = response;
        this.isDisplayed = true;
 
      },error => {
        if(error.message != "") {
          this.emptyResponse = true
        } 
        
        console.log(error);
      })

  }

  saveOrder(carrierName: string, offerPrice: string) {
    this.offerModel.carrierName = carrierName;
    this.offerModel.packageofferPrice = offerPrice.replace('$', '');
    this.offerModel.packagewidth = this.model.packagewidth;
    this.offerModel.packageheight = this.model.packageheight;
    this.offerModel.packagedepth = this.model.packagedepth;
    this.offerModel.packageweight = this.model.packageweight;
    console.log(this.offerModel);

    this.offerserviceService.saveOrder(this.offerModel).subscribe(
      (response) => {
        console.log(response);    
        setTimeout(() => {
          this.isDisplayed = false;
        }, 1000);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  cancel() {
    this.isDisplayed = false;
  }
}
