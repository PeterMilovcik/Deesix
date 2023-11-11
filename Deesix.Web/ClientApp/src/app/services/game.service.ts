import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Game } from '../models/game.model';
import { WorldSettings } from '../models/world-settings.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  NewGame(): Observable<Game> {
    return this.http.post<Game>(`${this.apiUrl}/api/game/new-game`, {}).pipe(
      catchError((error: any) => {
        console.error('Something went wrong', error);
        throw error;
      })
    );
  }

  GetRandomizedWorldSettings(): Observable<WorldSettings> {
    return this.http.get<WorldSettings>(`${this.apiUrl}/api/worldsettings/create`, {}).pipe(
      catchError((error: any) => {
        console.error('Something went wrong', error);
        throw error;
      })
    );
  }

}