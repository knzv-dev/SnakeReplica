using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public SnakeMovingSystem snakeMovingSystem;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            Debug.Log("Direction changed to: UP");
            snakeMovingSystem.snakeModel.FacingDirection = Vector2Int.up;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Debug.Log("Direction changed to: DOWN");
            snakeMovingSystem.snakeModel.FacingDirection = Vector2Int.down;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("Direction changed to: RIGHT");
            snakeMovingSystem.snakeModel.FacingDirection = Vector2Int.right;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log("Direction changed to: LEFT");
            snakeMovingSystem.snakeModel.FacingDirection = Vector2Int.left;
        }
    }
}
