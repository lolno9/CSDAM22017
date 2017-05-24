package GetData;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.List;

/**
 * @author Begoña
 *
 */
public class GetData {
	private List<Data> _allData;
	
	/**
	 * @param data
	 */
	public void setData(Data data)
	{
		this._allData.add(data);
	}
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		GetData gd=new GetData();
		gd._allData=new ArrayList<Data>();
		gd._allData=testData();
		File serveis = new File("SERVEIS.txt");
		try {
			FileWriter escriure = new FileWriter(serveis);
			BufferedWriter bw = new BufferedWriter(escriure);
			for(int i = 0; i<gd._allData.size(); i++)
			{
				bw.write(gd._allData.get(i).toString());
				bw.newLine();
			}
			bw.close();
			escriure.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	
	/* Data Generated for Test Purposes */
	/**
	 * @return
	 */
	public static List<Data> testData()
	{
		List<Data> _test = new ArrayList<Data>();
		double a= 9.5;
		Calendar c1 = new GregorianCalendar();
		c1.set(Calendar.HOUR_OF_DAY, 12);
		c1.set(Calendar.MINUTE, 40);
		Data d1 = new Data(1,"T4",c1,a);
		_test.add(d1);
		a= 10.2;
		c1.set(Calendar.HOUR_OF_DAY, 13);
		c1.set(Calendar.MINUTE, 04);
		Data d2 = new Data(1,"T3",c1,a);
		_test.add(d2);
		a= 25.0;
		c1.set(Calendar.HOUR_OF_DAY, 10);
		c1.set(Calendar.MINUTE, 11);
		Data d3 = new Data(2,"T3",c1,a);
		_test.add(d3);
		a= 15.18;
		c1.set(Calendar.HOUR_OF_DAY, 9);
		c1.set(Calendar.MINUTE, 45);
		Data d4 = new Data(3,"T2",c1,a);
		_test.add(d4);
		a= 50.9;
		c1.set(Calendar.HOUR_OF_DAY, 17);
		c1.set(Calendar.MINUTE, 30);
		Data d5 = new Data(2,"T4",c1,a);
		_test.add(d5);
		a= 25.0;
		c1.set(Calendar.HOUR_OF_DAY, 11);
		c1.set(Calendar.MINUTE, 46);
		Data d6 = new Data(3,"T3",c1,a);
		_test.add(d6);
		a= 11.5;
		c1.set(Calendar.HOUR_OF_DAY, 10);
		c1.set(Calendar.MINUTE, 15);
		Data d7 = new Data(2,"T2",c1,a);
		_test.add(d7);
		a= 20.11;
		c1.set(Calendar.HOUR_OF_DAY, 20);
		c1.set(Calendar.MINUTE, 26);
		Data d8 = new Data(3,"T3",c1,a);
		_test.add(d8);
		
		return _test;
	}
}
