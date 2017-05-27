package org.example.sintesiservei;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.provider.BaseColumns;

/**
 * Created by Begoña on 24/05/2017.
 */

public class Servei {
    private String NumSort;
    private String TipusC;
    private String HoraUs;
    private String Litres;

    public Servei(String numSort, String tipusC, String horaUs, String litres) {
        NumSort = numSort;
        TipusC = tipusC;
        HoraUs = horaUs;
        Litres = litres;
    }

    public String getNumSort() {
        return NumSort;
    }

    public void setNumSort(String numSort) {
        NumSort = numSort;
    }

    public String getTipusC() {
        return TipusC;
    }

    public void setTipusC(String tipusC) {
        TipusC = tipusC;
    }

    public String getHoraUs() {
        return HoraUs;
    }

    public void setHoraUs(String horaUs) {
        HoraUs = horaUs;
    }

    public String getLitres() {
        return Litres;
    }

    public void setLitres(String litres) {
        Litres = litres;
    }
    public String stringToExport(){
        return NumSort+";"+TipusC+";"+HoraUs+";"+Litres;

    }
    @Override
    public String toString() {
        return "Servei{" +
                "NumSort='" + NumSort + '\'' +
                ", TipusC='" + TipusC + '\'' +
                ", HoraUs=" + HoraUs +
                ", Litres=" + Litres +
                '}';
    }
}
