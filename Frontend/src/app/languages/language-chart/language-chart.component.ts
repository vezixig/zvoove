import {
  ChangeDetectionStrategy,
  Component,
  inject,
  computed,
} from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { RepositoriesStore } from '../../state/repositories.store';

@Component({
  selector: 'app-language-chart',
  imports: [ChartModule],
  templateUrl: './language-chart.component.html',
  styleUrl: './language-chart.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LanguageChartComponent {
  private readonly repositoriesStore = inject(RepositoriesStore);

  chartData = computed(() => {
    const langs = this.repositoriesStore.trendingLanguages() ?? [];
    return {
      labels: langs.map((l) => l.name),
      datasets: [
        {
          data: langs.map((l) => l.repositoryCount),
        },
      ],
    };
  });

  chartOptions = {
    responsive: true,
    plugins: {
      legend: {
        display: false,
        position: 'bottom',
      },
    },
  };
}
