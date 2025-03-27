import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { WelcomeComponent } from './components/welcome/welcome.component';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    // HomeComponent,
    // WelcomeComponent,
    RouterModule.forChild([
      { path: '', component: HomeComponent }
    ])
    //HomeComponent  // Import the standalone component here
  ]
})
export class HomeModule { }
