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

    public Animator Carillon;

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
                Carillon.SetBool("Left", true);
                Carillon.SetBool("Right", false);
                Carillon.SetBool("Front", false);
                Carillon.SetBool("Back", false);
                Debug.Log("Left");
                sons.Stop();
                sons.PlayOneShot(carillon1);
                StartCoroutine(LeftFalse());
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                Carillon.SetBool("Left", false);
                Carillon.SetBool("Right", true);
                Carillon.SetBool("Front", false);
                Carillon.SetBool("Back", false);
                sons.Stop();
                sons.PlayOneShot(carillon2);
                StartCoroutine(RightFalse());
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Carillon.SetBool("Left", false);
                Carillon.SetBool("Right", false);
                Carillon.SetBool("Front", true);
                Carillon.SetBool("Back", false);
                sons.Stop();
                sons.PlayOneShot(carillon3);
                StartCoroutine(FrontFalse());
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Carillon.SetBool("Left", false);
                Carillon.SetBool("Right", false);
                Carillon.SetBool("Front", false);
                Carillon.SetBool("Back", true);
                sons.Stop();
                sons.PlayOneShot(carillon4);
                StartCoroutine(BackFalse());
            }
        }
    }
    IEnumerator LeftFalse()
    {
        yield return new WaitForSeconds(1);
        Carillon.SetBool("Left", false);
    }
    IEnumerator RightFalse()
    {
        yield return new WaitForSeconds(1);
        Carillon.SetBool("Right", false);
    }
    IEnumerator FrontFalse()
    {
        yield return new WaitForSeconds(1);
        Carillon.SetBool("Front", false);
    }
    IEnumerator BackFalse()
    {
        yield return new WaitForSeconds(1);
        Carillon.SetBool("Back", false);
    }
}
