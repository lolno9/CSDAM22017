package ProcessData;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

//import javax.swing.JOptionPane;

/**
 * @author Begoña
 *
 */
public class Sortidor {
	/**
	 * @param nom
	 * @param tanc
	 */
	public Sortidor(String nom, Tanc tanc) {
		this.nom = nom;
		this.tanc=tanc;
	}

	public Sortidor() {
	}

	private String nom;
	private List<Date> horaUs = new ArrayList<Date>();
	private List<Double> _litres = new ArrayList<Double>();
	private List<Combustible> _combustibles = new ArrayList<Combustible>();
	private Tanc tanc;

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
	public List<Combustible> get_combustibles() {
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
	public List<Date> getHoraUs() {
		return horaUs;
	}

	/**
	 * @param horaUs
	 */
	public void setHoraUs(String horaUs) 
	{
		try {
		SimpleDateFormat sdf = new SimpleDateFormat("HH:mm");
		Calendar cal = Calendar.getInstance();
		
			cal.setTime(sdf.parse(horaUs));
		this.horaUs.add(cal.getTime());
		} catch (ParseException e) {
			e.printStackTrace();
		}
	}

	/**
	 * @return
	 */
	public List<Double> getLitres() {
		return _litres;
	}

	/**
	 * @param _litres
	 */
	public void addLitres(Double _litres) {
		this._litres.add(_litres);
	}
	/**
	 * @return
	 */
	public Double getTancLits()
	{
		return this.tanc.getLitres();
	}
	/**
	 * @return
	 */
	public String getTancNom()
	{
		return this.tanc.getNom();
	}
	
}
