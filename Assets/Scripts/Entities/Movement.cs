using Assets.Scripts.Entities.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /// <summary>
    /// The animation component associated with this entity. 
    /// </summary>
    public AnimatorScript AnimatorScript;

    public Attributes Attributes; 

    public Direction _movementDirection; 

    public Direction MovementDirection
    {
        get
        {
            return _movementDirection; 

        }
        set
        {
            if (value == Direction.None && _movementDirection != Direction.None)
            {
                FacingDirection = _movementDirection;
                _movementDirection = Direction.None;
            }
            else
                _movementDirection = value; 
        }
    }

    public Direction FacingDirection; 


    // Start is called before the first frame update
    void Start()
    {
        AnimatorScript = GetComponent<AnimatorScript>();
        Attributes = GetComponent<Attributes>(); 
        FacingDirection = Direction.Down;
        _movementDirection = Direction.None; 
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimatorScript.QueuedAnimation == null) //only move if there is not an attack or hit animation taking place. 
        {
            switch (_movementDirection)
            {
                case Direction.None:
                    switch (FacingDirection)
                    {
                        case Direction.None:
                            break;
                        case Direction.Up:
                            AnimatorScript.SetAnimation("idleup"); 
                            break;
                        case Direction.Right:
                            AnimatorScript.SetAnimation("idleright");
                            break;
                        case Direction.Down:
                            AnimatorScript.SetAnimation("idledown");
                            break;
                        case Direction.Left:
                            AnimatorScript.SetAnimation("idleleft");
                            break;
                    }
                    break;
                case Direction.Up:
                    AnimatorScript.SetAnimation("walkup");
                    transform.position += new Vector3(0, Attributes.WalkingSpeed) * Time.deltaTime; 
                    break;
                case Direction.Right:
                    AnimatorScript.SetAnimation("walkright");
                    transform.position += new Vector3(Attributes.WalkingSpeed, 0) * Time.deltaTime;
                    break;
                case Direction.Down:
                    AnimatorScript.SetAnimation("walkdown");
                    transform.position += new Vector3(0, -Attributes.WalkingSpeed) * Time.deltaTime;
                    break;
                case Direction.Left:
                    AnimatorScript.SetAnimation("walkleft");
                    transform.position += new Vector3(-Attributes.WalkingSpeed, 0) * Time.deltaTime;
                    break;
            }
        }
    }
}
