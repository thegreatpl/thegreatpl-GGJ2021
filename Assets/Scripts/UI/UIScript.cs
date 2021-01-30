using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIScript : MonoBehaviour
{

    public Canvas Canvas; 


    public Text Text; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HideInGameUI()
    {
        Canvas.gameObject.SetActive(false); 
    }

    public void ShowInGameUI()
    {
        Canvas.gameObject.SetActive(true); 
    }


    /// <summary>
    /// Displays the text box on the screen. 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="seconds"></param>
    public void DisplayText(string text, int seconds)
    {
        StopAllCoroutines(); 
        //StopCoroutine("TextTimer");

        Text.text = text; 

        StartCoroutine(TextTimer(seconds)); 
    }


    IEnumerator TextTimer(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Text.text = ""; 
    }
}
