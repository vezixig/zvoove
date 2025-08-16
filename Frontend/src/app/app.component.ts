import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { SkeletonListComponent } from './shared/skeleton-list/skeleton-list.component';
import { RepositoryListItemComponent } from './repositories/repository-list-item/repository-list-item.component';
@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    ButtonModule,
    MenubarModule,
    SkeletonListComponent,
    RepositoryListItemComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Frontend';
}
