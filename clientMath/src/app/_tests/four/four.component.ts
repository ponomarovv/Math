import { Component, OnInit } from '@angular/core';
import {TestService} from "../test.service";


@Component({
  selector: 'app-four',
  template: `
    <div class="card card-body">
      <p>Component Four</p>
      <input type="text" [(ngModel)]="inputData" />
      <button (click)="updateData()">Update Data</button>
    </div>
  `,
})
export class FourComponent implements OnInit {
  inputData: string = '';

  constructor(private testService: TestService) {}

  ngOnInit(): void {}

  updateData(): void {
    this.testService.updateData(this.inputData);
  }
}
