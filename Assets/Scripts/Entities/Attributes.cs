using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDeath();

public delegate void OnDamage(); 

public class Attributes : MonoBehaviour
{
    public bool IsAlive = true; 
    
    
    public float WalkingSpeed = 5;


    public float AttackDistance = 1;



    public float Health = 10;


    public float Attack = 1;


    public OnDeath OnDeath;


    public OnDamage OnDamage; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
            OnDeath?.Invoke(); 
    }

    /// <summary>
    /// Applies damage to this entity. 
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        Health -= amount;

        OnDamage?.Invoke(); 
    }
}
