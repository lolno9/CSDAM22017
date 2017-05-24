package GetData;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

public class TestData {

	@Test
	public void testRedondearDecimales() {
		//String s=String.format(null, Data.redondearDecimales(198.0092, 2));
		assertEquals("198.01",198.01,Data.redondearDecimales(198.0092, 2),0.01);
	}
	@Test
	public void testTestData()
	{
		List<Data> test = GetData.testData();
		List<Data> test2= new ArrayList<Data>();
		assertEquals("TestData",test, GetData.testData() );
	}
}
