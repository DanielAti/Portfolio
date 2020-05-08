using UnityEngine;
using TMPro;

public class RealTimeCounter : MonoBehaviour
{
    //Temporizador de prueba
    public float timer;
    public static bool simulateMouseWithTouches;
    public TextMeshProUGUI TextoOffline;
    public float PuntosOffline;
    public GameObject CuentaPrimerIdle;
    public GameObject CuentaPrimerUpgrade;
    public GameObject SumarOro;
    public GameObject PanelOffline;
    public GameObject PanelTutorial;
    public GameObject PanelTutoesp;
    public GameObject PanelTutoeng;
    public GameObject Boton;
    private bool VentanaCerradaTuto = false;
    private bool VentanaCerrada = false;
    private int change;
    private string NombreTxtSpain = "   Energia ganada";
    private string NombreTxt;
    private string NombreTxtIngles = "  Energy won!";


    void Start()
    {
        //Temporizador de inicio a nuestra cantidad inicial
        timer = 0;

        //Actualizar temporizador con tiempo real pasado
        timer += TimeMaster.instance.CheckDate();
        //Que aparezca el panel si el primer idle tiene por lo menos una mejora

        PanelOffline.SetActive(true);

        //Inicia con el valor de que la ventana de valor offline no se ha cerrado
        VentanaCerrada = false;
    }
    void Update()
    {
        //Ponemos en el motor gráfico el botón de cambiar idioma y extraemos el booleano del boton (si lo seleccionas, va cambiando su valor)
        change = Boton.GetComponent<CambiarIdioma>().Idint;

        //Actualiza nuestro temporizador cada fotograma
        timer += Time.deltaTime;
        //Con Mathf.Clamp le ponemos limite "Mathf.Clamp(valor, minimo, maximo)

        //TENGO QUE PONER UN LIMITADOR POR NIVEL DEL PRIMER IDLE
              if(CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 2)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 325);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 5)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 571);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 10)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 1679);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 20)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 23567);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 30)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 307183);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 40)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 3125496);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 50)
              { 
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 53115496);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 60)
              {
                  PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 731459218);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 70)
              {
                 PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 4295821354);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 80)
              {
                 PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 16453751246);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 90)
              {
                 PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 624453751246);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta <= 100)
              {
                 PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 4265375124616);
              }
              else if (CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta > 100)
              {
                 PuntosOffline = Mathf.Clamp(TimeMaster.instance.CheckDate() * 0.05f * CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta, 0, 37512461645582);
              }

        TextoOffline.text = Conversion.Instance.GetCurrencyIntoString(PuntosOffline, false, false) + NombreTxt;

        //Cuando los PuntosOffline sean mayor de 0, cuando VentanaCerradaTuto es false o la cuenta del primer idle es mayor o igual a 1, aparece la pantalla Tutorial

        if (PuntosOffline > 0f || VentanaCerradaTuto || CuentaPrimerIdle.GetComponent<ItemManager>().Cuenta >= 1 )
        {
            PanelTutorial.SetActive(false);
            VentanaCerradaTuto = true;
        }
        else
        {
            PanelTutorial.SetActive(true);
        }

        //Aquí, la variable en un principio está "false", asi que, cuando hagamos click al boton, se pondrá "true"
        //Ponemos la condición, de que si el valor es "true" se ponga el texto en Ingles, si es false, el texto en Español
        if (change == 1)
        {
            NombreTxt = NombreTxtIngles;
        }
        else if (change == 0)
        {
            NombreTxt = NombreTxtSpain;
        }

    }

    //Funcion para el panel de tutorial (que contiene una imagen tutorial), en el momento que haces clic en el boton, se desactiva
    public void TutoVenta()
    {
        PanelOffline.SetActive(false);
        ResetClock();
        VentanaCerradaTuto = true;
    }

    //Funcion para hacer click sobre el tutorial (segundo) y se desactive
    public void TutoVenta2()
    {
        if (change == 1)
        {
            PanelTutoeng.SetActive(false);
        }
        else if (change == 0)
        {
            PanelTutoesp.SetActive(false);
        }
    }
    //Funcion para hacer click en boton de tutorial y que se active este.
    public void TutoVentaBoton()
    {
        if (change == 1)
        {
            PanelTutoeng.SetActive(true);
        }
        else if (change == 0)
        {
            PanelTutoesp.SetActive(true);
        }
    }

    //Al hacer click en la pantalla de energia ganado offline, se sume, se reinicie el reloj, el booleano de ventana cerrada se ponga true y se desactive el panel
    public void OnMouseDown()
    {
            //Sumamos los puntos al contador
            SumarOro.GetComponent<Click>().Oro += PuntosOffline;
            ResetClock();
            //Desactivamos de la vista el panel
            PanelOffline.SetActive(false);
            VentanaCerrada = true;
    }

    //Si al cerrar ventana, el booleano está "true" se reinicia el contrador de reloj
    void OnApplicationQuit()
    {
        if (VentanaCerrada)
        {
            ResetClock();
        }
    }

    //Reinicia el reloj.
    void ResetClock()
    {
        TimeMaster.instance.SaveDate();
        timer = 0;
        timer += TimeMaster.instance.CheckDate();
    }


}
