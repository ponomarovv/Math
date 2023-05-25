import {Component, OnInit} from '@angular/core';
import {TestService} from "../test.service";

@Component({
  selector: 'app-two',
  templateUrl: './two.component.html',
  styleUrls: ['./two.component.css']
})
export class TwoComponent implements OnInit {
  receivedData: number = 0;

  constructor(private testService: TestService) {
  }

  ngOnInit(): void {
    this.testService.getData().subscribe((data: number) => {
      this.receivedData = data;
    });
  }

}
