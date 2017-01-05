using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounddepart : MonoBehaviour
{

    public AudioClip soundeffectdepart;
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
        animator.SetBool("trigger 2", h);
    }

    void OnTriggerStay()
    {
        zic.PlayOneShot(soundeffectdepart);
        /*if (col.gameObject.name == "box trigger 1")
        {

            print("coucou");
           
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //ok = animator.GetTrigger("Trigger 2");
        print(h);
    }

    void OnStateEnter()
    {

    }
}

