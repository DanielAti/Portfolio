using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Guardar : MonoBehaviour
{
    //Array que contiene los Idle
    public ItemManager[] Objetos;
    //Objeto del valor de idioma
    public GameObject Idioma;
    //Array que contiene los Upgrades del click
    public UpgradeManager[] Upgrades;
    //Guardado para los puntos de energia
    public GameObject Click;
    //Disquete
    public GameObject Disquete;
    //Volumen
    public GameObject Volumen;
    public AudioMixer Audio;

    void Awake()
    {
        CargarPartida();
    }

    void Start()
    {
        StartCoroutine(Autoguardado());
    }

    public void GuardarPartida()
    {
        //Guardamos los valores "Float" e "Int" de los Idle usando PlayerPref
        foreach (ItemManager Obj in Objetos)
        {
            PlayerPrefs.SetFloat("P" + Obj.name, Obj.GetComponent<ItemManager>().Precio);
            PlayerPrefs.SetFloat("T" + Obj.name, Obj.GetComponent<ItemManager>().TickValue);
            PlayerPrefs.SetInt("C" + Obj.name, Obj.GetComponent<ItemManager>().Cuenta);
        }

        //Guardamos los valores "Float" e "Int" de los Upgrades por click usando PlayerPref
        foreach (UpgradeManager Upg in Upgrades)
        {
            PlayerPrefs.SetFloat("Up1" + Upg.name, Upg.GetComponent<UpgradeManager>().Precio);
            PlayerPrefs.SetInt("Up2" + Upg.name, Upg.GetComponent<UpgradeManager>().Cuenta);
            PlayerPrefs.SetFloat("Up3" + Upg.name, Upg.GetComponent<UpgradeManager>().ClickFuerza);
        }

        //Guardamos los valores "Float" e "Int" de los  usando PlayerPrefs
        PlayerPrefs.SetFloat("Oro", Click.GetComponent<Click>().Oro);
        PlayerPrefs.SetFloat("OroClick", Click.GetComponent<Click>().OroClick);

        //Guardamos el valor"Int" del idioma usando PlayerPrefs
        PlayerPrefs.SetInt("Id", Idioma.GetComponent<CambiarIdioma>().Idint);

        //Guardamos el valor del volumen
        PlayerPrefs.SetFloat("Vol", Volumen.GetComponent<Slider>().value);
    }

    public void CargarPartida()
    {
        //Cargamos los valores "Float" e "Int" de los Idle usando PlayerPrefs e igualamos el valor
        foreach (ItemManager Obj in Objetos)
        {
            Obj.GetComponent<ItemManager>().Precio = PlayerPrefs.GetFloat("P" + Obj.name, Obj.GetComponent<ItemManager>().Precio);
            Obj.GetComponent<ItemManager>().TickValue = PlayerPrefs.GetFloat("T" + Obj.name, Obj.GetComponent<ItemManager>().TickValue);
            Obj.GetComponent<ItemManager>().Cuenta = PlayerPrefs.GetInt("C" + Obj.name, Obj.GetComponent<ItemManager>().Cuenta);
        }

        //Cargamos los valores "Float" e "Int" de los Upgrades por click, usando PlayerPrefs e igualamos el valor
        foreach (UpgradeManager Upg in Upgrades)
        {
            Upg.GetComponent<UpgradeManager>().Precio = PlayerPrefs.GetFloat("Up1" + Upg.name, Upg.GetComponent<UpgradeManager>().Precio);
            Upg.GetComponent<UpgradeManager>().Cuenta = PlayerPrefs.GetInt("Up2" + Upg.name, Upg.GetComponent<UpgradeManager>().Cuenta); ;
            Upg.GetComponent<UpgradeManager>().ClickFuerza = PlayerPrefs.GetFloat("Up3" + Upg.name, Upg.GetComponent<UpgradeManager>().ClickFuerza);
        }

        //Cargamos los valores "Float" e "Int" de los  usando PlayerPrefs e igualamos el valor
        Click.GetComponent<Click>().Oro = PlayerPrefs.GetFloat("Oro", Click.GetComponent<Click>().Oro);
        Click.GetComponent<Click>().OroClick = PlayerPrefs.GetFloat("OroClick", Click.GetComponent<Click>().OroClick);

        //Cargamos el valor"Int" del idioma usando PlayerPrefs e igualamos el valor
        Idioma.GetComponent<CambiarIdioma>().Idint = PlayerPrefs.GetInt("Id", Idioma.GetComponent<CambiarIdioma>().Idint);

        //Cargamos el valor del volumen e igualamos valor
        Volumen.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Vol", Volumen.GetComponent<Slider>().value);

        Audio.SetFloat("Volume", Volumen.GetComponent<Slider>().value);

    }

    IEnumerator Autoguardado()
    {
        while (true)
        {
            yield return new WaitForSeconds(20.0f);
            GuardarPartida();
            Disquete.SetActive(true);
            //Debug.Log("Partida guardada");
            yield return new WaitForSeconds(1.0f);
            Disquete.SetActive(false);
        }
    }

}
