import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface GrupoMusica {
  id: number;
  nombre: string;
  genero: string;
  numeroIntegrantes: number;
  fechaFormacion: string;
  activo: boolean;
}

export interface GruposMusicaPaginados {
  grupos: GrupoMusica[];
  totalRegistros: number;
}

@Injectable({ providedIn: 'root' })
export class GruposMusicaService {
  private apiUrl = 'https://localhost:7169/api/gruposmusica';

  constructor(private http: HttpClient) {}

  getGruposMusica(
    genero: string,
    nombre: string,
    numeroPagina: number = 1,
    tamanoPagina: number = 5
  ): Observable<GruposMusicaPaginados> {
    let params = new HttpParams();
    if (genero) params = params.set('genero', genero);
    if (nombre) params = params.set('nombre', nombre);
    params = params.set('numeroPagina', numeroPagina.toString());
    params = params.set('tamañoPagina', tamanoPagina.toString());
    return this.http.get<GruposMusicaPaginados>(this.apiUrl, { params });
  }

  getGrupoMusica(id: number): Observable<GrupoMusica> {
    return this.http.get<GrupoMusica>(`${this.apiUrl}/${id}`);
  }

  addGrupoMusica(grupoMusica: GrupoMusica): Observable<GrupoMusica> {
    return this.http.post<GrupoMusica>(this.apiUrl, grupoMusica);
  }

  updateGrupoMusica(id: number, grupoMusica: GrupoMusica): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, grupoMusica);
  }

  deleteGrupoMusica(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
