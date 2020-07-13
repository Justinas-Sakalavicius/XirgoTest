import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { VehicleComponent } from './vehicle/vehicle.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';
import { AgmCoreModule } from '@agm/core';
import { MapComponent } from './map/map.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VehicleComponent,
    VehicleDetailComponent,
    MapComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'vehicle', component: VehicleComponent },
      { path: 'vehicle/:id', component: VehicleDetailComponent },
      { path: 'map', component: MapComponent }
    ]),
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey : 'AIzaSyCsZu5GFyw8FqTAYFA063j8G_qcFI54pBI'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
