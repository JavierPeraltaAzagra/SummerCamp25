import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GrupoMusica, GruposMusicaPaginados, GruposMusicaService } from '../Servicios/gruposMusica.service';

@Component({
  selector: 'app-lista-grupos',
  standalone: false,
  templateUrl: './lista-grupos.html',
  styleUrl: './lista-grupos.css'
})
export class ListaGrupos implements OnInit {
  irPrimeraPagina(): void {
    if (this.paginaActual !== 1) {
      this.paginaActual = 1;
      this.cargarGrupos();
    }
  }

  irUltimaPagina(): void {
    if (this.paginaActual !== this.totalPaginas) {
      this.paginaActual = this.totalPaginas;
      this.cargarGrupos();
    }
  }
  resetFiltros(): void {
    this.nombre = '';
    this.genero = '';
    this.paginaActual = 1;
    this.cargarGrupos();
  }
  gruposMusica: GrupoMusica[] = [];
  totalRegistros: number = 0;
  nombre: string = '';
  genero: string = '';
  paginaActual: number = 1;
  tamanoPagina: number = 10;
  totalPaginas: number = 1;

  constructor(private gruposMusicaService: GruposMusicaService, private router: Router) {}
  irADetalleGrupo(grupo: GrupoMusica): void {
    this.router.navigate(['/grupo', grupo.id]);
  }

  ngOnInit(): void {
    this.cargarGrupos();
  }

  cargarGrupos(): void {
    this.gruposMusicaService.getGruposMusica(this.genero, this.nombre, this.paginaActual, this.tamanoPagina)
      .subscribe((resp: GruposMusicaPaginados) => {
        this.gruposMusica = resp.grupos;
        this.totalRegistros = resp.totalRegistros;
        this.totalPaginas = this.totalRegistros > 0 ? Math.ceil(this.totalRegistros / this.tamanoPagina) : 1;
      });
  }

  buscar(): void {
    this.paginaActual = 1;
    this.cargarGrupos();
  }

  paginaSiguiente(): void {
    if ((this.paginaActual * this.tamanoPagina) < this.totalRegistros) {
      this.paginaActual++;
      this.cargarGrupos();
    }
  }

  paginaAnterior(): void {
    if (this.paginaActual > 1) {
      this.paginaActual--;
      this.cargarGrupos();
    }
  }
}
