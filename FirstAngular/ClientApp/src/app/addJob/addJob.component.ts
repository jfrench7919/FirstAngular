import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { Job } from '../models/models.personInterfaces';
import { AddJobService } from './addJob.service';

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
  public addJobService: AddJobService;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
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
          phone: ''
        }
      ]
    };
  }

  public postJob() {
    alert('test');
    this.http.post('./api/jobs',
      this.job)
      .subscribe(
        data => {
          console.log("POST Request is successful ", data);
        },
        error => {
          console.log("Error", error);
        }
      );
  }
}

