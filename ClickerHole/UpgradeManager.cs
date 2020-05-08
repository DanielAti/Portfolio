using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public Click click;
    public TextMeshProUGUI itemInfo;
    public float Precio;
    public float ClickFuerza;
    public int Cuenta;
    public Color TextoEstandar;
    public Color TextoAsequible;
    private float NuevoPrecio;
    private Slider _slider;


    void Start()
    {
        NuevoPrecio = Precio;
        _slider = GetComponentInChildren<Slider>();

    }
    void Update()
    {
        //Queremos que solo nos aparezca el nivel del objeto
        itemInfo.text = " LvL: " + Cuenta;

        //Antes de escribir lo siguiente, en el slider que queremos usar, deberemos poner que el valor maximo, será 200 (en este caso)
        //Este, se coje el oro que se hace por click, se divide entre el precio y se multiplica por el valor maximo deseado, para que reparta en todo el slider
        _slider.value = click.Oro / Precio * 200;

        //Cogemos material para darle tectura al boton, y color para el texto
        //Irá avanzando hasta que pueda ser posible comprarlo, mientrás estará en "Estandar", cuando se puedas comprar, estará en "Asequible"
        if (_slider.value >= 200)
        {
            itemInfo.color = TextoAsequible;
        }
        else
        {
            itemInfo.color = TextoEstandar;
        }

        

    }
    //Restamos el oro, al precio que cuesta, creamos variable cuenta para tener en cuenta el nivel del objeto comprado y que cada vez que se compre, valga el 130% mas
    public void MejoraCompra()
    {
        if(click.Oro >= Precio)
        {
            click.Oro -= Precio;
            Cuenta += 1;
            click.OroClick += ClickFuerza;
            Precio = Mathf.Round (NuevoPrecio * Mathf.Pow(1.5f, Cuenta));
        }
    }
}
