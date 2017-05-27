package ProcessData;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

public class TestProcess {
	Proveiidor p = new Proveiidor("hRobles");
	List<Combustible> c = new ArrayList<Combustible>();
	List<Proveiidor> _p = new ArrayList<Proveiidor>();
	List<Sortidor> s = new ArrayList<Sortidor>();
	ProcessData pd = new ProcessData();
	@Test
	public void test() {
		assertEquals("TestProveidor","Hermanos Robles SL",p.getNom());
	}
	@Test
	public void test2() {
		assertEquals("TestProveidor","hRobles",p.getNom());
		
	}
	@Test
	public void test3(){
		Gasolinera.basicData(c, _p, s);
		assertEquals("ProcessData",void.class, pd.sortCombustibles(c));
	}
	

}
