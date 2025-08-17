import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { ErrorStateComponent } from '../../shared/error-state/error-state.component';
import { SkeletonListComponent } from '../../shared/skeleton-list/skeleton-list.component';
import { RepositoriesStore } from '../../state/repositories.store';
import { LanguageListItemComponent } from '../language-list-item/language-list-item.component';
import { EmptyStateComponent } from '../../shared/empty-state/empty-state.component';

@Component({
  selector: 'app-language-list',
  imports: [
    SkeletonListComponent,
    ErrorStateComponent,
    LanguageListItemComponent,
    EmptyStateComponent,
  ],
  templateUrl: './language-list.component.html',
  styleUrl: './language-list.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LanguageListComponent {
  readonly repositoriesStore = inject(RepositoriesStore);
}
