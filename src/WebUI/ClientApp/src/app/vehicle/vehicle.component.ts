import { Component, TemplateRef } from '@angular/core';
import { VehiclesClient, VehiclesVm,  VehiclesDto, CreateVehicleCommand,  VehicleDetailsVm, VehicleVm } from '../xirgo-api';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent{

  vehiclesListVm: VehiclesVm;
  vehicleDetailsVm: VehicleDetailsVm;

  selectedVehicles: VehiclesDto;
  initialState: number;
  newVehicleEditor: any = {};
  vehicleOptionsEditor : any = {};

  newVehicleModalRef: BsModalRef;
  deleteVehicleModalRef : BsModalRef;
  faPlus = faPlus;

  constructor(private listClient: VehiclesClient, 
              private modalService: BsModalService,
              private router : Router ) 
  {
    listClient.get().subscribe(result => {
        this.vehiclesListVm = result;
        
      },error => console.error(error));
  }

  showNewVehicleModal(template: TemplateRef<any>): void {
    this.newVehicleModalRef = this.modalService.show(template);
  }

  newVehicleCancelled(): void {
    this.newVehicleModalRef.hide();
    this.newVehicleEditor = {};
  }

  public addVehicle() : void {
    
    let data = VehiclesDto.fromJS({
      id: null,
      licensePlate: this.newVehicleEditor.licensePlate,
      brandName: this.newVehicleEditor.brandName,
      modelName: this.newVehicleEditor.modelName,
      color: this.newVehicleEditor.color,
    }); 

    this.listClient.create(<CreateVehicleCommand>
      {
        licensePlate : data.licensePlate,
        brandName : data.brandName,
        modelName : data.modelName,
        color : data.color
      }).subscribe(
      result => {
        this.vehiclesListVm.vehicles.push(data);
        this.newVehicleModalRef.hide();
        this.newVehicleEditor = {};
      },
      error => {
        let errors = JSON.parse(error.response);
        console.log(error);
        if(errors){
          this.newVehicleEditor.error = error;
        }
      }
    );
  }

  confirmDeleteList(template: TemplateRef<any>, id: number) {
    this.initialState = id;
    this.deleteVehicleModalRef = this.modalService.show(template);
  }

  deleteVehicleConfirmed(): void {
    this.listClient.delete(this.initialState).subscribe(
      () => {
        this.deleteVehicleModalRef.hide();
      },error => console.error(error)
    );
  }

  public gotoVehicleDetails(url, id) {
    var myurl = `${url}/${id}`;
    this.router.navigateByUrl(myurl).then(e => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });
  }

}
