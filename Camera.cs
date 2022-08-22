using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public int movespeed;

    public static Camera Instan;
    // Start is called before the first frame update
    void Start()
    {
        if (Instan != null && Instan != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instan = this;
        }
        string savelocation = Application.persistentDataPath + "/apple.json";
        if (!File.Exists(savelocation))
        {
            Gamedata gamedata = new Gamedata();
            gamedata.lever = 1;
            gamedata.number = 0;
            gamedata.audio = true;
            string str = JsonUtility.ToJson(gamedata);
            File.WriteAllText(savelocation,str);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector2 playerposition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 cameraposition = Vector2.MoveTowards(transform.position, playerposition, movespeed * Time.deltaTime);
            cameraposition.z = -1;
            transform.position = cameraposition;
        }
    }

    public IEnumerator Teleport()
    {
        yield return new WaitForEndOfFrame();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector2 playerposition = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = playerposition;
        }
    }

    public void nextcamera()
    {
        StartCoroutine(Teleport());
    }
}
