import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Language } from '../language.model';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-language-list-item',
  imports: [CardModule],
  templateUrl: './language-list-item.component.html',
  styleUrl: './language-list-item.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LanguageListItemComponent {
  readonly language = input.required<Language>();
}
