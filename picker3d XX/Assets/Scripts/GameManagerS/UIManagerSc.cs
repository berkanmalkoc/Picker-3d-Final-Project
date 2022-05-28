using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerSc : MonoBehaviour
{
    public GameObject playBttn;
    public GameObject pauseImg;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        pauseImg.SetActive(false);
        playBttn.SetActive(false);
      
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        pauseImg.SetActive(true);

    }


}
