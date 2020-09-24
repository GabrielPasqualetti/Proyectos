package Vistas;

import Controlador.GestorDB;
import Modelo.Producto;


public class VentanasDB {

    public static void main(String[] args) {
        Producto prod = new Producto();
        prod.setNombre("lapiz");
        prod.setPrecio(100);
        
        GestorDB gestor = new GestorDB();
        gestor.agregarProducto(prod);

    }
    
}
