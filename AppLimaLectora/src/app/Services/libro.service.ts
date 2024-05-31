import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi } from '../Interfaces/response-api';
import { Libro } from '../Interfaces/libro';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LibroService {

  private readonly urlApi = `${environment.endpoint}Libro/`

  constructor(private http:HttpClient) { }

  listar():Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlApi}Lista`)
  }

  registrar(request:Libro):Observable<ResponseApi>{
    return this.http.post<ResponseApi>(`${this.urlApi}Registrar`, request)
  }

  buscar(id:number):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlApi}Buscar/${id}`)
  }

  actualizar(request:Libro):Observable<ResponseApi>{
    return this.http.put<ResponseApi>(`${this.urlApi}Actualizar`, request)
  }

  eliminar(id:number):Observable<ResponseApi>{
    return this.http.delete<ResponseApi>(`${this.urlApi}Eliminar/${id}`)
  }

}
