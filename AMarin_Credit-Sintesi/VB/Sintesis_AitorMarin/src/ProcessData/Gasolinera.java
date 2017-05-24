package ProcessData;

import java.util.ArrayList;
import java.util.List;

import javax.swing.JOptionPane;

/**
 * @author Begoña
 *
 */
public class Gasolinera {
	
	private List<Combustible> combustibles = new ArrayList<Combustible>();
	private List<Proveiidor> proveiidors = new ArrayList<Proveiidor>();
	private List<Sortidor> sortidors = new ArrayList<Sortidor>();
	
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		String[] data;
		Gasolinera g1 = new Gasolinera();
		basicData(g1.combustibles, g1.proveiidors, g1.sortidors);
		ProcessData process = new ProcessData();
		List<String> readedData = process.readData();
		StringBuilder sb =new StringBuilder();
		for(int i=0;i<readedData.size();i++)
		{
			sb.append(readedData.get(i)+"\n");
			data = readedData.get(i).split(";");
			process.insertData(g1.combustibles, g1.proveiidors, g1.sortidors, data);
		}
		//JOptionPane.showMessageDialog(null, sb.toString());
		String litsMN = process.showMaxMinLits(g1.combustibles); //devuelve litros max y min por carburante (es return)
		String depCap = process.getDepositCap(g1.sortidors);
		String Contaminants = process.sortCombustibles(g1.combustibles).replace("null", " ");
		String CombFromProv = process.findCombustible(g1.proveiidors).replace("null", " ");
		//String ProvFromComb = process.findProvider(g1.combustibles);
		String dadcomb = process.dadesCombustible(g1.combustibles).replace("null", " ");
		
		JOptionPane.showMessageDialog(null, litsMN+"\n\n"+depCap+"\n\n"+Contaminants+"\n\n"+CombFromProv+"\n\n"+dadcomb);
	}

	/**
	 * @param c
	 * @param p
	 * @param s
	 */
	public static void basicData(List<Combustible> c, List<Proveiidor> p, List<Sortidor> s) {
				
		Tanc t95 = new Tanc("Deposit 95", 10000.00);
		Tanc t98 = new Tanc("Deposit 98", 10000.00);
		Tanc tbiodiesel = new Tanc("Deposit Biodiesel", 10000.00);
		Tanc tdiesel = new Tanc("Deposit Diesel", 10000.00);
		Combustible sp95 = new Combustible("Sense Plom 95º","T1",2,t95);
		Combustible sp98 = new Combustible("Sense Plom 98º","T2",3,t98);
		Combustible biodiesel = new Combustible("Biodiesel","T3",1,tbiodiesel);
		Combustible diesel = new Combustible("Diesel","T4",4,tdiesel);		
		Sortidor s1 = new Sortidor("1",t95);
		Sortidor s2 = new Sortidor("2",t98);
		Sortidor s3 = new Sortidor("3",tbiodiesel);
		Sortidor s4 = new Sortidor("4",tdiesel);		
		Proveiidor hRobles = new Proveiidor("Hermanos Robles SL");
		Proveiidor fAgudo = new Proveiidor("Faustino Agudo SL");
		Proveiidor zarcar = new Proveiidor("Zarcar SL");
		
		s1.addCombustible(sp95);
		s1.addCombustible(sp98);
		s2.addCombustible(sp95);
		s2.addCombustible(sp98);
		s3.addCombustible(biodiesel);
		s3.addCombustible(diesel);
		s4.addCombustible(biodiesel);
		s4.addCombustible(diesel);
		hRobles.addCombustible(sp95);
		hRobles.addCombustible(sp98);
		hRobles.addCombustible(biodiesel);
		hRobles.addCombustible(diesel);		
		fAgudo.addCombustible(sp95);
		fAgudo.addCombustible(sp98);
		zarcar.addCombustible(biodiesel);
		zarcar.addCombustible(diesel);
		sp95.addProveidors(hRobles);
		sp95.addProveidors(fAgudo);
		sp98.addProveidors(hRobles);
		sp98.addProveidors(fAgudo);
		biodiesel.addProveidors(hRobles);
		biodiesel.addProveidors(zarcar);
		diesel.addProveidors(hRobles);
		diesel.addProveidors(zarcar);		
		c.add(sp95);
		c.add(sp98);
		c.add(biodiesel);
		c.add(diesel);
		p.add(hRobles);
		p.add(fAgudo);
		p.add(zarcar);
		s.add(s1);
		s.add(s2);
		s.add(s3);
		s.add(s4);
	}

}
