import { Routes } from '@angular/router';
import { RepositoryListComponent } from './repositories/repository-list/repository-list.component';
import { LanguageListComponent } from './languages/language-list/language-list.component';

export const routes: Routes = [
  { path: 'repository', component: RepositoryListComponent },
  { path: 'language', component: LanguageListComponent },
  { path: '**', redirectTo: 'repository' },
];
