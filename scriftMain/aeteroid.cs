using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aeteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed;
    void Start()
    {
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
    }
}
