using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour
{

    [Header("Paneles del Menu")]
    public GameObject panelOpciones;
    public GameObject panelJuego;




    public void MostrarPanel(string panel)
    {


        switch (panel)
        {
            case "juego":
                panelOpciones.SetActive(false);
                panelJuego.SetActive(false);
                panelJuego.SetActive(true);
                break;
            case "opciones":
                panelOpciones.SetActive(false);
                panelJuego.SetActive(false);
                panelOpciones.SetActive(true);
                break;

            case "ocultar":
                panelOpciones.SetActive(false);
                panelJuego.SetActive(false);
                break;


        }



    }
    public void CargarScena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }





}
