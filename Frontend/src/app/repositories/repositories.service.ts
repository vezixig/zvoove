import { Injectable } from '@angular/core';
import { httpResource } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class RepositoriesService {
  getTrending() {
    return httpResource(() => environment.apiBaseUrl + `/repositories`);
  }
}
