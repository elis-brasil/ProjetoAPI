import { Component } from '@angular/core';
import { Components } from './Components/components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Components],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent {
  title = 'produtos-front';
}