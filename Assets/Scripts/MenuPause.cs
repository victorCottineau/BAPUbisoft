using UnityEngine;
using System.Collections;


public class MenuPause : MonoBehaviour {

    private bool isPaused = false;
    public GameObject ButtonContinuer ;
    public GameObject ButtonRecommencer ;
    public GameObject ButtonQuitter ;
    public Animator animationb ;
    public GameObject PanelFondMenuPause;

    void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
        }

        if (isPaused) {
            Time.timeScale = 0f;
            (ButtonContinuer.gameObject).SetActive(true);
            (ButtonRecommencer.gameObject).SetActive(true);
            (ButtonQuitter.gameObject).SetActive(true);
            (PanelFondMenuPause.gameObject).SetActive(true);
        }

        if (!isPaused){
            Time.timeScale = 1f;
            (ButtonContinuer.gameObject).SetActive(false);
            (ButtonRecommencer.gameObject).SetActive(false);
            (ButtonQuitter.gameObject).SetActive(false);
            (PanelFondMenuPause.gameObject).SetActive(false);
        }
	}

    public void pause ()
    {
       
        isPaused = !isPaused;
    }

    public void recommencer ()
    {
        animationb.Rebind();
        StartCoroutine(Example());
        isPaused = !isPaused;
        
    }

    public void quitter()
    {
        Application.Quit();
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        
    }

}
