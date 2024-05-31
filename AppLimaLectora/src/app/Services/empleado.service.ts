import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseApi } from '../Interfaces/response-api';
import { Empleado } from '../Interfaces/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  private readonly urlApi = `${environment.endpoint}Empleado/`

  constructor(private http: HttpClient) { }

  listar():Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlApi}Listar`)
  }

  registrar(empleado:Empleado):Observable<ResponseApi>{
    return this.http.post<ResponseApi>(`${this.urlApi}Registrar`, empleado)
  }

  buscar(id:number):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlApi}Buscar/${id}`)
  }

  actualizar(empleado:Empleado):Observable<ResponseApi>{
    return this.http.put<ResponseApi>(`${this.urlApi}Actualizar`, empleado)
  }

  eliminar(id:number):Observable<ResponseApi>{
    return this.http.delete<ResponseApi>(`${this.urlApi}Eliminar/${id}`)
  }

}
