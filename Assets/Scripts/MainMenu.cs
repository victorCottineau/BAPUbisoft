using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void jouer()
    {
        SceneManager.LoadScene(1);
    }

    public void quitter()
    {
        Application.Quit();
    }

}
