using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public SnakeService service;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Vertical") > 0)
        {
            service.ChangeDirection(Vector2Int.up);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            service.ChangeDirection(Vector2Int.down);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            service.ChangeDirection(Vector2Int.right);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            service.ChangeDirection(Vector2Int.left);
        }
    }
}
