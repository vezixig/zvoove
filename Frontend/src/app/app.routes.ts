import { Routes } from '@angular/router';
import { RepositoryListComponent } from './repositories/repository-list/repository-list.component';

export const routes: Routes = [
  { path: 'repository', component: RepositoryListComponent },
  { path: '**', redirectTo: 'repository' },
];
