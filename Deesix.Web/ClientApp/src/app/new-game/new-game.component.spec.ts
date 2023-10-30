import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Game } from '../models/game.model';
import { GameService } from '../services/game.service';
import { NewGameComponent } from './new-game.component';

describe('NewGameComponent', () => {
  let component: NewGameComponent;
  let fixture: ComponentFixture<NewGameComponent>;
  let mockGameService: GameService;
  let game: Game;

  beforeEach(async () => {
    mockGameService = jasmine.createSpyObj(['NewGame']);
    game = { id: 1 };
    (mockGameService.NewGame as jasmine.Spy).and.returnValue(of(game));

    await TestBed.configureTestingModule({
      declarations: [ NewGameComponent ],
      providers: [
        { provide: GameService, useValue: mockGameService }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize game model on init', () => {
    expect(component.game).toBe(game);
  });

  it('should call NewGame on GameService on init', () => {
    expect(mockGameService.NewGame).toHaveBeenCalled();
  });
});
