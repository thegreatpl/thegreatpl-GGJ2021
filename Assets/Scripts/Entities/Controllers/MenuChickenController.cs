using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChickenController : BaseAI
{
    public static int range = 20; 

    public Vector3 TargetPostion; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();
        StartCoroutine(ChooseNewTarget()); 
    }

    // Update is called once per frame
    void Update()
    {
        DumbMoveToPostion(TargetPostion); 
    }

    IEnumerator ChooseNewTarget()
    {
        while(true)
        {
            TargetPostion = new Vector3(Random.Range(-range, range), Random.Range(-range, range)); 

            yield return new WaitForSeconds(Random.Range(10, 20)); 
        }
    }
}
