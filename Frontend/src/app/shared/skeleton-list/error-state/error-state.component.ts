import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-error-state',
  imports: [CardModule],
  templateUrl: './error-state.component.html',
  styleUrl: './error-state.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ErrorStateComponent {
  readonly title = input('Error');
  readonly message = input(
    'An unexpected error occurred. Please try again later.'
  );
}
