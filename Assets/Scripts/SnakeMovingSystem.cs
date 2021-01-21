using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnakeForward", 1.0f, 1.0f);
    }


    void MoveSnakeForward()
    {
        Debug.Log("Hello");
    }
}
