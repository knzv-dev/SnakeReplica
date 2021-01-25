using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SnakeModel
{

    public Vector2Int FacingDirection { get; set; }
    private LinkedList<Vector2Int> _positions;
    private bool _shouldGrowOnNextMove = false;

    public SnakeModel(Vector2Int facingDirection, ICollection<Vector2Int> initialCoordinates)
    {
        _positions = new LinkedList<Vector2Int>(initialCoordinates);
        this.FacingDirection = facingDirection;
    }


    public List<Vector2Int> GetCurrentPosition()
    {
        return new List<Vector2Int>(_positions);
    }

    public List<Vector2Int> MoveForward()
    {
        if (_shouldGrowOnNextMove)
        {
            _positions.AddLast(new Vector2Int(0, 0));
            _shouldGrowOnNextMove = false;
        }
        if (_positions.Count > 1)
        {
            Vector2Int prevHead = _positions.First.Value;

            _positions.First.Value += FacingDirection;
            _positions.Remove(_positions.Last);
            _positions.AddAfter(_positions.First, prevHead);
        } else
        {
            _positions.First.Value += FacingDirection;
        }


        return new List<Vector2Int>(_positions);
    }

    internal void ShouldGrowOnNextMove()
    {
        _shouldGrowOnNextMove = true;
    }

    private void Grow()
    {

    }
}