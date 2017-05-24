package GetData;

import java.util.Calendar;

/**
 * @author Begoña
 *
 */
public class Data {
	/**
	 * @param nSortidor
	 * @param tipusC
	 * @param horaUs
	 * @param litres
	 */
	public Data(int nSortidor, String tipusC, Calendar horaUs, double litres) {
		this.nSortidor = nSortidor;
		this.tipusC = tipusC;
		this.horaUs = horaUs;
		this.litres = litres;
	}
	private int nSortidor;
	private String tipusC;
	private Calendar horaUs;
	private double litres;
	
	/**
	 * @return
	 */
	public int getnSortidor() {
		return nSortidor;
	}
	/**
	 * @param nSortidor
	 */
	public void setnSortidor(int nSortidor) {
		this.nSortidor = nSortidor;
	}
	/**
	 * @return
	 */
	public String getTipusC() {
		return tipusC;
	}
	/**
	 * @param tipusC
	 */
	public void setTipusC(String tipusC) {
		this.tipusC = tipusC;
	}
	/**
	 * @return
	 */
	public Calendar getHoraUs() {
		
		return horaUs;
	}
	/**
	 * @param horaUs
	 */
	public void setHoraUs(Calendar horaUs) {
		this.horaUs = horaUs;
	}
	/**
	 * @return
	 */
	public double getLitres() {
		return litres;
	}
	/**
	 * @param litres
	 */
	public void setLitres(double litres) {
		this.litres = litres;
	}
	/* (non-Javadoc)
	 * @see java.lang.Object#toString()
	 */
	@SuppressWarnings("static-access")
	public String toString()
	{
		
		return (Integer.toString(nSortidor)+";"+tipusC+";"+horaUs.HOUR+":"+horaUs.MINUTE+";"+redondearDecimales(litres,1));
	}
	/**
	 * @param valorInicial
	 * @param numeroDecimales
	 * @return
	 */
	public static double redondearDecimales(double valorInicial, int numeroDecimales) {
        double parteEntera, resultado;
        resultado = valorInicial;
        parteEntera = Math.floor(resultado);
        resultado=(resultado-parteEntera)*Math.pow(10, numeroDecimales);
        resultado=Math.round(resultado);
        resultado=(resultado/Math.pow(10, numeroDecimales))+parteEntera;
        return resultado;
    }
}
