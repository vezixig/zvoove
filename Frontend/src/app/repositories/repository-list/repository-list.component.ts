import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { SkeletonListComponent } from '../../shared/skeleton-list/skeleton-list.component';
import { ErrorStateComponent } from '../../shared/skeleton-list/error-state/error-state.component';
import { RepositoryListItemComponent } from '../repository-list-item/repository-list-item.component';
import { RepositoriesStore } from '../../state/respositories.store';

@Component({
  selector: 'app-repository-list',
  imports: [
    SkeletonListComponent,
    ErrorStateComponent,
    RepositoryListItemComponent,
  ],
  templateUrl: './repository-list.component.html',
  styleUrl: './repository-list.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RepositoryListComponent {
  readonly repositoriesStore = inject(RepositoriesStore);
}
