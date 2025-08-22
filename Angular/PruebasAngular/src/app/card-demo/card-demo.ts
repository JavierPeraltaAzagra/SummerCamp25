import { Component } from '@angular/core';

@Component({
  selector: 'pr-card-demo',
  standalone: false,
  templateUrl: './card-demo.html',
  styleUrl: './card-demo.css'
})
export class CardDemo {
  title: string = 'Prueba Bootstrap';
  description: string = 'Esta es una tarjeta de ejemplo para mostrar contenido.';
  imageUrl: string = 'https://upload.wikimedia.org/wikipedia/commons/5/5b/Insert_image_here.svg';

  constructor() {
    // Inicialización si es necesario
  }
}
