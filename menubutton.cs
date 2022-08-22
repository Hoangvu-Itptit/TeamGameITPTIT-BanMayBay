using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menubutton : MonoBehaviour
{
    public Button newgame;

    public Button continues;

    public Button hightscore;

    public Button oke;

    public Image hightimg;
    
    public Button end;
    
    
    // Start is called before the first frame update
    void Start()
    {
        newgame.onClick.AddListener(Newgame);
        continues.onClick.AddListener(Continue);
        hightscore.onClick.AddListener(Hight);
        oke.onClick.AddListener(okee);
        end.onClick.AddListener(End);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Newgame()
    {
        Gamedata gamedata = new Gamedata();
        gamedata.audio = true;
        gamedata.lever = 1;
        gamedata.number = 0;
        string savelocation = Application.persistentDataPath + "/apple.json";
        string dataString = JsonUtility.ToJson(gamedata);
        File.WriteAllText(savelocation, dataString);
        SceneManager.LoadScene("gameplay");
    }

    void Continue()
    {
        SceneManager.LoadScene("gameplay");
    }

    void Hight()
    {
        hightimg.gameObject.SetActive(true);
    }

    void okee()
    {
        hightimg.gameObject.SetActive(false);
    }

    void End()
    {
        Application.Quit();
    }
}
