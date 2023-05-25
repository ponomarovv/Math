import { Component, OnInit } from '@angular/core';
import {TestService} from "../test.service";

@Component({
  selector: 'app-three',
  template: `
    <div class="card card-body">
      <p>Component Three</p>
      <div>{{ data }}</div>
    </div>
  `,
})
export class ThreeComponent implements OnInit {
  data: string = '';

  constructor(private testService: TestService) {}

  ngOnInit(): void {
    this.testService.data$.subscribe((newData: string) => {
      this.data = newData;
    });
  }


}
