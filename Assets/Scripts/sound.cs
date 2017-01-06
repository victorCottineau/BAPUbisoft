using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip soundeffectarrive;
    private AudioSource zic;

    public Animator animator;

    public bool h;
    public bool positiontemple;


    void Awake()
    {
        zic = GetComponent<AudioSource>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Trigger 2", h);
    }

    void OnTriggerEnter(Collider other)
    {
        //Joueur arrive à destination
        if ((other.gameObject.name == "box sound start") || (other.gameObject.name == "box sound arrivee 2") || (other.gameObject.name == "box sound arrivee 3") || (other.gameObject.name == "box sound arrivee 4"))
        {
            //Joue son poussette qui ralentis
            zic.PlayOneShot(soundeffectarrive);
            
        }

    }
    
    //Arrivé à destination
    void OnTriggerStay(Collider other)
    {
        //Arrivé au temple 
        if (other.gameObject.name == "box trigger 2")
           {
            positiontemple = true;
        }
        else
        {
            positiontemple = false;
        }
    }
    


   
}

