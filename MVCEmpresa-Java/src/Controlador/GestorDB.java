
package Controlador;


import DTO.DtoReporte;
import DTO.DtoVenta;
import DTO.DtoVentaFiltros;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.sql.SQLException;
import Modelo.Producto;
import Modelo.Venta;

public class GestorDB {
    
    private Connection con;
    private String CONN = "jdbc:sqlserver://LAPTOP-D2H1GFR3\\GABIPC:1433;databaseName=Empresa";
    private String USER= "sa";
    private String PASS= "juegasql1994";
    
    public void abrirConeccion(){
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
    
    public void agregarProducto(Producto p){
        
        try {
            
            abrirConeccion();
            
            PreparedStatement ps = con.prepareStatement("INSERT INTO Productos VALUES (?,?)");
            ps.setString(1,p.getNombre());
            ps.setDouble(2,p.getPrecio());
            ps.executeUpdate();
            
            ps.close();
           
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
       finally
        {
            cerrarConexion();
        }
    }
    
    public ArrayList<Producto> obtenerProducto(){
        
        ArrayList<Producto> lista  = new ArrayList<>();
        
        try {
            abrirConeccion();
            
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT * FROM Productos");
            
            while(rs.next()){
                int codigo = rs.getInt("codigo");
                String nombre = rs.getString("nombre");
                double precio = rs.getDouble("precio");
                
                Producto prod = new Producto(codigo, nombre, precio);
//                prod.setCodigo(codigo);
//                prod.setNombre(nombre);
//                prod.setPrecio(predio);
                lista.add(prod);
            }
            rs.close();
            st.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
       finally
        {
            cerrarConexion();
        }
        return lista;
    }
    
    public void agregarVenta(Venta v){
        
        try {
            abrirConeccion();
            PreparedStatement ps = con.prepareStatement("INSERT INTO Ventas VALUES (?,?,?)");
            ps.setString(1,v.getCliente());
            ps.setInt(2,v.getCantidad());
            ps.setInt(3,v.getProducto().getCodigo());
            ps.executeUpdate();
            ps.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
       finally
        {
            cerrarConexion();
        }
    }
    
//     public ArrayList<Venta> obtenerVentas(){
//        
//        ArrayList<Venta> lista  = new ArrayList<>();
//        
//        try {
//            abrirConeccion();
//            Statement st = con.createStatement();
//            ResultSet rs =st.executeQuery("SELECT v.id, v.cliente, v.cantidad, p.nombre, p.precio FROM Ventas v JOIN Productos p ON v.codProducto=p.codigo");
//            while(rs.next()){
//                
//                int idVenta = rs.getInt("id");
//                String cliente = rs.getString("cliente");
//                int cantidad = rs.getInt("cantidad");
//                String nombreproducto = rs.getString("nombre");
//                double precioproducto= rs.getDouble("precio");
//                
//                Producto prod = new Producto();
//                prod.setNombre(nombreproducto);
//                prod.setPrecio(precioproducto);
//                
//                Venta venta = new Venta(idVenta, cliente, cantidad, prod);
//                
//                lista.add(venta);
//            }
//           rs.close();
//        } 
//        catch (Exception exc) {
//            exc.printStackTrace();
//        }
//       finally
//        {
//            cerrarConexion();
//        }
//        return lista;
//    }
     
    public ArrayList<DtoVenta> obtenerVentaConDto(){
      ArrayList<DtoVenta> lista  = new ArrayList<DtoVenta>();
      
      try {
          abrirConeccion();
          
          Statement st = con.createStatement();
          ResultSet rs = st.executeQuery("SELECT v.id, v.cliente, v.cantidad, p.nombre, p.precio FROM Ventas v JOIN Productos p ON v.codProducto=p.codigo");
          
          while(rs.next()){
              int idVenta = rs.getInt("id");
              String cliente = rs.getString("cliente");
              int cantidad = rs.getInt("cantidad");
              String nombreProducto = rs.getString("nombre");
              double precioProducto= rs.getDouble("precio");
              DtoVenta venta = new DtoVenta(cliente, cantidad, nombreProducto, precioProducto);
              lista.add(venta);
            }
            rs.close();
            st.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
       finally
        {
            cerrarConexion();
        }
        return lista;
    }
     
    public ArrayList<DtoReporte> cantidadVentasPorProducto()
    {
      ArrayList<DtoReporte> lista  = new ArrayList<>();
      
        try {
            abrirConeccion();
            
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT count(*) 'Cantidad', p.nombre 'Producto' "
                                        + "FROM Ventas v JOIN Productos p ON v.codProducto = p.codigo "
                                        + "group by p.nombre");
            while(rs.next()){
                int cantidad = rs.getInt("Cantidad");
                String nombreProducto = rs.getString("Producto");
                DtoReporte Dto = new DtoReporte(nombreProducto, cantidad);
                lista.add(Dto);
            }
            rs.close();
            st.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
       finally
        {
            cerrarConexion();
        }
        return lista;
    }
    
    public double facturacionTotal(){
        double facturacion = 0;
        
        try {
            abrirConeccion();
            
            Statement st = con.createStatement();
            ResultSet rs =st.executeQuery("SELECT sum(v.cantidad * p.precio)"
                                        + "FROM Ventas v JOIN Productos p ON v.codProducto=p.codigo ");
            rs.next();
              facturacion = rs.getDouble(1);
            rs.close();
            st.close();
            } 
        catch (Exception exc) {
                exc.printStackTrace();
            }
        finally{
                cerrarConexion();
            }
        return facturacion;
    }
     
    public DtoVenta ventaDeMayorCantidadDeProducto(){
     DtoVenta dto = null;
     
     try {
            abrirConeccion();

            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT top 1 v.cliente, v.cantidad, p.nombre, p.precio "
                                         + "FROM Ventas v JOIN Productos p ON v.codProducto = p.codigo "
                                         + "order by cantidad desc");
            rs.next();
            String cliente = rs.getString("cliente");
            int cantidad = rs.getInt("cantidad");
            String nombre = rs.getString("nombre");
            double precio = rs.getDouble("precio");
            
            dto = new DtoVenta(cliente, cantidad, nombre, precio);
            rs.close();
            st.close();
        } 
        catch (Exception exc) {
            exc.printStackTrace();
        }
        finally
         {
            cerrarConexion();
         }
         return dto;
   }
    
   public ArrayList<DtoVentaFiltros> obtenerVentasPorFilroImporteTotal(double importe, String nombre){
      ArrayList<DtoVentaFiltros> lista  = new ArrayList<DtoVentaFiltros>();
      
      try {
          abrirConeccion();
          
          String sql = "SELECT v.cliente, p.nombre, v.cantidad * p.precio 'IMPORTE' " +
                                        " FROM Ventas v JOIN Productos p ON v.codProducto = p.codigo " +
                                        " WHERE v.cantidad * p.precio > ?  and p.nombre = ?" +
                                        " order by 3 desc ";
          PreparedStatement pt = con.prepareStatement(sql);
          pt.setDouble(1, importe);
          pt.setString(2, nombre);
          ResultSet rs = pt.executeQuery();
          while(rs.next()){

              String nombreProducto = rs.getString("nombre");
              double importeVenta= rs.getDouble("IMPORTE");
              String cliente = rs.getString("cliente");
              DtoVentaFiltros dto = new DtoVentaFiltros(cliente, nombreProducto, importeVenta);
              lista.add(dto);
            }
            rs.close();
            pt.close();
        } 
         catch (Exception exc) {
          exc.printStackTrace();
        }
        finally
        {
            cerrarConexion();
        }
        return lista;
    }
   
}

