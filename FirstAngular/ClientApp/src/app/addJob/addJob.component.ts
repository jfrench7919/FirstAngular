import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { Job } from '../models/models.personInterfaces';

@NgModule({
  imports: [BrowserModule, FormsModule],
  declarations: [AddJobComponent],
  bootstrap: [AddJobComponent]
})

@Component({
  selector: 'app-addJob',
  templateUrl: './addJob.component.html'
})
export class AddJobComponent {
  public job: Job;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.job = {
      id: 0,
      name: '',
      description: '',
      startMonth: 0,
      startYear: 0,
      endMonth: 0,
      endYear: 0,
      jobDuty: [],
      jobLocation: [
        {
          id: 0,
          address: '',
          cityCounty: '',
          state: '',
          zip: '',
          phone:''
        }
      ]
    };
  }
}

