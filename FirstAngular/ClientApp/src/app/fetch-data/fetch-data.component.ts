import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { People, PersonJob, Location2 } from '../models/models.personInterfaces';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public people: People[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<People[]>(baseUrl + 'api/People').subscribe(result => {
      this.people = result;
      this.people.forEach(function (p) {
        http.get<PersonJob[]>(baseUrl + 'api/Jobs/ByPerson/' + p.id).subscribe(async result => {
          p.personJob = await result;
          p.personJob.forEach(function (pj) {
            http.get<Location2[]>(baseUrl + 'api/Locations/ByJob/' + pj.jobId).subscribe(async result => {
              pj.job.jobLocation = await result;
            }, error => console.error(error));
         });
        }, error => console.error(error));
      });
    }, error => console.error(error));
  }
}

