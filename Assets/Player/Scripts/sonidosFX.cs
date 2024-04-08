using System;
using System.Collections;
using UnityEngine;
namespace Player
{
    public class sonidosFX : MonoBehaviour
    {
        [Header("Audios Player")]
        public AudioClip audioAliento;
        public AudioClip audioEspada;
        public AudioClip audioPisada;
        public AudioClip audioCaer;
        public AudioClip audioSaltar;

        [Header("Audios Enemigo")]
        public AudioClip enemigo;

        [Header("Audios Genericos")]
        public AudioClip audioGolpe;



        public void FxSonido(String sonido)
        {
            if (audioAliento || audioEspada || audioPisada || audioCaer || audioSaltar)
            {

                switch (sonido)
                {

                    case "aliento":
                        GetComponent<AudioSource>().PlayOneShot(audioAliento);
                        break;
                    case "sonidoEspada":
                        GetComponent<AudioSource>().PlayOneShot(audioEspada);
                        break;
                    case "pisada":
                        GetComponent<AudioSource>().PlayOneShot(audioPisada);
                        break;
                    case "caer":
                        GetComponent<AudioSource>().PlayOneShot(audioCaer);
                        break;
                    case "saltar":
                        GetComponent<AudioSource>().PlayOneShot(audioSaltar);
                        break;
                    case "golpe":
                        GetComponent<AudioSource>().PlayOneShot(audioGolpe);
                        break;
                }
            }
        }
    }
}