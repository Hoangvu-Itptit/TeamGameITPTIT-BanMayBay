using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalValue : MonoBehaviour
{
    // Start is called before the first frame update
    public static float screenHeight;
    public static float screenWidth;
    void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * (1.0f * Screen.width / Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
