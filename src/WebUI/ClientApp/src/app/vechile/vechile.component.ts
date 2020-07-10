import { Component, TemplateRef } from '@angular/core';
import { VechilesClient, VechilesVm,  VechilesDto, CreateVechileCommand,  VechileDetailsVm, VechileVm } from '../xirgo-api';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vechile',
  templateUrl: './vechile.component.html',
  styleUrls: ['./vechile.component.css']
})
export class VechileComponent{

  vechilesListVm: VechilesVm;
  vechileDetailsVm: VechileDetailsVm;

  selectedVechiles: VechilesDto;
  initialState: number;
  newVechileEditor: any = {};
  vechileOptionsEditor : any = {};


  newVechileModalRef: BsModalRef;
  deleteVechileModalRef : BsModalRef;

  faPlus = faPlus;

  constructor(private listClient: VechilesClient, 
              private modalService: BsModalService,
              private router : Router ) 
  {
    listClient.get().subscribe(result => {
        this.vechilesListVm = result;
        
      },error => console.error(error));
  }

  showNewVechileModal(template: TemplateRef<any>): void {
    this.newVechileModalRef = this.modalService.show(template);
  }

  newVechileCancelled(): void {
    this.newVechileModalRef.hide();
    this.newVechileEditor = {};
  }

  public addVechile() : void {
    
    let data = VechilesDto.fromJS({
      id: null,
      licensePlate: this.newVechileEditor.licensePlate,
      brandName: this.newVechileEditor.brandName,
      modelName: this.newVechileEditor.modelName,
      color: this.newVechileEditor.color,
    }); 

    this.listClient.create(<CreateVechileCommand>
      {
        licensePlate : data.licensePlate,
        brandName : data.brandName,
        modelName : data.modelName,
        color : data.color
      }).subscribe(
      result => {
        this.vechilesListVm.vechiles.push(data);
        this.newVechileModalRef.hide();
        this.newVechileEditor = {};
      },
      error => {
        let errors = JSON.parse(error.response);
        console.log(error);
        if(errors){
          this.newVechileEditor.error = error;
        }
      }
    );
  }

  confirmDeleteList(template: TemplateRef<any>, id: number) {
    this.initialState = id;
    this.deleteVechileModalRef = this.modalService.show(template);
  }

  deleteVechileConfirmed(): void {
    this.listClient.delete(this.initialState).subscribe(
      () => {
        this.deleteVechileModalRef.hide();
      },error => console.error(error)
    );
  }

  public gotoVechileDetails(url, id) {
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
