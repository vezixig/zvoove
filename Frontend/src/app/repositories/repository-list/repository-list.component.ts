import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RepositoriesService } from '../repositories.service';
import { SkeletonListComponent } from '../../shared/skeleton-list/skeleton-list.component';
import { ErrorStateComponent } from '../../shared/skeleton-list/error-state/error-state.component';
import { RepositoryListItemComponent } from '../repository-list-item/repository-list-item.component';

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
  private readonly repositoriesService = inject(RepositoriesService);
  readonly repositories = this.repositoriesService.getTrending();
}
