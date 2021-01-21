using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnakeMovingSystem : MonoBehaviour
{

    public Tilemap tilemap;
    public Tile snakeHeadTile;
    public Tile snakeBodyTile;

    public SnakeModel snakeModel;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnakeForward", 1.0f, 1.0f);

        LinkedList<Vector2> snakePositions = new LinkedList<Vector2>();
        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                Tile tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile != null )
                {
                    // fixme: this part does not work
                    if (tile.GetType() == snakeBodyTile.GetType())
                    {
                        snakePositions.AddLast(new Vector2(x, y));
                    }
                    if (tile.GetType() == snakeHeadTile.GetType())
                    {
                        snakePositions.AddFirst(new Vector2(x, y));
                    }
                }
            }
        }
        

        snakeModel = new SnakeModel(Vector2.up, snakePositions);
    }


    void MoveSnakeForward()
    {
        Debug.Log(snakeModel.MoveForward().ToString());
    }
}
