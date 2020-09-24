
package Controlador;

import Modelo.Oferta;
import Modelo.Producto;
import Modelo.dtoOferta;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;



public class Gestor {
    
    private Connection con; 
    private String CONN = "jdbc:sqlserver://LAPTOP-D2H1GFR3\\GABIPC:1433;databaseName=Supermercado";
    private String USER = "sa";
    private String PASS= "juegasql1994";
    
    public void abrirConexion(){
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            con = DriverManager.getConnection(CONN, USER, PASS);
        } 
    catch (Exception exc) {
            exc.printStackTrace();
        }
    }
    
    private void cerrarConexion() {
        try {
            if (con != null && !con.isClosed()) {
                con.close();
            }
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
    }
    
    public ArrayList<Producto> ObtenerProducto(){
        ArrayList<Producto> lista = new ArrayList<>();
        
        try {
            abrirConexion();
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT * FROM Producto");
            while(rs.next()){
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                
                Producto prod = new Producto(id,nombre);
                lista.add(prod);
            }
            rs.close();
            st.close();
           
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
        finally{
            cerrarConexion();
        }
        return lista;
    }
    
    public void agregarOferta(Oferta of){
        
        try {
            abrirConexion();
            PreparedStatement ps = con.prepareStatement("INSERT INTO Oferta VALUES (?,?,?,?,?,?)");
            ps.setInt(1, of.getProducto().getId());
            ps.setDouble(2, of.getPrecioNormal());
            ps.setDouble(3, of.getPrecioOferta());
            ps.setInt(4,of.getStockDisponible());
            ps.setString(5, of.getFechaInicioOferta());
            ps.setInt(6, of.getDiasVigencia());
            ps.executeUpdate();
            
            ps.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
        finally{
            cerrarConexion();
        }
    }
    
    public ArrayList<dtoOferta> obtenerOfertaConDto(){
        ArrayList<dtoOferta> lista = new ArrayList<>();
        
        try {
            abrirConexion();
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT p.nombre, o.precioNormal, o.precioOferta, o.stockDisponible, o.fechaInicioOferta, o.diasVigencia\n" +
                                           "FROM Oferta o JOIN Producto p ON o.idProducto=p.id");
            while(rs.next()){
                String producto = rs.getString(1);
                double precioInicial = rs.getDouble(2);
                double precioOferta = rs.getDouble(3);
                int stock = rs.getInt(4);
                String fecha = rs.getString(5);
                int dia = rs.getInt(6);
                
                dtoOferta dtoOfer = new dtoOferta(producto, precioInicial, precioOferta, stock, fecha, dia);
                lista.add(dtoOfer);
            }
            rs.close();
            st.close();
           
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
        finally{
            cerrarConexion();
        }
        return lista;
    }
    
    public int calcularMontoPerdido(int id){
        int total = 0;
        
        try {
            abrirConexion();
            String sql = "SELECT sum((o.precioNormal-o.precioOferta)*o.stockDisponible) 'Monto que no se ganó'\n" +
                        "FROM Oferta o JOIN Producto p ON o.idProducto=p.id\n" +
                        "WHERE p.id = ? ";
            
            PreparedStatement ps = con.prepareStatement(sql);
            ps.setInt(1, id );
            ResultSet rs = ps.executeQuery();
            rs.next();
            total = rs.getInt(1);
            
            rs.close();
            ps.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
        finally{
            cerrarConexion();
        }
        return total;
    }
    
    public int CantidadOfertaMas5Dias(){
        int cant=0;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT count(*) 'Cantidad de artículos ofertados por más de 5 días'\n" +
                                            "FROM Oferta o JOIN Producto p ON o.idProducto=p.id\n" +
                                            "WHERE o.diasVigencia > 5 ");
            rs.next();
            cant = rs.getInt(1);
            
            rs.close();
            st.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
        finally{
            cerrarConexion();
        }
        return cant;
    }
}
