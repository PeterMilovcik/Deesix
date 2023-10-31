import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Game } from '../models/game.model';
import { WorldSettings } from '../models/world-settings.model';
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

  it('should have title property set to "World Settings"', () => {
    expect(component.title).toBe('World Settings');
  });

  it('should have themes array initialized with correct values', () => {
    const expectedThemes = ['High Fantasy', 'Medieval', 'Steampunk', 'Cyberpunk', 'Space Opera', 'Post-Apocalyptic', 'Urban Fantasy', 'Western', 'Desert', 'Kingdoms', 'Eastern Mythology', 'Nordic Mythology'];
    expect(component.themes).toEqual(expectedThemes);
  });

  it('should have worldSettings property with non-empty name, description, and theme', () => {
    expect(component.worldSettings).toBeDefined();
    expect(component.worldSettings.name).toBeTruthy();
    expect(component.worldSettings.description).toBeTruthy();
    expect(component.worldSettings.theme).toBeTruthy();
  });
});
