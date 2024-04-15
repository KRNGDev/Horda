using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //Atributos del juego
    public float salud;
    public int saludMaxima;
    public int puntuacion=0;
    public int puntuacionMaxima=0;

    //ESTO SE PUEDE HACER CON EVENTOS
    public Image imageVida;
    public TextMeshProUGUI textoPuntuacion;
    public TextMeshProUGUI textoPuntuacionMaxima;

    public List<GameObject> objetosAActivarCuandoGameOver;

    private static string KEY_HIGHSCORE = "HIGHSCORE"; 

    private void Awake()
    {
        if (PlayerPrefs.HasKey(KEY_HIGHSCORE)){
            puntuacionMaxima = PlayerPrefs.GetInt(KEY_HIGHSCORE);
        } else {
            puntuacionMaxima = 0;
        }
        textoPuntuacion.text=puntuacion.ToString();
        textoPuntuacionMaxima.text=puntuacionMaxima.ToString();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start(){
        ActualizarBarraDeSalud();
    }

    private void Update(){
        if (salud==0){
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                ReiniciarJuego();
            }
        }
    }

    public void DecrementarSalud(int decrementoSalud)
    {
        salud=salud-decrementoSalud;
        if (salud<=0){
            salud=0;
            TerminarJuego();
        }
        ActualizarBarraDeSalud();
    }
    public void IncrementarSalud(int incrementoSalud)
    {
        salud=salud+incrementoSalud;
        if (salud>=saludMaxima){
            salud=saludMaxima;
        }
        ActualizarBarraDeSalud();
    }
    private void ActualizarBarraDeSalud(){
        imageVida.fillAmount=salud/saludMaxima;
    }
    public void TerminarJuego(){
        //1. Aparecen los textos de GameOver y de continuar y el resto de objetos que quieras
        foreach (GameObject objeto in objetosAActivarCuandoGameOver){
            objeto.SetActive(true);
        }
        //2. Guardar la puntuación si es puntuación máxima?
        if (puntuacion>puntuacionMaxima){
            PlayerPrefs.SetInt(KEY_HIGHSCORE, puntuacion);
            PlayerPrefs.Save();
        }
    }

    public void ReiniciarJuego(){
        SceneManager.LoadScene(0);
    }
    public void Puntuar(int puntuacion){
        this.puntuacion+=puntuacion;
        this.textoPuntuacion.text=this.puntuacion.ToString();
    }
}
