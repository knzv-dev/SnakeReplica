using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SnakeModel
{

    public Vector2Int FacingDirection { get; set; }
    private List<Vector2Int> _positions;

    public SnakeModel(Vector2Int facingDirection, ICollection<Vector2Int> initialCoordinates)
    {
        _positions = new List<Vector2Int>(initialCoordinates);
        this.FacingDirection = facingDirection;
    }


    public List<Vector2Int> GetCurrentPosition()
    {
        return new List<Vector2Int>(_positions);
    }

    public List<Vector2Int> MoveForward()
    {
        Vector2Int[] result = new Vector2Int[_positions.Count];
        Vector2Int prevHeadPos = Vector2Int.zero;
        for (int i = 0; i < _positions.Count; i++)
        {
            
            if (i == 0)
            {
                prevHeadPos = _positions[i];
                result[i] = _positions[i] + FacingDirection;
                continue;
            }
            if (_positions.Count > 1)
            {
                if (i != _positions.Count - 1)
                {
                    result[i + 1] = _positions[i];
                }
                else
                {
                    
                    result[1] = prevHeadPos;
                    
                }
            }
            
        }

        _positions = new List<Vector2Int>(result);
        return new List<Vector2Int>(result);
    }
}