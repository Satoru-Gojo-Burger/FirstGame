using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;
        public AudioSource Fx;
        public AudioClip FailFx;

        private void OnEnable()
        {
            rootUI.SetActive(true);    
            Fx.PlayOneShot(FailFx);       
        }

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
            }
        }
        

        public void Restart()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void BackToManinMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }
    }
}
