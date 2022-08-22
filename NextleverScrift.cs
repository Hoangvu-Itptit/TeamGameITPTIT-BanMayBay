using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextleverScrift : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Instantiate()
            GameController.gameController.NextLever();
            CreatLeverconntroller.creat.CreatLever();
            Camera.Instan.nextcamera();
        }
    }
}
