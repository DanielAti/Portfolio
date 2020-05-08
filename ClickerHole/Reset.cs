using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public Button BotonIdi;
    public GameObject PanelReset;
    private int change;
    private string NombreTxtSpain = "Estas seguro de reiniciar tu progreso?";
    private string NombreTxt;
    private string NombreTxtIngles = "Are you sure to restart your progress?";
    public TextMeshProUGUI TextoPregunta;

    //Ponemos la condicion de si, en el animator, el booleano "b_showmenu", se haga true, o false;

    void Update()
    {
        //Ponemos en el motor gráfico el botón de cambiar idioma y extraemos el booleano del boton (si lo seleccionas, va cambiando su valor)
        change = BotonIdi.GetComponent<CambiarIdioma>().Idint;

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

        TextoPregunta.text = NombreTxt;

    }

    public void ResetButton()
    {
        PanelReset.SetActive(true);
    }

    public void Accept()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Project");
    }
    public void Discard()
    {
        PanelReset.SetActive(false);
    }
}
