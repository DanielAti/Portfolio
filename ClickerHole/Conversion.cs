using UnityEngine;

public class Conversion : MonoBehaviour
{
    //Creamos un objeto vacio y en este, metemos este Script
    private static Conversion instance;
    public GameObject Boton;
    private int change;
    private string NombrePerSec;
    private string NombrePerClick;
    private string NombreSpainPerSec = " Energia/Seg";
    private string NombreInglesPerSec = " Energy/Sec";
    private string NombreSpainPerClick = " Energia/Toque";
    private string NombreInglesPerClick = " Energy/Tap";

    void Update()
    {
        //Ponemos en el motor gráfico el botón de cambiar idioma y extraemos el booleano del boton (si lo seleccionas, va cambiando su valor)
        change = Boton.GetComponent<CambiarIdioma>().Idint;

        //Aquí, la variable en un principio está "false", asi que, cuando hagamos click al boton, se pondrá "true"
        //Ponemos la condición, de que si el valor es "true" se ponga el texto en Ingles, si es false, el texto en Español
        if (change == 1)
        {
            NombrePerSec = NombreInglesPerSec;
            NombrePerClick = NombreInglesPerClick;
        }
        else if (change == 0)
        {
            NombrePerSec = NombreSpainPerSec;
            NombrePerClick = NombreSpainPerClick;
        }
    }
    public static Conversion Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        CrearInstancia();
    }

    void CrearInstancia()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //"valueToConvert" es el valor externo que le pondremos, el que tendrá los ceros que se precisan disminuir
    // currencyPerSec se pone true cuando es el marcador de valor por segundo, y así lo definido aquí, aparecerá en el marcador
    // currencyPerclick se pone true cuando es el marcador de valor por click, y así lo definido aquí, aparecerá en el marcador
    // 'ToString("f3")' para poner 3 decimales al float.
    public string GetCurrencyIntoString(float valueToConvert, bool currencyPerSec, bool currencyPerClick)
    {
        string converted;
        if (valueToConvert >= 100000000000000000000000000000000000000f)
        {
            converted = (valueToConvert / 100000000000000000000000000000000000000f).ToString("f3") + " WTF?!";
        }
        else if (valueToConvert >= 1000000000000000000000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000000000000000000000f).ToString("f3") + " J";
        }
        else if (valueToConvert >= 1000000000000000000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000000000000000000f).ToString("f3") + " S";
        }
        else if (valueToConvert >= 1000000000000000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000000000000000f).ToString("f3") + " GE";
        }
        else if (valueToConvert >= 1000000000000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000000000000f).ToString("f3") + " B";
        }
        else if (valueToConvert >= 1000000000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000000000f).ToString("f3") + " Y";
        }
        else if (valueToConvert >= 1000000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000000f).ToString("f3") + " Z";
        }
        else if (valueToConvert >= 1000000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000000f).ToString("f3") + " E";
        }
        else if (valueToConvert >= 1000000000000000f)
        {
            converted = (valueToConvert / 1000000000000000f).ToString("f3") + " P";
        }
        else if (valueToConvert >= 1000000000000f)
        {
            converted = (valueToConvert / 1000000000000f).ToString("f3") + " T";
        }
        else if (valueToConvert >= 1000000000f)
        {
            converted = (valueToConvert / 1000000000f).ToString("f3") + " G";
        }
        else if (valueToConvert >= 1000000f)
        {
            converted = (valueToConvert / 1000000f).ToString("f3") + " M";
        }
        else if (valueToConvert >= 1000f)
        {
            converted = (valueToConvert / 1000f).ToString("f3") + " k";
            }
        else
            {
            converted = (valueToConvert).ToString("f0");
        }

            if (currencyPerSec == true)
            {
                converted = converted + NombrePerSec;
            }

            if (currencyPerClick == true)
            {
                converted = converted + NombrePerClick;
            }
            return converted;
        }
        }
