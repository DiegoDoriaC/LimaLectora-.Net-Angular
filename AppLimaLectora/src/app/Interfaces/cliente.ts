export interface Cliente {
    idCliente:number,
    dni:string,
    nombre:string,
    apellido:string,
    email?:string,
    telefono?:string,
    esActivo:number
}
