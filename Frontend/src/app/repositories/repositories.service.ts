import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Repository } from './repository.model';

@Injectable({ providedIn: 'root' })
export class RepositoriesService {
  private readonly httpClient = inject(HttpClient);

  getTrending() {
    return this.httpClient.get<Repository[]>(
      environment.apiBaseUrl + `/repositories`
    );
  }
}
