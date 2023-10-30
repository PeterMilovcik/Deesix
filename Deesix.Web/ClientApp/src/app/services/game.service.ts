import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Game } from '../models/game.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  NewGame(): Observable<Game> {
    return this.http.post<Game>('/api/new-game', {}).pipe(
      catchError((error: any) => {
        console.error('Something went wrong', error);
        throw error;
      })
    );
  }
}