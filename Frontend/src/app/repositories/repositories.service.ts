import { Injectable } from '@angular/core';
import { httpResource } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Repository } from './repository.model';

@Injectable({ providedIn: 'root' })
export class RepositoriesService {
  getTrending() {
    return httpResource<Repository[]>(
      () => environment.apiBaseUrl + `/repositories`
    );
  }
}
