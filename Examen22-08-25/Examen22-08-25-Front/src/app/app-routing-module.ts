import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaGrupos } from './lista-grupos/lista-grupos';
import { DetallesGrupos } from './detalles-grupos/detalles-grupos';

const routes: Routes = [
  { path: '', component: ListaGrupos },
  { path: 'grupo/:id', component: DetallesGrupos },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
