package org.example.sintesiservei;


import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

public class SintesiServei extends AppCompatActivity {
    TextView tv1;
    List<Servei> ls;
    EditText et1, et2, et3, et4;
    SQLiteDatabase db;
    Button bmos, bsav;
    ListView lv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sintesi_servei);
        bmos = (Button)findViewById(R.id.button);
        bsav= (Button)findViewById(R.id.button2);
        et1=(EditText)findViewById(R.id.editText);
        et2=(EditText)findViewById(R.id.editText2);
        et3=(EditText)findViewById(R.id.editText3);
        et4=(EditText)findViewById(R.id.editText4);
        //tv1=(TextView) findViewById(R.id.textView6);
        //lv=(ListView)findViewById(R.id.listView1);

    }
    public void alta(View v) {
        DBHelper admin = new DBHelper(this,
                "serveis", null, 1);
        SQLiteDatabase bd = admin.getWritableDatabase();
        String sort = et1.getText().toString();
        String tipusc = et2.getText().toString();
        String hora = et3.getText().toString();
        String litres = et4.getText().toString();
        ContentValues registro = new ContentValues();
        registro.put("sortidor", sort);
        registro.put("tipusc", tipusc);
        registro.put("hora", hora);
        registro.put("litres",litres);
        bd.insert("servs", null, registro);
        bd.close();
        et1.setText("");
        et2.setText("");
        et3.setText("");
        et3.setText("");
        et4.setText("");
        Toast.makeText(this, "Se cargaron los datos del servicio",
                Toast.LENGTH_SHORT).show();
    }

    public void consultaporcodigo(View v) {
        DBHelper admin = new DBHelper(this,
                "serveis", null, 1);
        SQLiteDatabase bd = admin.getWritableDatabase();
        String[] columns = new String[] {"sortidor", "tipusc", "hora", "litres" };
        int[] to = new int[] {1,2,3,4};




        Cursor fila = bd.rawQuery(
                "select * from servs", null);

        SimpleCursorAdapter mAdap = new SimpleCursorAdapter(this, R.layout.activity_sintesi_servei, fila, columns, to);
        lv.setAdapter(mAdap);

        //this.setListAdapter(mAdap);
        /*StringBuilder sb = new StringBuilder();
        int i=0;
        while (fila.getString(i) != null) {
            sb.append(fila.getString(i));
                //et2.setText(fila.getString(0));
                //et3.setText(fila.getString(1));

        }*/
        bd.close();

        //Toast.makeText(this, sb.toString(), Toast.LENGTH_LONG).show();
    }


}