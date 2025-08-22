import { Component, signal } from '@angular/core';

@Component({
  selector: 'pr-root',
  template: `<div>
              <h1>{{ title }}</h1>
              <div>Mi primer componente</div>
              <pr-welcome></pr-welcome>
              <pr-counter-demo></pr-counter-demo>
              <pr-card-demo></pr-card-demo>
              <pr-peliculas></pr-peliculas>
            </div>`,
  standalone: false,
})
export class App {
  title = 'Prueba Angular';
}
