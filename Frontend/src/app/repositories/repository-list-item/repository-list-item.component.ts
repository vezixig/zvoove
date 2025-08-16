import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-repository-list-item',
  imports: [CardModule],
  templateUrl: './repository-list-item.component.html',
  styleUrl: './repository-list-item.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RepositoryListItemComponent {
  readonly name = input('repository name');
  readonly description = input(
    'orem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd '
  );
  readonly starCount = input(2);
  readonly primaryLanguage = input('TypeScript');
}
