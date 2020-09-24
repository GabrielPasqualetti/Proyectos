
package Modelo;


public class Venta {
    private int id;
    private String  cliente;
    private int cantidad;
    private Producto producto;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCliente() {
        return cliente;
    }

    public void setCliente(String cliente) {
        this.cliente = cliente;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }

    public Venta(int id, String cliente, int cantidad, Producto producto) {
        this.id = id;
        this.cliente = cliente;
        this.cantidad = cantidad;
        this.producto = producto;
    }


    @Override
    public String toString() {
        return "Venta{" + "id=" + id + ", cliente=" + cliente + ", cantidad=" + cantidad + ", producto=" + producto + '}';
    }
    
}
