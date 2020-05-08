using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    //Este pequeño script es para poner un slider, relacionarlo, y poner de valor mínimo -80 y máximo 0, que son los valores del AudioMixer
    public AudioMixer audioMixer;

    void Start()
    {
        this.SetVolumen(this.GetComponent<Slider>().value);
    }
    

    public void SetVolumen(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}

