import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Repository } from './repository.model';

@Injectable({ providedIn: 'root' })
export class RepositoriesService {
  private readonly httpClient = inject(HttpClient);

  getTrending(filter?: string) {
    return this.httpClient.get<Repository[]>(
      filter
        ? environment.apiBaseUrl + `/repositories?filter=${filter}`
        : environment.apiBaseUrl + `/repositories`
    );
  }
}
