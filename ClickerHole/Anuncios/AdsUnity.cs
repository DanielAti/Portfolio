using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;
using System.Collections;

public class AdsUnity : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3565074";
#elif UNITY_ANDROID
    private string gameId = "3565075";
#endif

    private string PlacementID;
    public GameObject Click;
    public GameObject Agujero;
    public GameObject Round;
    public Button botonPremio;
    public Button botonAuto;

    void Start () {
        Advertisement.Initialize (gameId);
        //StartCoroutine (ShowBannerWhenReady ());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        // Set interactivity to be dependent on the Placement’s status:
        //botonAuto.interactable = Advertisement.IsReady("RewardAutoClick");
        //botonPremio.interactable = Advertisement.IsReady("rewardedVideo");

    }
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("Banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show ("Banner");
    }

    public void ShowRewardedAd(string placement)
    {
        PlacementID = placement;
        if (Advertisement.IsReady(placement))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(placement, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Se ha mostrado satisfactoriamente.");
                //
                //YOUR CODE TO REWARD THE GAMER
                //Give your money.
                if (PlacementID == "rewardedVideo")
                {
                    SetEnergia();
                }
                else if (PlacementID == "RewardAutoClick")
                {
                    SetAutoClicker();
                }
                break;
            case ShowResult.Skipped:
                Debug.Log("Ha salido antes de que acabe.");
                break;
            case ShowResult.Failed:
                Debug.Log("No se ha mostrado.");
                break;
        }
    }

    private void SetEnergia()
    {
        Click.GetComponent<Click>().Oro += Click.GetComponent<Click>().OroClick * 9.9f;
    }

    private void SetAutoClicker()
    {
        StartCoroutine(AutoClick());

        IEnumerator AutoClick()
        {
            // Esperará 1 segundo como Invoke podría hacer, elimine esto si no se necesita
            // yield return new WaitForSeconds(1);

            float tiempopasado = 0;
            while (tiempopasado <= 20)
            {
                // Code here
                // LLama a la funcion 20 segundos
                InvokeRepeating("Clicking", 0, 20);
                Agujero.GetComponent<ParticleSystem>().startSize = 0.03f;
                Agujero.GetComponent<ParticleSystem>().playbackSpeed = 2;
                Round.GetComponent<ParticleSystem>().playbackSpeed = 1.5f;
                tiempopasado += Time.deltaTime;
                yield return null;
            }
            CancelInvoke();
            Agujero.GetComponent<ParticleSystem>().startSize = 0.02f;
            Agujero.GetComponent<ParticleSystem>().playbackSpeed = 1;
            Round.GetComponent<ParticleSystem>().playbackSpeed = 1;
        }
        StopCoroutine(AutoClick());
    }

    void Clicking()
    {
        Click.GetComponent<Click>().Oro += Click.GetComponent<Click>().OroClick / 30;
    }

}
