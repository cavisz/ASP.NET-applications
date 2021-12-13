<%@page contentType="text/html" language="java" pageEncoding="UTF-8" %>
<%@page import="net.sf.jasperreports.view.JasperViewer"%>
<%@page import="java.sql.Statement"%>
<%@page import="java.io.PrintWriter"%>
<%@page import="java.io.StringWriter"%>
<%@page import="net.sf.jasperreports.engine.util.JRLoader"%>
<%@page import="java.io.File"%>
<%@page import="net.sf.jasperreports.engine.*"%>
<%@page import="java.sql.DriverManager"%>
<%@page import="java.sql.Connection"%>
<%@page import="java.sql.ResultSet"%>
<%@page import="java.util.Map"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Locale"%>
<%@page import="java.sql.SQLException"%>
<%@page import="db.Conexao"%>
<%
            //Integer pTipo = Integer.parseInt(request.getParameter("pTipo"));
            //String pOrgaoDescricao = new String(request.getParameter("pOrgaoDescricao").getBytes("ISO-8859-1"), "UTF-8");
            String pTipo = new String(request.getParameter("pTipo").getBytes("ISO-8859-1"), "UTF-8");

            String pCondicao = "";


            if (pTipo != "") {
                pCondicao += "  WHERE pessoal_c.PESS_STR_NOME LIKE '%" + pTipo+"%'";
            }

            String query = "SELECT depto_c.DEPA_STR_SIGLA," +
                                   " local_c.LOCA_STR_SIGLA," +
                                   " pessoal_c.PESS_INT_CODIGO," +
                                   " pessoal_c.PESS_STR_EMAIL," +
                                   " pessoal_c.PESS_STR_RAMAL," +
                                   " pessoal_c.PESS_STR_NOME" +
                                   " FROM pessoal_c" +
                                   " INNER JOIN depto_c ON depto_c.DEPA_INT_CODIGO = pessoal_c.FK_DEPA_INT_CODIGO" +
                                   " INNER JOIN local_c ON local_c.LOCA_INT_CODIGO = pessoal_c.FK_LOCA_INT_CODIGO" + pCondicao +
                                   " ORDER BY PESS_STR_NOME";


            try {

                Connection conn = Conexao.getConexao();

                Statement stm = conn.createStatement();
                ResultSet rs = stm.executeQuery(query);

                JRResultSetDataSource jrRS = new JRResultSetDataSource(rs);

                // parametros do relatorio
                //File logoPMC = new File(application.getRealPath("/WEB-INF/imagens/LOGOPMC.jpg"));
                //File logoIMAP = new File(application.getRealPath("/WEB-INF/imagens/logoimap3.png"));
                HashMap parameters = new HashMap();
                
                Locale localeBrasil = new Locale("pt", "BR");
                parameters.put("REPORT_LOCALE", localeBrasil);

                // parameters.put("logoPMC", logoPMC);
                //parameters.put("logoIMAP", logoIMAP);
                //parameters.put("pOrgaoDescricao", pOrgaoDescricao);
                //parameters.put("pNivelDescricao", pNivelDescricao);

                // lendo arquivo jasper
                File reportFile = new File(application.getRealPath("/WEB-INF/relatorios/report1.jasper"));

                byte[] bytes = JasperRunManager.runReportToPdf(reportFile.getPath(), parameters, jrRS);
                response.setContentType("application/pdf");
                response.setContentLength(bytes.length);
                ServletOutputStream ouputStream = response.getOutputStream();
                ouputStream.write(bytes, 0, bytes.length);
                ouputStream.flush();
                ouputStream.close();

            } catch (Exception e) {
                e.printStackTrace();
                out.println("ERRO: " + e.getMessage());
            }

%>
