import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormBuilder} from '@angular/forms';
import {MatCardModule} from '@angular/material/card'; 
import { MatButtonModule } from "@angular/material/button";
import {MatChipsModule} from '@angular/material/chips'; 
import {MatGridListModule} from '@angular/material/grid-list'; 
import {MatCheckboxModule} from '@angular/material/checkbox'; 
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 

@Component({
  selector: 'app-dogs-list',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule, MatChipsModule, MatGridListModule, MatCheckboxModule,MatProgressSpinnerModule],
  templateUrl: './dogs-list.component.html',
  styleUrls: ['./dogs-list.component.css']
})
export class DogsListComponent {
  toppings = this._formBuilder.group({
    pepperoni: false,
    extracheese: false,
    mushroom: false,
  });

  constructor(private _formBuilder: FormBuilder) {}
}
