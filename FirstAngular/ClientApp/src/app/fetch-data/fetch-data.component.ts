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
  personJob: Array<PersonJob>;
  personCert: Array<PersonCert>;
  personLocation: Array<PersonLocation>;
  jobManager: Array<JobManager>;
  personEducation: Array<PersonEducation>;
  personReferencePerson: Array<PersonReferencePerson>;
  personSkill: Array<PersonSkill>;
  personUrl: Array<PersonUrl>;
}

interface PersonJob {
  id: number;
  personId: number;
  jobId: number;
  job: Job;
}

interface Job {
  id: number;
  name: string;
  jobDuty: Array<Duty>;
  jobLocation: Array<Location>;
}

interface Duty {
  id: number;
  description: string;
}

interface PersonCert{
  id: number
  cert: Cert;
}

interface Cert {
  id: number;
}

interface PersonLocation {
  location: Location;
}

interface Location {
  id: number;
}

interface JobManager {
  id: number;
  manager: People;
}

interface PersonEducation {
  id: number;
  education: Education;
}

interface Education {
  id: number;
}

interface PersonReferencePerson {
  id: number;
  referencePerson: ReferencePerson;
}

interface ReferencePerson {
  id: number;
}

interface PersonSkill {
  id: number;
  skill: Skill;
}

interface Skill {
  id: number;
}

interface PersonUrl {
  id: number;
  url: Url;
}

interface Url {
  id: number;
}

