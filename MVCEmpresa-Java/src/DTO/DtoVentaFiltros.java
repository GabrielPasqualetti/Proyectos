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
public class DtoVentaFiltros {
     private String cliente;
    private String nombre;
    private double importe;

    public DtoVentaFiltros(String cliente, String nombre, double importe) {
        this.cliente = cliente;
        this.nombre = nombre;
        this.importe = importe;
    }

    public String getCliente() {
        return cliente;
    }

    public String getNombre() {
        return nombre;
    }

    public double getImporte() {
        return importe;
    }
    
    
}
