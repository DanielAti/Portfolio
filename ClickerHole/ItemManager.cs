using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public TextMeshProUGUI itemInfo;
    public Click click;
    public float Precio;
    public float TickValue;
    public int Cuenta;
    public GameObject Boton;
    public string NombreSpain;
    private int change;
    public string NombreIngles;
    private string PrecioTxtSpain = "  Precio: ";
    private string PrecioTxt;
    private string PrecioTxtIngles = "  Price: ";
    private string Nombre;
    public Material Estandar;
    public Material Asequible;
    public Color TextoEstandar;
    public Color TextoAsequible;
    private float basePrecio;
    private Slider _slider;



    void Start()
    {
        basePrecio = Precio;
        _slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        //Ponemos en el motor gráfico el botón de cambiar idioma y extraemos el booleano del boton (si lo seleccionas, va cambiando su valor)
        change = Boton.GetComponent<CambiarIdioma>().Idint;


        //Del Script "Conversion", usamos lo creado para que nos aparezca la información con menos ceros
        itemInfo.text = Nombre + " \n LvL: " + Cuenta + PrecioTxt + Conversion.Instance.GetCurrencyIntoString(Precio, false, false);

        //Antes de escribir lo siguiente, en el slider que queremos usar, deberemos poner que el valor maximo, será 200 (en este caso)
        //Este, se coje el oro que se hace por click, se divide entre el precio y se multiplica por el valor maximo deseado, para que reparta en todo el slider
        _slider.value = click.Oro / Precio * 200;

        //Cogemos material para darle tectura al boton, y color para el texto
        //Irá avanzando hasta que pueda ser posible comprarlo, mientrás estará en "Estandar", cuando se puedas comprar, estará en "Asequible"
        if (_slider.value >= 200)
        {
            GetComponent<Image>().material = Asequible;
            itemInfo.color = TextoAsequible;
        }
        else
        {
            GetComponent<Image>().material = Estandar;
            itemInfo.color = TextoEstandar;
        }

        //Aquí, la variable en un principio está "false", asi que, cuando hagamos click al boton, se pondrá "true"
        //Ponemos la condición, de que si el valor es "true" se ponga el texto en Ingles, si es false, el texto en Español
        if (change == 1)
        {
            Nombre = NombreIngles;
            PrecioTxt = PrecioTxtIngles;
        }
        else if(change == 0)
        {
            Nombre = NombreSpain;
            PrecioTxt = PrecioTxtSpain;
        }

    }

    //Restamos el oro, al precio que cuesta, creamos variable cuenta para tener en cuenta el nivel del objeto comprado y que cada vez que se compre, valga el 130% mas
    public void ComprarObjeto()
    {
        if(click.Oro >= Precio)
        {
            click.Oro -= Precio;
            Cuenta += 1;
            Precio = Mathf.Round(basePrecio * Mathf.Pow(1.2f, Cuenta));
        }
    }

}
