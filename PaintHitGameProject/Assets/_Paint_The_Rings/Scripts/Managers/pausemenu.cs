using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using OnefallGames;

public class pausemenu : MonoBehaviour

{
    [SerializeField] public GameObject pauseMenuPannel = null;
    public CanvasGroup cg;



    public void PlayClickButtonSound()
    {
        ServicesManager.Instance.SoundManager.PlaySound(ServicesManager.Instance.SoundManager.button);
    }

   public void Hidepausebutton()
    {
        cg.alpha = 0f;
    }


    private void Start()
    {
        cg = GameObject.Find("canvas").GetComponent<CanvasGroup>();
    }
    public void pause()
    {
        PlayClickButtonSound();
        pauseMenuPannel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PlayClickButtonSound();
        pauseMenuPannel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restart()
    {
        PlayClickButtonSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Ingame");
    }

    //public void Loadscene()
    //{
    //    //PlayClickButtonSound();
    //    SceneManager.LoadScene("Loading");
    //    //yield return new WaitForSeconds(0.1f);
    //    //SceneManager.LoadScene("Home");
    //}

    //public void Homebtn()
    //{
    //    PlayClickButtonSound();
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("Home");
    //}

    public void HomeBtn()
    {
        ViewManager.Instance.PlayClickButtonSound();
        Time.timeScale = 1f;
        ViewManager.Instance.LoadScene("Home", 0.25f);
    }
    //public void home()
    //{
    //    ViewManager.Instance.PlayClickButtonSound();
    //    SceneManager.LoadScene("Home");
    //}


}
