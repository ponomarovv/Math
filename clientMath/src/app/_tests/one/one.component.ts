import {Component} from '@angular/core';
import {TestService} from "../test.service";

@Component({
  selector: 'app-one',
  templateUrl: './one.component.html',
  styleUrls: ['./one.component.css']
})
export class OneComponent {
  a = 1;

  constructor(private testService: TestService) {
  }

  sendDataToTwoComponent(){
    this.testService.sendData(this.a);
  }

  increment(){
    this.a++;
  }
}
