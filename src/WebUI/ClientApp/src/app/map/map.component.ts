import { Component, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  changeDetection : ChangeDetectionStrategy.OnPush
})
export class MapComponent {

  selectedMarker : any;
  zoom:number;
  lat: number;
  lng: number;
  
  constructor() {}

  selectMarker(event) {
    this.selectedMarker = {
      lat: event.latitude,
      lng: event.longitude
    };
  }
  
 
}
