using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnakeMovingSystem : MonoBehaviour
{

    public Tilemap tilemap;
    public Tile snakeHeadTile;
    public Tile snakeBodyTile;
    public float tickDelay;

    public SnakeModel snakeModel;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnakeForward", 1.0f, tickDelay);

        LinkedList<Vector2Int> snakePositions = new LinkedList<Vector2Int>();
        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                Tile tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile != null )
                {
                    if (tile == snakeHeadTile)
                    {
                        snakePositions.AddFirst(new Vector2Int(x, y));
                    }
                    if (tile == snakeBodyTile)
                    {
                        snakePositions.AddLast(new Vector2Int(x, y));
                    }
                }
            }
        }

        snakeModel = new SnakeModel(Vector2Int.left, snakePositions);
    }


    void MoveSnakeForward()
    {
        List<Vector2Int> oldPos = snakeModel.GetCurrentPosition();
        List<Vector2Int> newPos = snakeModel.MoveForward();
        RedrawSnake(oldPos, newPos);
    }

    void RedrawSnake(List<Vector2Int> oldPos, List<Vector2Int> newPos)
    {
        foreach (var pos in oldPos)
        {
            tilemap.SetTile(new Vector3Int(pos.x, pos.y, 0), null);
        }

        for (int i = 0; i < newPos.Count; i++)
        {
            Vector3Int position = new Vector3Int(newPos[i].x, newPos[i].y, 0);
            if (i == 0)
            {
                tilemap.SetTile(position, snakeHeadTile);
            } else
            {
                tilemap.SetTile(position, snakeBodyTile);
            }
        }
     }
}
