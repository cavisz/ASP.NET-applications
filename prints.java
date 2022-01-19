import java.util.Locale;

public class Main {

	public static void main(String[] args) {
		int y =32;
		double x =10.335784;
		String nome = "Maria";
		int idade = 31;
		double renda = 4000.0;
		
		System.out.println(y);
		System.out.println(x);
		
		/**   controlar saida */
		
		System.out.printf("%.2f%n", x);
		System.out.print("bodia");
		
		/** definir a locaizar e cacater unicode da aplicacao */
		
		Locale.setDefault(Locale.US);
		System.out.printf("%.2f%n", x);
		
		/** printar com a chamada de println */
		
		System.out.println("RESULTADO = " + x + " METROS");
		
		/** para printar %f = ponto flutuante
				%d = inteiro
				%s = texto
				%n = quebra de linha */
		
		System.out.printf("%s tem %d anos e ganha R$ %.2f reais%n", nome, idade, renda);
		
		
	}

}
