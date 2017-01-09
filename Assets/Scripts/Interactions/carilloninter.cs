using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carilloninter : MonoBehaviour {


    public bool condregarde;
    public bool condposition;

    public AudioClip carillon1;
    public AudioClip carillon2;
    public AudioClip carillon3;
    public AudioClip carillon4;
    private AudioSource sons;

    public Raycast raycastscript;
    public sound soundscript;

  	void Awake()
    {
        sons = GetComponent<AudioSource>();
    }

    void Update()
    {
        condregarde = raycastscript.interactioncarillon;
        condposition= soundscript.positiontemple;
        jouer();
    }


    void jouer()
    {
        if ((condregarde == true) & ( condposition == true) )
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                sons.Stop();
                sons.PlayOneShot(carillon1);              
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                sons.Stop();
                sons.PlayOneShot(carillon2);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                sons.Stop();
                sons.PlayOneShot(carillon3);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                sons.Stop();
                sons.PlayOneShot(carillon4);
            }
        }
    }
}
