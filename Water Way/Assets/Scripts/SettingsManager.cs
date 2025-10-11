using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer Audio;
    
    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void setVolume(float Volume)
    {
        Audio.SetFloat("Volume", Volume);
    }

    public void LoadMenu()
    {
        gameObject.SetActive(false);
    }
}
