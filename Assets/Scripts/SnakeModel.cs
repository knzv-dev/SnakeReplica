using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SnakeModel
{

    public Vector2 FacingDirection { get; set; }
    private List<Vector2> _positions;

    public SnakeModel(Vector2 facingDirection, ICollection<Vector2> initialCoordinates)
    {
        _positions = new List<Vector2>(initialCoordinates);
        this.FacingDirection = facingDirection;
    }

    public List<Vector2> MoveForward()
    {
        Vector2[] result = new Vector2[_positions.Count];
        Vector2 prevHeadPos = Vector2.zero;
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

        _positions = new List<Vector2>(result);
        return new List<Vector2>(result);
    }
}