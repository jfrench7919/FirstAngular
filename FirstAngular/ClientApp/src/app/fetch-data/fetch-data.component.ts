import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public people: People[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<People[]>(baseUrl + 'api/People').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }
}

interface People {
  id: number;
  firstName: string;
  lastName: string;
  middleName: string;
  title: string;
}
