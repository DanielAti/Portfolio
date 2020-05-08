using UnityEngine;
using UnityEngine.UI;

public class CambiarIdioma : MonoBehaviour
{
    public bool idioma;
    public int Idint;
    public Sprite BanderaEnUso;
    public Sprite BanderaSpa;
    public Sprite BanderaEng;

    //Ponemos la condicion de si, en el animator, el booleano "b_showmenu", se haga true, o false;

    void Update()
    {
        this.gameObject.GetComponent<Image>().sprite = BanderaEnUso;

        if (idioma)
        {
            BanderaEnUso = BanderaSpa;
        }
        if (!idioma)
        {
            BanderaEnUso = BanderaEng;
        }
    }

    //Ponemos un botón que, al hacer clic en el, cambie de false a true, que representaran ingles o español
    public void IdiomaCambiar()
    {
        if (!idioma)
        {
            idioma = true;
            Idint = 1;

        }
        else if (idioma)
        {
            idioma = false;
            Idint = 0;
        }
    }
}
