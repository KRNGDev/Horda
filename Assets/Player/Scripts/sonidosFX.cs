using System;
using UnityEngine;
namespace Player
{
    public class sonidosFX : MonoBehaviour
    {

        [Header("Audios Genericos")]
        public AudioClip audioCaidaPesada;
        public AudioClip alientoPlayer;
        public AudioClip audioEspada;

        [Header("Audios Player")]
        public AudioClip audioPisada1;
        public AudioClip audioPisada2;
        public AudioClip audioPisada;
        public AudioClip gritoSalto;
        public AudioClip audioCaer;
        public AudioClip audioSaltar;

        [Header("Audios Enemigo")]
        public AudioClip alientoEnemigo;
        [Header("Audios efectos")]
        public AudioClip fuego;
        public AudioClip hielo;




        public void FxSonido(String sonido)
        {

            switch (sonido)
            {

                case "aliento":
                    GetComponent<AudioSource>().PlayOneShot(alientoPlayer);
                    break;
                case "alientoEnemigo":
                    GetComponent<AudioSource>().PlayOneShot(alientoEnemigo);
                    break;
                case "sonidoEspada":
                    GetComponent<AudioSource>().PlayOneShot(audioEspada);
                    break;
                case "pisada":
                    GetComponent<AudioSource>().PlayOneShot(audioPisada);
                    break;
                case "pisada1":
                    GetComponent<AudioSource>().PlayOneShot(audioPisada1);
                    break;
                case "pisada2":
                    GetComponent<AudioSource>().PlayOneShot(audioPisada2);
                    break;
                case "caer":
                    GetComponent<AudioSource>().PlayOneShot(audioCaer);
                    break;
                case "saltar":
                    GetComponent<AudioSource>().PlayOneShot(audioSaltar);
                    break;
                case "gritoSalto":
                    GetComponent<AudioSource>().PlayOneShot(gritoSalto);
                    break;
                case "caidaPesada":
                    GetComponent<AudioSource>().PlayOneShot(audioCaidaPesada);
                    break;
                case "fuego":
                    GetComponent<AudioSource>().PlayOneShot(fuego);
                    break;
                case "hielo":
                    GetComponent<AudioSource>().PlayOneShot(hielo);
                    break;
            }

        }
    }
}