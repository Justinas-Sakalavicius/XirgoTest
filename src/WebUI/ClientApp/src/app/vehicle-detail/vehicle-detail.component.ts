import { Component} from '@angular/core';
import { VehicleDetailsVm, VehicleVm, VehiclesDetailsClient, VehiclesClient } from '../xirgo-api';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MapComponent } from '../map/map.component';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.css'],
})
export class VehicleDetailComponent {
  public vehicleVm : VehicleVm;
  public detailsVm : VehicleDetailsVm;

  private bsModalRef: BsModalRef;

  constructor(private listClient : VehiclesClient,
              private detailsClient : VehiclesDetailsClient,
              private router : Router,
              private activatedRoute : ActivatedRoute,
              private modalService: BsModalService) 
  { 
    this.activatedRoute.params.subscribe(data =>
      {
        this.listClient.getById(data.id).subscribe(result => {
          this.vehicleVm = result;
          this.detailsClient.getByVehicleId(this.vehicleVm.vehicle.id).subscribe(result => {
            this.detailsVm = result
          },error => console.error(error));
        },error => console.error(error));
      });
  }

  public gotoVehicleMap(id) {
    var myurl = `/map/${id}`;
    this.router.navigateByUrl(myurl).then(e => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });
  }

  public vehicleDetailsMap(lat: number, lng : number) {
      const initialState = {
        lat : lat,
        lng : lng
      };
      this.bsModalRef = this.modalService.show(MapComponent, {initialState});
  }

}
