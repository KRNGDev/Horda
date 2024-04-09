using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour
{

    [Header("Paneles del Menu")]
    public GameObject panelOpciones;
    public GameObject panelJuego;
    public GameObject panelFondo;
    public GameObject panelBotones;
    public GameObject panelLogo;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MostrarPanel(string panel)
    {

        panelOpciones.SetActive(false);
        panelJuego.SetActive(false);
        panelFondo.SetActive(false);
        panelBotones.SetActive(false);
        panelLogo.SetActive(false);

        switch (panel)
        {
            case "juego":
                panelJuego.SetActive(true);
                break;
            case "opciones":
                panelOpciones.SetActive(true);
                break;
            case "fondo":
                panelFondo.SetActive(true);
                break;
            case "botones":
                panelBotones.SetActive(true);
                break;
            case "logo":
                panelLogo.SetActive(true);
                break;


        }



    }
    public void CargarScena(string nombre)
    {
        SceneManager.LoadScene(name);
    }





}
