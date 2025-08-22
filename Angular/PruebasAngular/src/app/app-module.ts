import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Welcome } from './welcome/welcome';
import { CounterDemo } from './counter-demo/counter-demo';
import { CardDemo } from './card-demo/card-demo';
import { Peliculas } from './peliculas/peliculas';

@NgModule({
  declarations: [
    App,
    Welcome,
    CounterDemo,
    CardDemo,
    Peliculas
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
