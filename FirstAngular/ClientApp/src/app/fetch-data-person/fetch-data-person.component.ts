import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data-person.component.html'
})
export class FetchDataPersonComponent implements OnInit, OnDestroy {
  public people: People[];
  public chartData: ChartData;
  public id: number;
  public type = 'horizontalBar';
  private sub: any;

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
    http.get<People[]>(baseUrl + 'api/People').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
    http.get<ChartData>(baseUrl + 'api/ChartsData/Skills/1').subscribe(result => {
      this.chartData = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      //alert(this.id);
      // In a real app: dispatch action to load the details here.
    });
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
  description: string;
  startMonth: number;
  startYear: number;
  endMonth: number;
  endYear: number;
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

