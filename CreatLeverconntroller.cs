using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatLeverconntroller : MonoBehaviour
{
    public static CreatLeverconntroller creat;
    public List<GameObject> levers;
    private int curentLever;
    
    // Start is called before the first frame update
    void Start()
    {
        creat = this;
        string savelocation = Application.persistentDataPath + "/apple.json";
        if (File.Exists(savelocation))
        {
            //ghi de
            //doc file
            string dataString = File.ReadAllText(savelocation);
            Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
            curentLever = gamedata.lever;
        }
        else
        {
            Gamedata gamedata = new Gamedata();
            gamedata.lever = 1;
            curentLever = 1;
        }
        Instantiate(levers[curentLever-1]);
    }

    public void CreatLever()
    {
        string savelocation = Application.persistentDataPath + "/apple.json";
        if (File.Exists(savelocation))
        {
            //ghi de
            //doc file
            string dataString = File.ReadAllText(savelocation);
            Gamedata gamedata = JsonUtility.FromJson<Gamedata>(dataString);
            curentLever = gamedata.lever;
        }
        else
        {
            Gamedata gamedata = new Gamedata();
            gamedata.lever = 1;
            curentLever = 1;
        }

        GameObject leverObj = GameObject.FindGameObjectWithTag("Leverobject");
        Destroy(leverObj);
        Instantiate(levers[curentLever-1]);
    }
    // Update is called once per frame
    void Awake()
    {
        
    }
}
