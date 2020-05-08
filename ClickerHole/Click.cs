using UnityEngine;
using TMPro;

public class Click : MonoBehaviour {

    //Dentro de un camvas, hacemos un boton que es donde se hará click para que genere oro por click.
    public TextMeshProUGUI GPC;
    public TextMeshProUGUI MonitorOro;
    public GameObject Boton;
    private int change;
    private string Nombre;
    private string Spa = "Energia: ";
    private string Eng = "Energy: ";
    public float Oro;
    public float OroClick;

    void Update() {
        //Ponemos en el motor gráfico el botón de cambiar idioma y extraemos el booleano del boton (si lo seleccionas, va cambiando su valor)
        change = Boton.GetComponent<CambiarIdioma>().Idint;

        //Aquí, la variable en un principio está "false", asi que, cuando hagamos click al boton, se pondrá "true"
        //Ponemos la condición, de que si el valor es "true" se ponga el texto en Ingles, si es false, el texto en Español
        if (change == 1)
        {
            Nombre = Eng;
        }
        else if (change == 0)
        {
            Nombre = Spa;
        }

        //Del Script "Conversion", usamos lo creado para que nos aparezca la información con menos ceros
        MonitorOro.text = Nombre + Conversion.Instance.GetCurrencyIntoString(Oro, false, false);
        GPC.text = Conversion.Instance.GetCurrencyIntoString(OroClick, false, true);
    }

    //Suma el precio de cada click, al oro
    public void Clicked() {
        Oro += OroClick;
    }
}
