import { Component} from '@angular/core';
import { VechileDetailsVm, VechileVm, VechilesDetailsClient, VechilesClient } from '../xirgo-api';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MapComponent } from '../map/map.component';

@Component({
  selector: 'app-vechile-detail',
  templateUrl: './vechile-detail.component.html',
  styleUrls: ['./vechile-detail.component.css'],
})
export class VechileDetailComponent {
  public vechileVm : VechileVm;
  public detailsVm : VechileDetailsVm;

  private bsModalRef: BsModalRef;

  constructor(private listClient : VechilesClient,
              private detailsClient : VechilesDetailsClient,
              private router : Router,
              private activatedRoute : ActivatedRoute,
              private modalService: BsModalService) 
  { 
    this.activatedRoute.params.subscribe(data =>
      {
        this.listClient.getById(data.id).subscribe(result => {
          this.vechileVm = result;
          this.detailsClient.getByVechileId(this.vechileVm.vechile.id).subscribe( result => {
            this.detailsVm = result
          },error => console.error(error));
        },error => console.error(error));
      });
  }

  public gotoVechileMap(id) {
    var myurl = `/map/${id}`;
    this.router.navigateByUrl(myurl).then(e => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });
  }

  public vechileDetailsMap(lat: number, lng : number) {
      const initialState = {
        lat : lat,
        lng : lng
      };
      this.bsModalRef = this.modalService.show(MapComponent, {initialState});
  }

}
