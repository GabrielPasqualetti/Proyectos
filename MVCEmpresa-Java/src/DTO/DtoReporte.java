/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DTO;

/**
 *
 * @author rgpas
 */
public class DtoReporte {
    private String producto;
    private int Cantidad;

    public DtoReporte(String producto, int Cantidad) {
        this.producto = producto;
        this.Cantidad = Cantidad;
    }

    public String getProducto() {
        return producto;
    }

    public int getCantidad() {
        return Cantidad;
    }
    
    
}
