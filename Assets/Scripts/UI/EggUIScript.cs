using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggUIScript : MonoBehaviour
{
    public Text DisplayText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText.text = $"{GameManager.GM.Eggs}";
    }
}
