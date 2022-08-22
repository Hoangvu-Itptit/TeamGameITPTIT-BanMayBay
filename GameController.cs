using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public Text appleDisplay;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameController != null && gameController != this)
        {
            Destroy(this.gameObject); 
        }
        else
        {
            gameController = this;
        }
        string savelocation = Application.persistentDataPath + "/apple.json";
        string dataString = File.ReadAllText(savelocation);
        Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
        appleDisplay.text = gamedata.number.ToString();
    }

    private void LateUpdate()
    {
        string savelocation = Application.persistentDataPath + "/apple.json";
        string dataString = File.ReadAllText(savelocation);
        Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
        appleDisplay.text = gamedata.number.ToString();
    }

    public void Add(int amount)
    {
        //Kiểm tra coi file đã tồn tại hay chưa
        //ghi de vao file
        string savelocation = Application.persistentDataPath + "/apple.json";
        if (File.Exists(savelocation))
        {
            //ghi de
            //doc file
            string dataString = File.ReadAllText(savelocation);
            Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
            gamedata.number += amount;
            dataString = JsonUtility.ToJson(gamedata);
            File.WriteAllText(savelocation, dataString);
        }
        else
        {
            Gamedata gamedata = new Gamedata();
            gamedata.number = 1;
            string str = JsonUtility.ToJson(gamedata);
            File.WriteAllText(savelocation,str);
        }
        
    }

    public void Use(int amount)
    {
        string savelocation = Application.persistentDataPath + "/apple.json";
        //ghi de
        //doc file
        string dataString = File.ReadAllText(savelocation);
        Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
        if (gamedata.number >= amount)
        {
            gamedata.number -= amount;
        }
        dataString = JsonUtility.ToJson(gamedata);
        File.WriteAllText(savelocation, dataString);
    }

    public void NextLever()
    {
        string savelocation = Application.persistentDataPath + "/apple.json";
        if (File.Exists(savelocation))
        {
            //ghi de
            //doc file
            string dataString = File.ReadAllText(savelocation);
            Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
            gamedata.lever += 1;
            dataString = JsonUtility.ToJson(gamedata);
            File.WriteAllText(savelocation, dataString);
        }
        else
        {
            Gamedata gamedata = new Gamedata();
            gamedata.lever = 1;
            string str = JsonUtility.ToJson(gamedata);
            File.WriteAllText(savelocation,str);
        }
    }
}
