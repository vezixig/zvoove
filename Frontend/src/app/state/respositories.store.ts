import { inject } from '@angular/core';
import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';
import { RepositoriesService } from '../repositories/repositories.service';
import { Repository } from '../repositories/repository.model';
import { Language } from '../languages/language.model';

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
  withComputed(({ repositories }) => ({
    /**
     * Get the top programming languages used in the repositories.
     * @returns An array of languages with their repository count.
     */
    topLanguages: () => {
      if (!repositories()) return [];
      const languageCount: Record<string, number> = {};
      for (const repo of repositories()!) {
        const lang = repo.primaryLanguage ?? 'Unknown';
        languageCount[lang] = (languageCount[lang] || 0) + 1;
      }
      return Object.entries(languageCount)
        .map(
          ([name, repositoryCount]) => ({ name, repositoryCount } as Language)
        )
        .sort((a, b) => b.repositoryCount - a.repositoryCount);
    },
  })),
  withHooks({
    async onInit(store) {
      store.refresh();
    },
  })
);
