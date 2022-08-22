using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenuButtonScrift : MonoBehaviour
{
    public Button HomeMenuButton;
    public Button BackButton;
    public Button EndButton;
    public Button RestartButton;
    public Button VolumeButton;
    public GameObject HomeMenuWindow;
    public Boolean kt;
    
    // Start is called before the first frame update
    void Start()
    {
        kt = true;
    }

    // Update is called once per frame
    void Update()
    {
        HomeMenuButton.onClick.AddListener(HomeMenu);
        BackButton.onClick.AddListener(backButton);
        EndButton.onClick.AddListener(endButton);
        if(kt){
            kt = false;
            RestartButton.onClick.AddListener(restartButton);
        }
        VolumeButton.onClick.AddListener(volumeButton);
    }

    void HomeMenu()
    {
        HomeMenuWindow.SetActive(true);
        HomeMenuButton.gameObject.SetActive(false);
        kt = true;
    }

    void backButton()
    {
        HomeMenuWindow.SetActive(false);
        HomeMenuButton.gameObject.SetActive(true);
    }

    void endButton()
    {
        Application.Quit();
    }

    void restartButton()
    {
        CreatLeverconntroller.creat.CreatLever();
        Camera.Instan.nextcamera();
        // RestartButton.gameObject.SetActive(false);
        Debug.Log("restart");
        kt = false;
        backButton();
        return;
    }

    void volumeButton()
    {
        while (GameObject.FindGameObjectWithTag("audio")!=null)
        {
            GameObject audio = GameObject.FindGameObjectWithTag("audio");
            
        }

        
    }
}
