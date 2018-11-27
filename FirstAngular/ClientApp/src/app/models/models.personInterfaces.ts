export interface People {
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

export interface PersonJob {
  id: number;
  personId: number;
  jobId: number;
  job: Job;
}

export interface Job {
  id: number;
  name: string;
  description: string;
  startMonth: number;
  startYear: number;
  endMonth: number;
  endYear: number;
  jobDuty: Array<Duty>;
  jobLocation: Array<Location2>;
}

export interface JobLocation {
  id: number;
  locationId: number;
  jobId: number;
  location: Location2;
}

export interface JobDuty {
  id: number;
  dutyId: number;
  jobId: number;
  duty: Duty;
}

export interface Duty {
  id: number;
  description: string;
}

export interface PersonCert {
  id: number
  cert: Cert;
}

export interface Cert {
  id: number;
}

export interface PersonLocation {
  id: number;
  locationId: number;
  personId: number;
  location: Location2;
}

export interface Location2 {
  id: number;
  address: string;
  cityCounty: string;
  state: string;
  zip: string;
  phone: string;
}

export interface JobManager {
  id: number;
  manager: People;
}

export interface PersonEducation {
  id: number;
  education: Education;
}

export interface Education {
  id: number;
}

export interface PersonReferencePerson {
  id: number;
  referencePerson: ReferencePerson;
}

export interface ReferencePerson {
  id: number;
}

export interface PersonSkill {
  id: number;
  skill: Skill;
}

export interface Skill {
  id: number;
  name: string;
  years: number;
}

export interface PersonUrl {
  id: number;
  url: Url;
}

export interface Url {
  id: number;
}


