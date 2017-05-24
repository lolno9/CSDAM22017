package ProcessData;

/**
 * @author Begoña
 *
 */
public class Tanc {
	/**
	 * @param nom
	 * @param litres
	 */
	public Tanc(String nom, Double litres) {
		this.nom = nom;
		this.litres = litres;
	}
	private String nom;
	private Double litres;
	/**
	 * @return
	 */
	public String getNom() {
		return nom;
	}
	/**
	 * @param nom
	 */
	public void setNom(String nom) {
		this.nom = nom;
	}
	/**
	 * @return
	 */
	public Double getLitres() {
		return litres;
	}
	/**
	 * @param litres
	 */
	public void setLitres(double litres) {
		this.litres -= litres;
	}
	
}
