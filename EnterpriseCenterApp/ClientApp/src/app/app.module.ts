import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FindCompanyComponent } from './find-company/find-company.component';
import { AlgorithmsComponent } from './algorithms/algorithms.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FindCompanyComponent,
    HomeComponent,
    AlgorithmsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'find-company', component: FindCompanyComponent },
      { path: 'algorithms', component: AlgorithmsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
