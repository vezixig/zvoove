import { inject } from '@angular/core';
import {
  patchState,
  signalStore,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';
import { RepositoriesService } from '../repositories/repositories.service';
import { Repository } from '../repositories/repository.model';

type RepositoriesState = {
  repositories: Repository[] | undefined;
  hasError: boolean;
  isLoading: boolean;
};

const initialState: RepositoriesState = {
  hasError: false,
  isLoading: true,
  repositories: undefined,
};

export const RepositoriesStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store) => {
    const repositoriesService = inject(RepositoriesService);

    return {
      async refresh() {
        try {
          patchState(store, () => ({
            repositories: undefined,
            isLoading: true,
          }));
          const repositories = await firstValueFrom(
            repositoriesService.getTrending()
          );
          patchState(store, () => ({ repositories }));
        } catch (error) {
          patchState(store, () => ({ hasError: true }));
        } finally {
          patchState(store, () => ({ isLoading: false }));
        }
      },
    };
  }),
  withHooks({
    async onInit(store) {
      store.refresh();
    },
  })
);
