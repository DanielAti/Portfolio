using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarIdle : MonoBehaviour
{
    public GameObject IdleSuperior;

    // Este Script es para que aparezca el siguiente Idle, cuando se haya desbloqueado uno, es decir, para ir avanzando
    public void Update()
    {
        if (this.GetComponent<ItemManager>().Cuenta >= 1)
        {
            IdleSuperior.SetActive(true);
        }

    }

}
