import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { ActivatedRoute } from '@angular/router';
import { People, PersonLocation, PersonJob, JobLocation, JobDuty, Duty, Location2 } from '../models/models.personInterfaces';

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
          http.get<Location2[]>(baseUrl + 'api/Locations/ByJob/' + pj.jobId).subscribe(async result => {
            pj.job.jobLocation = await result;
          }, error => console.error(error));
          http.get<Duty[]>(baseUrl + 'api/Duties/ByJob/' + pj.jobId).subscribe(async result => {
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



