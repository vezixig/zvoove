import {
  ChangeDetectionStrategy,
  Component,
  inject,
  model,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, filter, tap } from 'rxjs/operators';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { RepositoriesStore } from '../../state/repositories.store';

@Component({
  selector: 'app-search-bar',
  imports: [FormsModule],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchBarComponent {
  private readonly repositoriesStore = inject(RepositoriesStore);

  private readonly searchTermSubject = new Subject<string>();
  readonly searchTerm = model('');

  constructor() {
    this.searchTermSubject
      .pipe(
        takeUntilDestroyed(),
        debounceTime(1000),
        filter((term) => term.length >= 3),
        tap((term) => {
          this.repositoriesStore.refresh(term);
          this.searchTerm.set(term);
        })
      )
      .subscribe();
  }

  onSearchChange(value: string) {
    this.searchTermSubject.next(value);
  }
}
