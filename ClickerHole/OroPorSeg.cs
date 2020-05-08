using System.Collections;
using UnityEngine;
using TMPro;

public class OroPorSeg : MonoBehaviour
{
    public TextMeshProUGUI ppsDisplay;
    public Click click;
    public ItemManager[] Objetos;

    void Start()
    {
        StartCoroutine(AutoTick());
    }

    void Update()
    {
        //Del Script "Conversion", usamos lo creado para que nos aparezca la información con menos ceros
        ppsDisplay.text = Conversion.Instance.GetCurrencyIntoString(ObtenerOroPorSegundo(),true,false);
    }

    //Aquí, introducimos desde el motor grafico, todos los objetos que generan oro por segundo automaticamente.
    public float ObtenerOroPorSegundo()
    {
        //Que se sumen todos los valores por segundo, para que vaya sumando por segundo.
        float tick = 0;
        foreach (ItemManager Obj in Objetos)
        {
            tick += Obj.Cuenta * Obj.TickValue;
        }
        return tick;
    }

    public void AutoOroPorSegundo()
    {
        //Ya que se actualiza cada segundo, usamos la linea de comentario de abajo para que se actualice mas rapido, pero necesimos dividir entre 10 la ganancia por segundo (en este caso),
        //así actualizamos mas rapido el contador, y no se acelera.
        click.Oro += ObtenerOroPorSegundo() / 10;
    }

    IEnumerator AutoTick()
    {
        while (true)
        {
            AutoOroPorSegundo();
            // Para que se actualice la puntuación mucho más rapido, ponemos la siguiente linea, pero esto hará que vaya mas rápido, para resolver eso, leer linea comentario encima.
            yield return new WaitForSeconds(0.10f);
        }
    }
}
