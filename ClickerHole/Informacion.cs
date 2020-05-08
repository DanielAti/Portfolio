using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion : MonoBehaviour
{
    public GameObject PanelInfo;

    //Funcion para hacer click sobre el panel Informacion y se desactive
    public void InfoVentana()
    {
        PanelInfo.SetActive(false);
    }
    //Funcion para hacer click en boton de Informacion y que se active este.
    public void BotonInfo()
    {
        PanelInfo.SetActive(true);
    }
}
