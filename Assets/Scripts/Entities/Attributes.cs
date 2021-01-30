using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public float WalkingSpeed = 5;


    public float AttackDistance = 1;



    public float Health = 10;


    public float Attack = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Applies damage to this entity. 
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        Health -= amount; 
    }
}
