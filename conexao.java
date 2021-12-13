package db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Conexao {

    /*
    private static final String url = "jdbc:mysql://dbprdestagio.curitiba.pr.gov.br:3306/estagio";
    private static final String driver = "com.mysql.jdbc.Driver";
    private static final String usuario = "estagio";
    private static final String senha = "6LVwxL%b";
    */
    
    private static final String url = "jdbc:mysql://localhost:3306/imap";
    private static final String driver = "com.mysql.jdbc.Driver";
    private static final String usuario = "root";
    private static final String senha = "";
    
    
    private static Connection conn = null;

    //conectar no banco
    public static Connection getConexao() throws Exception {
        
        try {
            // carregamento do driver
            Class.forName(driver);
            // Obtendo a conexao
            conn = DriverManager.getConnection(url, usuario, senha);

        } catch (ClassNotFoundException e) {
            System.out.println("Driver nao encontrado: " + e);
        } catch (SQLException e) {
            System.out.println("Erro ao obter a conexão: " + e);
        }
        return conn;
    }

    //fecha conexao
    public void close() throws SQLException {
        try {
            if (conn != null) {
                conn.close();
            }
        } catch (Exception e) {
            System.out.println("Não foi possível fechar a conexão com o banco: " + e);
        }
    }
}
