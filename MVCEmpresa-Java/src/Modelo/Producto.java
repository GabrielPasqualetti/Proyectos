
package Modelo;


public class Producto {
    
    private int codigo;
    private String nombre;
    private double precio; 

    

    public int getCodigo() {
        return codigo;
    }

    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public double getPrecio() {
        return precio;
    }

    public void setPrecio(double precio) {
        this.precio = precio;
    }

   public Producto() {
        codigo=0;
        nombre="";
        precio=0;
    }

    public Producto(int codigo, String nombre, double precio) {
        this.codigo = codigo;
        this.nombre = nombre;
        this.precio = precio;
    }

    
    @Override
    public String toString() {
        return  nombre + ", precio: $" + String.format("%5.2f",precio);
    }
    
}
