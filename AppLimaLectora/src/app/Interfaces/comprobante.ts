export interface Comprobante {
    idComprobante:number,
    idCliente?:number,
    nombreCliente:string,
    idEmpleado?:number,
    nombreEmpleado:string,
    idMetodoPago?:number,
    descripcionMetodoPago:string,
    total:number,
    fechaVenta?:string
}
