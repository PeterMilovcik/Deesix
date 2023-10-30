import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { GameService } from './game.service';
import { Game } from '../models/game.model';

describe('GameService', () => {
  let service: GameService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [GameService]
    });

    service = TestBed.inject(GameService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // Ensure that there are no outstanding requests
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('NewGame method should return a non-null result', () => {
    service.NewGame().subscribe(response => {
      expect(response).not.toBeNull();
    });

    const req = httpMock.expectOne('/api/new-game');
    expect(req.request.method).toBe('POST');
    req.flush({}, { status: 200, statusText: 'OK' });
  });

  it('NewGame method should return a game with ID 1', () => {
    const mockGame: Game = { id: 1 };

    service.NewGame().subscribe(game => {
      expect(game).not.toBeNull();
      expect(game.id).toBe(1);
    });

    const req = httpMock.expectOne('/api/new-game');
    expect(req.request.method).toBe('POST');
    req.flush(mockGame, { status: 200, statusText: 'OK' });
  });
});
