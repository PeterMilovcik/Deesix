import { Component, OnInit } from '@angular/core';
import { Game } from '../models/game.model';
import { GameService } from '../services/game.service';
import { WorldSettings } from '../models/world-settings.model';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styleUrls: ['./new-game.component.css']
})
export class NewGameComponent implements OnInit {
  game: Game | undefined;
  title: string = 'World Settings';
  themes: string[] = ['High Fantasy', 'Medieval', 'Steampunk', 'Cyberpunk', 'Space Opera', 'Post-Apocalyptic', 'Urban Fantasy', 'Western', 'Desert', 'Kingdoms', 'Eastern Mythology', 'Nordic Mythology'];
  worldSettings: WorldSettings = { theme: 'High Fantasy', name: 'Eldoria', description: 'Eldoria is a realm where magic flows as freely as the rivers, and mystical creatures roam the enchanted forests. Towering castles and intricate citadels dot the landscape, serving as a testament to the intricate balance of magic and might. Here, heroes forge their destinies and villains seek to disrupt the cosmic equilibrium. Eldoria beckons all who dare to tread its mystical paths.' };

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
