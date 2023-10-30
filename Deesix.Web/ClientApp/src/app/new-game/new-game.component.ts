import { Component, OnInit } from '@angular/core';
import { Game } from '../models/game.model';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styleUrls: ['./new-game.component.css']
})
export class NewGameComponent implements OnInit {
  game: Game | undefined;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.gameService.NewGame().subscribe({
      next: game => {
        this.game = game;
      },
      error: error => {
        console.error('Something went wrong', error);
      }
    });
  }
}
