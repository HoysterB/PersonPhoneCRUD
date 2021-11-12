import { PersonPhone } from './../models/PersonPhone';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { Constants } from '../utils/Constants';

@Injectable({
  providedIn: 'root',
})
export class PersonPhoneService {
  constructor(private snackBar: MatSnackBar, private http: HttpClient) {}

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }

  getByPersonId(id: number): Observable<PersonPhone[]> {
    return this.http.get<PersonPhone[]>(`${Constants.API_URL}phone/${id}`);
  }
}
