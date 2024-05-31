import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Componentes para trabajar con formularios reactivos
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

//Componentes de Angular Material
import { MatCardModule } from '@angular/material/card'; //Para trabajar con tarjetas
import { MatInputModule } from '@angular/material/input'; //Para trabajar con inputs
import { MatSelectModule } from '@angular/material/select'; //Para trabajar con los select
import { MatProgressBarModule } from '@angular/material/progress-bar'; //Barras de progreso como loading
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'; //Cuando se esta cargando
import { MatGridListModule } from '@angular/material/grid-list'; //Para trabajar con filas y columnas

import { LayoutModule } from '@angular/cdk/layout'; //Para trabajar con contenedores laterales
import { MatToolbarModule } from '@angular/material/toolbar'; //Para mostrar u ocultar el contenedor lateral
import { MatSidenavModule } from '@angular/material/sidenav'; //
import { MatButtonModule } from '@angular/material/button'; //Para trabajar con boton
import { MatIconModule } from '@angular/material/icon'; //Para trabajar con los iconos de angular
import { MatListModule } from '@angular/material/list'; //Para trabajar con listas de angular

import { MatTableModule } from '@angular/material/table';  //Para trabajar con tablas
import { MatPaginatorModule } from '@angular/material/paginator'; //Para trabajar con paginacion de tablas
import { MatDialogModule } from '@angular/material/dialog'; //Para trabajar con los dialogos parecidos a los alert
import { MatSnackBarModule } from '@angular/material/snack-bar'; //Para mostrar pequeñas alertas
import { MatTooltipModule } from '@angular/material/tooltip'; //Para mostrar diminutos mensajes al hacer hover
import { MatAutocompleteModule } from '@angular/material/autocomplete'; //Para el autocompletado
import { MatDatepickerModule } from '@angular/material/datepicker'; //Para trabajar con calendarios

import { MatNativeDateModule } from '@angular/material/core'; //Nos permite trabajar con las fechas
import { MomentDateModule } from '@angular/material-moment-adapter'; //Cambiar el formato de las fechas



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    LayoutModule,
    MatCardModule,
    MatInputModule,
    MatSelectModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatGridListModule,
    MatToolbarModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatSnackBarModule,
    MatTooltipModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MomentDateModule
  ],
  providers:[
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class SharedModule { }
