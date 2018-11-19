import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data-person.component.html'
})
export class FetchDataPersonComponent implements OnInit, OnDestroy {
  public person: People;
  public chartData: ChartData;

  public id: number;
  private sub: any;

  public type = 'horizontalBar';

  public options = {
    responsive: true,
    barThickness: 20,
    maintainAspectRatio: false,
    scales: {
      xAxes: [{
        ticks: {
          beginAtZero: true
        }
      }]
    },
    legend: {
      display: false,
      labels: {
        fontColor: 'rgb(255, 99, 132)'
      }
    }
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    http.get<People>(baseUrl + 'api/People' + '/' + this.id).subscribe(async result => {
      this.person = await result;
      http.get<PersonLocation>(baseUrl + 'api/Locations/ByPerson/' + this.id).subscribe(async result => {
        this.person.personLocation = await result;
      }, error => console.error(error));
      http.get<PersonJob[]>(baseUrl + 'api/Jobs/ByPerson/' + this.id).subscribe(async result => {
        this.person.personJob = await result;
        this.person.personJob.forEach(function (pj) {
          http.get<JobLocation[]>(baseUrl + 'api/Locations/ByJob/' + pj.jobId).subscribe(async result => {
            pj.job.jobLocation = await result;
          }, error => console.error(error));
          http.get<JobDuty[]>(baseUrl + 'api/Duties/ByJob/' + pj.jobId).subscribe(async result => {
            pj.job.jobDuty = await result;
          }, error => console.error(error));
        });
      }, error => console.error(error));
    }, error => console.error(error));
    http.get<ChartData>(baseUrl + 'api/ChartsData/Skills/' + this.id).subscribe(async result => {
      this.chartData = await result;
    }, error => console.error(error));
    
  }

  ngOnInit() {
    //this.sub = this.route.params.subscribe(params => {
      //this.id = +params['id']; // (+) converts string 'id' to a number
      //alert(this.id);
      // In a real app: dispatch action to load the details here.
    //});
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}

interface ChartData {
  data: {
    labels: Array<string>,
    datasets: Array<{ label: string, data: Array<number>, backgroundColor: Array<string> }>
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
  personLocation: PersonLocation;
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
  description: string;
  startMonth: number;
  startYear: number;
  endMonth: number;
  endYear: number;
  jobDuty: Array<JobDuty>;
  jobLocation: Array<JobLocation>;
}

interface JobLocation {
  id: number;
  locationId: number;
  jobId: number;
  location: Location;
}

interface JobDuty {
  id: number;
  dutyId: number;
  jobId: number;
  duty: Duty;
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
  id: number;
  locationId: number;
  personId: number;
  location: Location;
}

interface Location {
  id: number;
  address: string;
  cityCounty: string;
  state: string;
  zip: string;
  phone: string;
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
  name: string;
  years: number;
}

interface PersonUrl {
  id: number;
  url: Url;
}

interface Url {
  id: number;
}

