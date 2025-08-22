import { Component } from '@angular/core';

@Component({
  selector: 'pr-counter-demo',
  standalone: false,
  templateUrl: './counter-demo.html',
  styleUrl: './counter-demo.css'
})
export class CounterDemo {
  contador: number = 0;
  incrementar(){
    this.contador++;
  }
  decrementar(){
    this.contador--;
  }
  reiniciar(){
    this.contador = 0;
  }
}
