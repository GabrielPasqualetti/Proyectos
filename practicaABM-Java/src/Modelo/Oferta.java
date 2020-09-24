
package Modelo;


public class Oferta {
    
    private int id;
    private Producto producto;
    private double precioNormal;
    private double precioOferta;
    private int stockDisponible;
    private String fechaInicioOferta;
    private int diasVigencia;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setIdProducto(Producto producto) {
        this.producto = producto;
    }

    public double getPrecioNormal() {
        return precioNormal;
    }

    public void setPrecioNormal(double precioNormal) {
        this.precioNormal = precioNormal;
    }

    public double getPrecioOferta() {
        return precioOferta;
    }

    public void setPrecioOferta(double precioOferta) {
        this.precioOferta = precioOferta;
    }

    public int getStockDisponible() {
        return stockDisponible;
    }

    public void setStockDisponible(int stockDisponible) {
        this.stockDisponible = stockDisponible;
    }

    public String getFechaInicioOferta() {
        return fechaInicioOferta;
    }

    public void setFechaInicioOferta(String fechaInicioOferta) {
        this.fechaInicioOferta = fechaInicioOferta;
    }

    public int getDiasVigencia() {
        return diasVigencia;
    }

    public void setDiasVigencia(int diasVigencia) {
        this.diasVigencia = diasVigencia;
    }

    public Oferta(int id, Producto producto, double precioNormal, double precioOferta, int stockDisponible, String fechaInicioOferta, int diasVigencia) {
        this.id = id;
        this.producto = producto;
        this.precioNormal = precioNormal;
        this.precioOferta = precioOferta;
        this.stockDisponible = stockDisponible;
        this.fechaInicioOferta = fechaInicioOferta;
        this.diasVigencia = diasVigencia;
    }

    @Override
    public String toString() {
        return "Oferta{" + "id=" + id + ", idProducto=" + producto + ", precioNormal=" + precioNormal + ", precioOferta=" + precioOferta + ", stockDisponible=" + stockDisponible + ", fechaInicioOferta=" + fechaInicioOferta + ", diasVigencia=" + diasVigencia + '}';
    }
    
    
}
