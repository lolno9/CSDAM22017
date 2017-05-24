package ProcessData;
import java.util.ArrayList;
import java.util.List;

/**
 * @author Begoña
 *
 */
public class Proveiidor {
	public Proveiidor() {
	}

	/**
	 * @param nom
	 */
	public Proveiidor(String nom) {
		this.nom = nom;
		this.setDescripcio(nom);
	}

	private String nom;
	private String descripcio;
	private List<Combustible> _combustibles = new ArrayList<Combustible>();

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
	public List<Combustible> getcombustibles() {
		return _combustibles;
	}

	/**
	 * @param combustible
	 */
	public void addCombustible(Combustible combustible) {
		this._combustibles.add(combustible);
	}

	/**
	 * @return
	 */
	public String getDescripcio() {
		return descripcio;
	}
	/**
	 * @param nom
	 */
	public void setDescripcio(String nom) {
		if (nom.equals("Hermanos Robles SL")){
			this.descripcio = "La comercializacion, venta, distribucion y transporte de combustibles, carburantes, lubricantes y cualesquiera otros productos derivados del petroleo.";
		}
		else if (nom.equals("Faustino Agudo SL")){
			this.descripcio = "Comercio al por menor de combustibles, carburantes y lubricantes.";
		}
		else if(nom.equals("Zarcar SL")){
			this.descripcio = "Comercio al por menor de combustibles, carburantes y lubricantes.";
		}
	}
	/**
	 * @return
	 */
	public String combustibleToString()
	{
		String s=null;
		for(int i=0;i<this._combustibles.size();i++)
		{
			s+= "\n"+this._combustibles.get(i).getNom()+"  "+this._combustibles.get(i).getTipusC()+"  "+this._combustibles.get(i).getGrauContaminacio()+"  "+this._combustibles.get(i).getTanc();
		}
		return s;
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#toString()
	 */
	@Override
	public String toString() {
		return "Proveiidor [nom=" + nom + ", descripcio=" + descripcio +combustibleToString()+ "]";
	}
}
