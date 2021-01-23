using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnakeService : MonoBehaviour, IMovable
{
    public Vector2Int currentDirection = Vector2Int.up;

    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Tile headTile;
    [SerializeField]
    private Tile bodyTile;

    private SnakeModel snakeModel;

    private void Start()
    {
        List<Vector2Int> snakePos = ExtractSnakeCoordinates(tilemap, headTile, bodyTile);
        snakeModel = new SnakeModel(currentDirection, snakePos);
    }

    private List<Vector2Int> ExtractSnakeCoordinates(Tilemap tilemap, Tile headTile, Tile bodyTile)
    {
        LinkedList<Vector2Int> snakePositions = new LinkedList<Vector2Int>();
        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                Tile tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    if (tile == headTile)
                    {
                        snakePositions.AddFirst(new Vector2Int(x, y));
                    }
                    if (tile == bodyTile)
                    {
                        snakePositions.AddLast(new Vector2Int(x, y));
                    }
                }
            }
        }
        return new List<Vector2Int>(snakePositions);
    }

    public void Move()
    {
        List<Vector2Int> prevPosition = snakeModel.GetCurrentPosition();
        List<Vector2Int> newPosition = snakeModel.MoveForward();
        RedrawSnake(prevPosition, newPosition);
    }

    public void ChangeDirection(Vector2Int direction)
    {
        if (Vector2.Dot(snakeModel.FacingDirection, direction) != -1)
        {
            snakeModel.FacingDirection = direction;
        }

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
                tilemap.SetTile(position, headTile);
            }
            else
            {
                tilemap.SetTile(position, bodyTile);
            }
        }
    }
}