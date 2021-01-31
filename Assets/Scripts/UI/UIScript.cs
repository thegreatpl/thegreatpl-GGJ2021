using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIScript : MonoBehaviour
{

    public Canvas Canvas; 


    public Text Text;



    public Text GameOverScreen;

    public Image GameOverImage; 
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



    public void ShowDeath()
    {
        GameOverImage.gameObject.SetActive(true); 

        GameOverScreen.text = "Be Lost Forever...";
        GameOverScreen.color = Color.red; 
        GameOverImage.color = new Color(0, 0, 0, 0);
        StartCoroutine(FadeIn()); 
    }


    public void ShowVictoryScreen()
    {
        GameOverImage.gameObject.SetActive(true);
        GameOverScreen.text = "Be found forever";
        GameOverScreen.color = Color.black; 
        GameOverImage.color = new Color(1, 1, 1, 0);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2); 
        while (GameOverImage.color.a < 1)
        {
            GameOverImage.color 
                = new Color(GameOverImage.color.r, GameOverImage.color.g, GameOverImage.color.b, GameOverImage.color.a + 0.01f);
            yield return new WaitForSeconds(0.1f); 
        }
    }

    public void HideEndgameScreen()
    {
        GameOverImage.gameObject.SetActive(false);

    }
}
