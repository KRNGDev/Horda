using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private static string KEY_VOLUME = "Volumen";
    public AudioSource audiosourceBSO;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        RestoreVolume();
        GameObject.Find("PanelOpciones").SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void RestoreVolume()
    {
        if (PlayerPrefs.HasKey(KEY_VOLUME))
        {
            GameObject.Find("SliderVolumen").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volumen");

        }
    }
    public void SaveAudioVolume()
    {
        PlayerPrefs.SetFloat(KEY_VOLUME, GameObject.Find("SliderVolumen").GetComponent<Slider>().value);
        PlayerPrefs.Save();
    }
    public void ModificarVolumen()
    {
        audiosourceBSO.volume = GameObject.Find("SliderVolumen").GetComponent<Slider>().value;
    }
}
