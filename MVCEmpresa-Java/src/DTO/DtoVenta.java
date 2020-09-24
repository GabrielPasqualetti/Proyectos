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
public class DtoVenta {
    private String cliente;
    private int cantidad;
    private String producto;
    private double precio;

    public DtoVenta(String cliente, int cantidad, String producto, double precio) {
        this.cliente = cliente;
        this.cantidad = cantidad;
        this.producto = producto;
        this.precio = precio;
    }

    public String getCliente() {
        return cliente;
    }

    public int getCantidad() {
        return cantidad;
    }

    public String getProducto() {
        return producto;
    }

    public double getPrecio() {
        return precio;
    }
    
}
