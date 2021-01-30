using Assets.Scripts.Entities.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Movement Movement;

    public Attributes Attributes; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();
        Attributes = GetComponent<Attributes>();
        Attributes.OnDeath += Death;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Attributes.IsAlive)
            return; 

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


    void Death()
    {
        if (!Attributes.IsAlive)
            return;

        Attributes.IsAlive = false;
        Movement.AnimatorScript.SetAnimation("Death", true);
        Movement.AnimatorScript.QueueAnimation("Dead"); 
        StartCoroutine(DeathCoroutine()); 
    }

    IEnumerator DeathCoroutine()
    {        
        //wait for death animation to end, and suitable time while they comtemplate their choices. 
        yield return new WaitForSeconds(20); 
        GameManager.GM.MainCamera.transform.parent = null; 
        Destroy(gameObject);
        GameManager.GM.LoadMenu(); 
    }
}
