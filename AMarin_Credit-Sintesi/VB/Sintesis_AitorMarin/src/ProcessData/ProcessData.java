package ProcessData;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JOptionPane;


/**
 * @author Begoña
 *
 */
public class ProcessData {
	
	/**
	 * @return
	 */
	public List<String> readData()
	{
		try{
			FileReader lector;
				try {
					lector = new FileReader("SERVEIS.txt");
				
				BufferedReader bf = new BufferedReader(lector);
				String linea;
				List<String> arlist = new ArrayList<String>();
					while((linea=bf.readLine())!=null){
						arlist.add(linea);
					}
				
					bf.close();
				
					lector.close();
				
				return arlist;
				} catch (FileNotFoundException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			} catch(IOException e){
				e.printStackTrace();
			}
		return null;
		}
	
	/**
	 * @param combustibles
	 * @param proveiidors
	 * @param sortidors
	 * @param data
	 */
	public void insertData(List<Combustible> combustibles, List<Proveiidor> proveiidors, List<Sortidor> sortidors, String[] data)
	{
		if (data[0].equals("1")){
			sortidors.get(0).setHoraUs(data[2]);
			sortidors.get(0).addLitres(Double.parseDouble(data[3]));
			sortidors.get(0).addLitres(Double.parseDouble(data[3]));
			if(data[1].equals("T1")){
				combustibles.get(0).addLitres(Double.parseDouble(data[3]));
			} else if(data[1].equals("T2")){
				combustibles.get(1).addLitres(Double.parseDouble(data[3]));
			}
			
		} else if (data[0].equals("2")){
			sortidors.get(1).setHoraUs(data[2]);
			sortidors.get(1).addLitres(Double.parseDouble(data[3]));
			sortidors.get(1).addLitres(Double.parseDouble(data[3]));
			if(data[1].equals("T1")){
				combustibles.get(0).addLitres(Double.parseDouble(data[3]));
				combustibles.get(0).resLitsTanc(Double.parseDouble(data[3]));
			} else if(data[1].equals("T2")){
				combustibles.get(1).addLitres(Double.parseDouble(data[3]));
				combustibles.get(1).resLitsTanc(Double.parseDouble(data[3]));
			}
				}else if (data[0].equals("3")){
					sortidors.get(2).setHoraUs(data[2]);
					sortidors.get(2).addLitres(Double.parseDouble(data[3]));
					sortidors.get(2).addLitres(Double.parseDouble(data[3]));
					if(data[1].equals("T3")){
						combustibles.get(2).addLitres(Double.parseDouble(data[3]));
						combustibles.get(2).resLitsTanc(Double.parseDouble(data[3]));
					} else if(data[1].equals("T4")){
						combustibles.get(3).addLitres(Double.parseDouble(data[3]));
						combustibles.get(3).resLitsTanc(Double.parseDouble(data[3]));
					}
				} else if (data[0].equals("4")){
					sortidors.get(3).setHoraUs(data[2]);
					sortidors.get(3).addLitres(Double.parseDouble(data[3]));
					sortidors.get(3).addLitres(Double.parseDouble(data[3]));
					if(data[1].equals("T3")){
						combustibles.get(2).addLitres(Double.parseDouble(data[3]));
					} else if(data[1].equals("T4")){
						combustibles.get(3).addLitres(Double.parseDouble(data[3]));
					}
				}
	}
	/**
	 * @param combustibles
	 * @return
	 */
	public String showMaxMinLits(List<Combustible> combustibles)
	{
		Double d1, d2, d3, d4;
		String n1, n2, n3, n4, nmax = "", nmin = "";
		
		d1=combustibles.get(0).getLitresTotals();
		n1=combustibles.get(0).getNom();
		d2=combustibles.get(1).getLitresTotals();
		n2=combustibles.get(1).getNom();
		d3=combustibles.get(2).getLitresTotals();
		n3=combustibles.get(2).getNom();
		d4=combustibles.get(3).getLitresTotals();
		n4=combustibles.get(3).getNom();
		
		Double max = 0.0;
		if(d1>d2 && d1>d3 && d1>d4){
			max=d1;
			nmax=n1;
		} else if(d2>d1 && d2>d3 && d2>d4){
			max=d2;
			nmax=n2;
		} else if(d3>d1 && d3>d2 && d3>d4){
			max=d3;
			nmax=n3;
		} else if(d4>d1 && d4>d2 && d4>d3){
			max=d4;
			nmax=n4;
		}
		
		Double min = 0.0;
		if(d1<d2 && d1<d3 && d1<d4){
			min=d1;
			nmin=n1;
		} else if(d2<d1 && d2<d3 && d2<d4){
			min=d2;
			nmin=n2;
		} else if(d3<d1 && d3<d2 && d3<d4){
			min=d3;
			nmin=n3;
		} else if(d4<d1 && d4<d2 && d4<d3){
			min=d4;
			nmin=n4;
		}
		String s = ("Litres Maxims: "+nmax.toString()+"  "+max.toString()+" Litres\n"+
				"Litres Minims: "+nmin.toString()+"  "+min.toString()+" Litres");
		System.out.println(s);
		//JOptionPane.showMessageDialog(null,s);
		return s;
	}
	/**
	 * @param sortidors
	 * @return
	 */
	public String getDepositCap(List<Sortidor> sortidors)
	{		
		Double t1, t2, t3, t4, tt = null;
		String n1, n2, n3, n4 = null, nn=null;
		t1=sortidors.get(0).getTancLits();
		t2=sortidors.get(1).getTancLits();
		t3=sortidors.get(2).getTancLits();
		t4=sortidors.get(3).getTancLits();
		n1=sortidors.get(0).getNom();
		n2=sortidors.get(1).getNom();
		n3=sortidors.get(2).getNom();
		n3=sortidors.get(3).getNom();
		if(t1<t2 && t1<t3 && t1<t4){
			tt= t1;
			nn=n1;
		}else if(t2<t1 && t2<t3 && t2<t3){
			tt=t2;
			nn=n2;
		}else if(t3<t1 && t3<t2 && t3<t4){
			tt=t3;
			nn=n3;
		}else if(t4<t1 && t4<t2 && t4<t3){
			tt=t4;
			nn=n4;
		}
		double totcom = 10000.00-tt;
		System.out.println("El Deposit amb menos litres es: "+nn+"  "+tt.toString()+" Litres"+"\n"
		+"La comanda actual es de: "+totcom);
		return "El Deposit amb menos litres es: "+nn+"  "+tt.toString()+" Litres"+"\n"
				+"La comanda actual es de: "+totcom;
	}
	
	/**
	 * @param combustibles
	 * @return
	 */
	public String sortCombustibles(List<Combustible> combustibles)
	{
		int c1 = 0, c2 = 0, c3 = 0, c4 = 0;
		String n1 = null, n2 = null, n3 = null, n4 = null;
		for(Combustible c : combustibles)
		{
			if(c.getGrauContaminacio()==4){
				c1=c.getGrauContaminacio();
				n1=c.getNom();
			}
			if(c.getGrauContaminacio()==3){
				c2=c.getGrauContaminacio();
				n2=c.getNom();
			}else if(c.getGrauContaminacio()==2 ){
				c3=c.getGrauContaminacio();
				n3=c.getNom();
			}else if(c.getGrauContaminacio()==1 ){
				c4=c.getGrauContaminacio();
				n4=c.getNom();
			}
		
		}
		System.out.println(n1+": "+c1+"\n"
				+n2+": "+c2+"\n"
				+n3+": "+c3+"\n"
				+n4+": "+c4+"\n");
		return n1+": "+c1+"\n"
				+n2+": "+c2+"\n"
				+n3+": "+c3+"\n"
				+n4+": "+c4+"\n";		
	}
	/**
	 * @param combustibles
	 * @return
	 */
	public String findProvider(List<Combustible> combustibles)
	{
		List<Proveiidor> lc = new ArrayList<Proveiidor>();
		String s = (JOptionPane.showInputDialog("Introdueix el Carburant(95 = T1,  98 = T2,  Biodiesel = T3, Diesel = T4)"));
		if(s==combustibles.get(0).getTipusC()){
			lc=combustibles.get(0).get_proveidors();
		}
		if(s==combustibles.get(1).getTipusC()){
			lc=combustibles.get(1).get_proveidors();
		}
		if(s==combustibles.get(2).getTipusC()){
			lc=combustibles.get(2).get_proveidors();
		}
		if(s==combustibles.get(3).getTipusC()){
			lc=combustibles.get(3).get_proveidors();
		}
		if (lc.size()==4)
		{
			System.out.println(lc.get(0).toString()+"\n\n"+lc.get(1).toString()+"\n\n"+lc.get(2).toString()+"\n\n"+lc.get(3).toString());
			return "\n"+lc.get(0).toString()+"\n\n"+lc.get(1).toString()+"\n\n"+lc.get(2).toString()+"\n\n"+lc.get(3).toString();
		}else{
		//System.out.println("\n"+lc.get(0).toString()+"\n\n"+lc.get(1).toString());
		return "\n"+lc.get(0).toString()+"\n\n"+lc.get(1).toString();
		}
	}
	
	/**
	 * @param proveiidors
	 * @return
	 */
	public String findCombustible(List<Proveiidor> proveiidors)
	{
		List<Combustible> lc = new ArrayList<Combustible>();
		String s = (JOptionPane.showInputDialog("Introdueix el Proveiidor(Hermanos Robles SL, Faustino Agudo SL, Zarcar SL)"));
		String busc = proveiidors.get(0).getNom().trim().toLowerCase();
		String ss = s.trim().toLowerCase();
		if (busc.equals(ss)){
			lc=proveiidors.get(0).getcombustibles();
		}
		busc = proveiidors.get(1).getNom().trim().toLowerCase();
		if (busc.equals(ss)){
			lc=proveiidors.get(1).getcombustibles();
		}
		busc = proveiidors.get(2).getNom().trim().toLowerCase();
		if (busc.equals(ss)){
			lc=proveiidors.get(2).getcombustibles();
		}
		if (lc.size()==4)
		{
			System.out.println(lc.get(0).toString()+"\n\n"+lc.get(1).toString()+"\n\n"+lc.get(2).toString()+"\n\n"+lc.get(3).toString());
			return lc.get(0).toString()+"\n\n"+lc.get(1).toString()+"\n\n"+lc.get(2).toString()+"\n\n"+lc.get(3).toString();
		}else{
		System.out.println(lc.get(0).toString()+"\n\n"+lc.get(1).toString());
		return lc.get(0).toString()+"\n\n"+lc.get(1).toString();
		}
	}
	/**
	 * @param combustibles
	 * @return
	 */
	public String dadesCombustible(List<Combustible> combustibles)
	{
		String s = (JOptionPane.showInputDialog("Introdueix el Carburant(95 = T1,  98 = T2,  Biodiesel = T3, Diesel = T4)"));
			if(combustibles.get(0).getTipusC().toLowerCase().trim().equals(s.toLowerCase().trim()))
			{
				System.out.println(combustibles.get(0).toString());
				return combustibles.get(0).toString();
			}else if(combustibles.get(1).getTipusC().toLowerCase().trim().equals(s.toLowerCase().trim()))
			{
				System.out.println(combustibles.get(1).toString());
				return combustibles.get(1).toString();
			}else if(combustibles.get(2).getTipusC().toLowerCase().trim().equals(s.toLowerCase().trim()))
			{
				System.out.println(combustibles.get(2).toString());
				return combustibles.get(2).toString();
			}else if(combustibles.get(3).getTipusC().toLowerCase().trim().equals(s.toLowerCase().trim()))
			{
				System.out.println(combustibles.get(3).toString());
				return combustibles.get(3).toString();
			}
		return "No s'ha trobat la busqueda: "+s;
		}
	}

		

