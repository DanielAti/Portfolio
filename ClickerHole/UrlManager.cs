using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlManager : MonoBehaviour
{
    public string Patreon;
    public string Twitter;
    public string Paypal;
    public string Instagram;
    public string Aligathor;
    public string Musico;

    public void PatreonBoton()
    {
        Application.OpenURL(Patreon);
    }

    public void TwitterBoton()
    {
        Application.OpenURL(Twitter);
    }

    public void PaypalBoton()
    {
        Application.OpenURL(Paypal);
    }

    public void InstagramBoton()
    {
        Application.OpenURL(Instagram);
    }

    public void AligathorBoton()
    {
        Application.OpenURL(Aligathor);
    }
    public void MusicoBoton()
    {
        Application.OpenURL(Musico);
    }
}
