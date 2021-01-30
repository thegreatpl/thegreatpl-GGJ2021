using Assets.Scripts.Entities.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
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
        
    }


    protected void DumbMoveToPostion(Vector3 position)
    {
        var distance = position - transform.position; 

        if (System.Math.Abs(distance.x) > System.Math.Abs(distance.y))
        {
            if (distance.x < 0)
            {
                Movement.MovementDirection = Direction.Left;
            }
            else
            {
                Movement.MovementDirection = Direction.Right; 
            }
        }
        else
        {
            if (distance.y < 0)
            {
                Movement.MovementDirection = Direction.Down;
            }
            else
            {
                Movement.MovementDirection = Direction.Up;
            }
        }
    }

    protected void Wander()
    {
        if (Random.Range(0, 100) > 90)
        {
            Movement.MovementDirection = Extensions.RandomDiraction();
        }
    }



   
}
