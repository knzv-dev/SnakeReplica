using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveService : MonoBehaviour
{

    public float StartDelay = 1.0f;
    public float TickDelay = 1.0f;

    private IMovable[] _moveables;
    // Start is called before the first frame update
    void Start()
    {
        _moveables = GetComponents<IMovable>();

        InvokeRepeating("Move", StartDelay, TickDelay);
    }

    void Move()
    {
        foreach (var moveable in _moveables)
        {
            moveable.Move();
        }
    }

}
