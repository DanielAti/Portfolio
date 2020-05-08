using System;
using UnityEngine;

public class TimeMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation;
    public static TimeMaster instance;

    void Awake()
    {
        //Crear instancia de nuestros scripts de fecha
        instance = this;

        //Establece nuestras preferencias de jugador para guardar la ubicación
        saveLocation = "Ultimafecha1";
    }

    // Comprueba la hora actual con el tiempo guardado...
    public float CheckDate()
    {
        //Almacenar la hora actual cuando se inicia
        currentDate = System.DateTime.Now;

        string tempString = PlayerPrefs.GetString(saveLocation, "1");

        //Coge los anteriores tiempos de las preferencias del jugador como un "long"

        long tempLong = Convert.ToInt64(tempString);

        //Convierta la antigua fecha de binario a una variable DateTime

        oldDate = DateTime.FromBinary(tempLong);
//        print("Antigua fecha : " + oldDate);

        //Use el método de restar y almacene el resultado como un intervalo de tiempo

        TimeSpan diferrence = currentDate.Subtract(oldDate);
//        print("Diferencia: " + diferrence);

        return (long)diferrence.TotalSeconds;
    }

    //Guarda la hora actual, esto es necesario para que podamos comprobar la diferencia más tarde
    public void SaveDate()
    {
        //guarda la hora actual del sistema
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());

//        print("Guardar esta fecha en las preferencias del jugador: " + System.DateTime.Now);
    }
}
