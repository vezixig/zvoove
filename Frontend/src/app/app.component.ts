import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { SearchBarComponent } from './shared/search-bar/search-bar.component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ButtonModule, MenubarModule, SearchBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Frontend';
}
