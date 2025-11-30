import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

export interface Team {
  id: number;
  name: string;
}

export interface Visitor {
  name: string;
  email: string;
  company: string;
  teamId: number;
  entranceId: string;
  rulesAccepted: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class VisitorService {
  private apiUrl = 'https://localhost:44322/api'; // Adjust port if needed

  // State Management
  private entranceIdSubject = new BehaviorSubject<string>('');
  entranceId$ = this.entranceIdSubject.asObservable();

  private visitorDataSubject = new BehaviorSubject<Partial<Visitor>>({});
  visitorData$ = this.visitorDataSubject.asObservable();

  constructor(private http: HttpClient) { }

  setEntranceId(id: string) {
    this.entranceIdSubject.next(id);
  }

  getEntranceId(): string {
    return this.entranceIdSubject.value;
  }

  updateVisitorData(data: Partial<Visitor>) {
    this.visitorDataSubject.next({ ...this.visitorDataSubject.value, ...data });
  }

  getVisitorData(): Partial<Visitor> {
    return this.visitorDataSubject.value;
  }

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(`${this.apiUrl}/teams`);
  }

  checkIn(visitor: Visitor): Observable<any> {
    return this.http.post(`${this.apiUrl}/checkin`, visitor);
  }
}
