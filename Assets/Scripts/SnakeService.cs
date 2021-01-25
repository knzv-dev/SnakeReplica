﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnakeService : MonoBehaviour, IMovable, IDamageable, IGrowable
{
    public Vector2Int currentDirection = Vector2Int.up;

    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Tile headTile;
    [SerializeField]
    private Tile bodyTile;
    [SerializeField]
    private Tile wallTile;
    [SerializeField]
    private Tile foodTile;

    private int health = 1;

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
        if (health > 0)
        {
            List<Vector2Int> prevPosition = snakeModel.GetCurrentPosition();
            Vector2Int nextHeadPosition = prevPosition[0] + snakeModel.FacingDirection;
            Tile nextTile = tilemap.GetTile<Tile>(new Vector3Int(nextHeadPosition.x, nextHeadPosition.y, 0));
            if (nextTile == wallTile)
            {
                TakeDamage(1);
            } else if (nextTile == foodTile)
            {
                Grow();
            }
            List<Vector2Int> newPosition = snakeModel.MoveForward();
            RedrawSnake(prevPosition, newPosition);
        } else
        {
            Debug.Log("You DEAD :)");
        }
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

    public void TakeDamage(int amount)
    {
        health -= 1;
    }

    public void Grow()
    {
        snakeModel.ShouldGrowOnNextMove();
    }
}