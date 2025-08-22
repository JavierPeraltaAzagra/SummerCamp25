import { Component } from '@angular/core';
import { GrupoMusica, GruposMusicaService } from '../Servicios/gruposMusica.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalles-grupos',
  standalone: false,
  templateUrl: './detalles-grupos.html',
  styleUrl: './detalles-grupos.css'
})
export class DetallesGrupos {
  grupo: GrupoMusica | null = null;

  constructor(private route: ActivatedRoute, private gruposMusicaService: GruposMusicaService) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.gruposMusicaService.getGrupoMusica(+id).subscribe((data: GrupoMusica) => {
        this.grupo = data;
      });
    }
  }
}
