using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : BaseAI
{

    public int RemainingLife; 

    public GameObject Target; 
    // Start is called before the first frame update
    void Start() 
    {
        Movement = GetComponent<Movement>();
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

        RemainingLife--;
        if (RemainingLife < 0)
            Death();
    }

    void Death()
    {
        Destroy(gameObject); 
    }
    
}
