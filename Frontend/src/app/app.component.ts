import { Component, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ButtonModule, MenubarModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  private readonly router = inject(Router);
  title = 'Frontend';

  navigate(event: any) {
    const label = event.item.label;
    if (label === 'Repositories') {
      this.router.navigate(['/repository']);
    } else if (label === 'Languages') {
      this.router.navigate(['/language']);
    }
  }
}
