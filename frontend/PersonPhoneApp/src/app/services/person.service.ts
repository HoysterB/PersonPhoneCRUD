import { Person } from './../models/Person';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { Constants } from '../utils/Constants';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private snackBar: MatSnackBar, private http: HttpClient) {}

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }

  create(person: Person): Observable<Person> {
    return this.http.post<Person>(`${Constants.API_URL}personphone`, person);
  }

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(`${Constants.API_URL}personphone`);
  }

  getById(id: number): Observable<Person> {
    return this.http.get<Person>(`${Constants.API_URL}personphone/${id}`);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<Person>(`${Constants.API_URL}personphone/${id}`);
  }
}
