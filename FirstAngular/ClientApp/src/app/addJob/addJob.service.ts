import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Job } from '../models/models.personInterfaces';

@Injectable()
export class AddJobService {
  constructor(private http: HttpClient) { }
  addJobUrl = 'assets/addJob.json';

  getAddJob(job: Job) {
    return this.http.post(this.addJobUrl, job);
  }
}
