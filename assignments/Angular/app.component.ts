import { Component } from '@angular/core';
import {FormControl} from '@angular/forms';
import { NgModel } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Assg-1';
  fontStyleControl = new FormControl();
  fontStyle?: string;
  isPressed = false;
  isPressed1 = false;
  isPressed2 = false;

  onButtonPress() {
    this.isPressed = true;
  }
  onButtonPress1()
  {
    this.isPressed1=true;
  }
  onButtonPress2()
  {
    this.isPressed2=true;
  }
}
