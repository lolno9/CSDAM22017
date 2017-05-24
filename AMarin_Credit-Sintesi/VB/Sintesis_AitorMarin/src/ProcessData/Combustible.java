package ProcessData;
import java.util.ArrayList;
import java.util.List;

/**
 * @author Begoña
 *
 */
public class Combustible {

	/**
	 * @param nom
	 * @param tipusC
	 * @param grauContaminacio
	 * @param tanc
	 */
	public Combustible(String nom, String tipusC, int grauContaminacio, Tanc tanc) {
		this.nom = nom;
		this.tipusC = tipusC;
		this.grauContaminacio = grauContaminacio;
		this.setTanc(tanc);
	}

	public Combustible() {
	}

	private String nom;
	private String tipusC;
	private int grauContaminacio;
	private Tanc tanc;
	private List<Proveiidor> _proveidors = new ArrayList<Proveiidor>();
	private List<Double> _litres = new ArrayList<Double>();

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
	public int getGrauContaminacio() {
		return grauContaminacio;
	}

	/**
	 * @param grauContaminacio
	 */
	public void setGrauContaminacio(int grauContaminacio) {
		this.grauContaminacio = grauContaminacio;
	}

	/**
	 * @return
	 */
	public List<Proveiidor> get_proveidors() {
		return _proveidors;
	}

	/**
	 * @param proveidor
	 */
	public void addProveidors(Proveiidor proveidor) {
		this._proveidors.add(proveidor);
	}

	/**
	 * @return
	 */
	public String getTanc() {
		return tanc.getNom();
	}

	/**
	 * @param tanc
	 */
	public void setTanc(Tanc tanc) {
		this.tanc = tanc;
	}

	/**
	 * @return
	 */
	public Double getLitresTotals() {
		Double sum = 0.0;
		for(Double d : this._litres)
		{
			sum+=d;
		}
		return sum;
	}

	/**
	 * @param _litres
	 */
	public void addLitres(Double _litres) {
		this._litres.add(_litres);
	}
	/**
	 * @param lits
	 */
	public void resLitsTanc(Double lits)
	{
		this.tanc.setLitres(lits);
	}
	/**
	 * @return
	 */
	public Double getTancLits()
	{
		return this.tanc.getLitres();
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#toString()
	 */
	@Override
	public String toString() {
		return "Combustible [nom=" + nom + ", tipusC=" + tipusC
				+ ", grauContaminacio=" + grauContaminacio +" Proveidors:"+proveiidorsToString()+ "]";
	}
	/**
	 * @return
	 */
	public String proveiidorsToString()
	{
		String s=null;
		for(int i=0;i<this._proveidors.size();i++)
		{
			s+= "\n"+this._proveidors.get(i).getNom()+"  "+this._proveidors.get(i).getDescripcio();
		}
		return s;
	}



	
}
