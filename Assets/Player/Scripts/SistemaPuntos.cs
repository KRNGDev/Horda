using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaPuntos : MonoBehaviour
{
    public int puntos = 1;
    private int totalPuntos = 0;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoTotal;
    public TextMeshProUGUI textoTotalGameover;
    public AudioClip moneda;

    void Start()
    {
        textoPuntos.GetComponent<TextMeshProUGUI>().SetText(totalPuntos.ToString());
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))
        {

            GetComponent<AudioSource>().PlayOneShot(moneda);

            totalPuntos += puntos;
            textoPuntos.GetComponent<TextMeshProUGUI>().SetText(totalPuntos.ToString());
            textoTotal.GetComponent<TextMeshProUGUI>().SetText(totalPuntos.ToString());
            textoTotalGameover.GetComponent<TextMeshProUGUI>().SetText(totalPuntos.ToString());

        }
    }
}
