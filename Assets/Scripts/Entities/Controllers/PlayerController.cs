using Assets.Scripts.Entities.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Movement Movement; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");

        if (moveX < 0)
            Movement.MovementDirection = Direction.Left;
        else if (moveX > 0)
            Movement.MovementDirection = Direction.Right;

        if (moveY < 0)
            Movement.MovementDirection = Direction.Down;
        else if (moveY > 0)
            Movement.MovementDirection = Direction.Up;

        if (moveX == 0 && moveY == 0)
            Movement.MovementDirection = Direction.None; 

    }
}
