using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{

    public bool showMenu;
    private Animator botonAnim;
    void Start()
    {
        botonAnim = GetComponent<Animator>();
    }

    //Ponemos la condicion de si, en el animator, el booleano "b_showmenu", se haga true, o false;

    void Update()
    {
        // Al cambiar el valor del booleano (justo en la funcion de debajo) y que aparezca o se esconda, segun la animación
        if (showMenu)
        {
            botonAnim.SetBool("b_showMenu", true);

        }
        if (!showMenu)
        {
            botonAnim.SetBool("b_showMenu", false);
        }
    }

    //Cuando hagas click en el engranaje del juego, cambie el valor del booleano 
    public void ButtonShowMenu()
    {
        if (!showMenu)
        {
            showMenu = true;
        }
        else if (showMenu)
        {
            showMenu = false;
        }
    }
}
