import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { CardModule } from 'primeng/card';
import { Repository } from '../repository.model';

@Component({
  selector: 'app-repository-list-item',
  imports: [CardModule],
  templateUrl: './repository-list-item.component.html',
  styleUrl: './repository-list-item.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RepositoryListItemComponent {
  readonly repository = input.required<Repository>();
}
