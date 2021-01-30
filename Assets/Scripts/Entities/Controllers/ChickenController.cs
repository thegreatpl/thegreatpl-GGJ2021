using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : BaseAI
{
    public GameObject ExplosionPrefab; 


    public int RemainingLife; 

    public Attributes Target; 
    // Start is called before the first frame update
    void Start() 
    {
        Movement = GetComponent<Movement>();
        GetComponent<Attributes>().OnDeath += Death;
        StartCoroutine(DeathCounter(RemainingLife)); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Wander(); 
        }
        else
        {
            DumbMoveToPostion(Target.transform.position); 
        }

        Attack(); 
    }


    void Attack()
    {
        
        if (!Movement.AnimatorScript.RunningQueued 
            && Vector3.Distance(Target.transform.position, transform.position) 
            <= Movement.Attributes.AttackDistance)
        {
            switch (Movement.FacingDirection)
            {
                case Assets.Scripts.Entities.Enums.Direction.None:
                    break;
                case Assets.Scripts.Entities.Enums.Direction.Up:
                    
                    Movement.AnimatorScript.QueueAnimation("attackup");
                    break;
                case Assets.Scripts.Entities.Enums.Direction.Right:
                    Movement.AnimatorScript.QueueAnimation("attackright");
                    break;
                case Assets.Scripts.Entities.Enums.Direction.Down:
                    Movement.AnimatorScript.QueueAnimation("attackdown");
                    break;
                case Assets.Scripts.Entities.Enums.Direction.Left:
                    Movement.AnimatorScript.QueueAnimation("attackleft");
                    break;
            }
            Target.TakeDamage(Movement.Attributes.Attack); 
          
        }
    }


    void Death()
    {
        Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation); 

        Destroy(gameObject); 
    }

    IEnumerator DeathCounter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Death(); 
    }

}
