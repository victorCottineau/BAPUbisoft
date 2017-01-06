using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

   // public AudioClip soundeffectdepart;
    public AudioClip soundeffectarrive;
    private AudioSource zic;

    public Animator animator;

    public bool h;


    void Awake()
    {
        zic = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Trigger 2", h);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "box sound start") || (other.gameObject.name == "box sound arrivee 2") || (other.gameObject.name == "box sound arrivee 3") || (other.gameObject.name == "box sound arrivee 4"))
        {
            zic.PlayOneShot(soundeffectarrive);
        }
        /*if (col.gameObject.name == "box trigger 1")
        {

            print("coucou");
           
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (h == true)
        {
            print(h);
        }
    }

    void OnStateEnter()
    {

    }
}

