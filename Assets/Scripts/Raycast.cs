using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Animator Joueur;

    public Animator TempleAnimator;
    public Animator JardinAnimator;
    public Animator LacAnimator;

    Camera camerajoueur;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public float looking;

    public AudioClip soundeffectdepart;
    public AudioClip soundtemple;
    public AudioClip soundjardin;
    public AudioClip soundlac;

    private AudioSource zic;

    public GameObject joueur;
    public bool interactioncarillon;

    private bool Temple;
    private bool Jardin;
    private bool Lac;

    public static bool GoingToTemple;
    public static bool GoingToJardin;
    public static bool GoingToLac;

    public  GameObject TempleTrigger;
    public  GameObject JardinTrigger;
    public  GameObject LacTrigger;

    void Awake()
    {
        zic = GetComponent<AudioSource>();
        interactioncarillon = false;
    }

    void Start()
    {
        looking = 0.0f;
        camerajoueur = GetComponent<Camera>();

        Temple = false;
        Lac = false;
        Jardin = false;

        GoingToJardin = false;
        GoingToLac = false;
        GoingToTemple = false;
    }

    void Update()
    {
        Debug.Log(looking);

        //déplace la caméra avec la souris
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * -Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);

        //Raycast au centre de l'écran
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        RaycastHit hit;
        Ray ray = camerajoueur.ScreenPointToRay(new Vector3(x, y));
        Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));

        //Detecte une collision avec le Raycast
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                //Detecte une collision avec le temple
                if (hit.collider.tag == "Temple")
                {
                    //Temple true
                    TempleAnimator.SetBool("Show", true);
                    TempleAnimator.SetFloat("Speed", 1.0f);

                    //Jardin false
                    JardinFalse();
                    //Lac false
                    LacFalse();

                    //Joue musique que du temple 
                    if (Temple == false)
                    {
                        Temple = true;
                        Jardin = false;
                        Lac = false;
                        zic.Stop();
                        zic.PlayOneShot(soundtemple);
                    }
                    
                    //Carillon false
                    interactioncarillon = false;


                    looking++;
                    if (looking >= 130)
                    {
                        TempleTrigger.GetComponent<BoxCollider>().enabled = false;
                        GoingToTemple = true;
                        Joueur.SetBool("Trigger 2", true);
                        zic.PlayOneShot(soundeffectdepart);

                    }
                }
                //Detecte une collision avec le jardin
                else if (hit.collider.tag == "Jardin")
                {
                    //Jardin true
                    JardinAnimator.SetBool("Show", true);
                    JardinAnimator.SetFloat("Speed", 1.0f);

                    //Temple false
                    TempleFalse();
                    //Lac false
                    LacFalse();

                    //Joue musique que du jardin 
                    if (Jardin == false)
                    {
                        Jardin = true;
                        Temple = false;
                        Lac = false;
                        zic.Stop();
                        zic.PlayOneShot(soundjardin);
                    }
                    
                    //Carillon false
                    interactioncarillon = false;

                    looking++;
                    if (looking >= 130)
                    {
                        JardinTrigger.GetComponent<BoxCollider>().enabled = false;
                        GoingToJardin = true;
                        Joueur.SetBool("Trigger 3", true);
                        zic.PlayOneShot(soundeffectdepart);
                    }
                }
                //Detecte une collision avec le lac
                else if (hit.collider.tag == "Lac")
                {
                    Debug.Log("Lac");
                    //Lac true
                    LacAnimator.SetBool("Show", true);
                    LacAnimator.SetFloat("Speed", 1.0f);

                    //Temple false
                    TempleFalse();
                    //Jardin false
                    JardinFalse();

                    //Joue musique que du lac
                    if (Lac == false)
                    {
                        Lac = true;
                        Temple = false;
                        Jardin = false;
                        zic.Stop();
                        zic.PlayOneShot(soundlac);
                    }
                    
                    //Carillon false
                    interactioncarillon = false;

                    looking++;
                    if (looking >= 130)
                    {
                        LacTrigger.GetComponent<BoxCollider>().enabled = false;
                        GoingToLac = true;
                        Joueur.SetBool("Trigger 4", true);
                        zic.PlayOneShot(soundeffectdepart);
                    }
                }

                //Carillon true
                else if (hit.collider.tag == "Carillon")
                {
                    interactioncarillon=true;
                  
                }

                else
                {
                    //Temple false
                    TempleFalse();
                    //Jardin false
                    JardinFalse();
                    //Lac false
                    LacFalse();

                    //Carillon false
                    interactioncarillon = false;

                    looking = 0;
                }
            }


        }

       
    }

    void TempleFalse()
    {
        AnimatorStateInfo TemplecurrentState = TempleAnimator.GetCurrentAnimatorStateInfo(0);
        float TemplePlayBackTime = TemplecurrentState.normalizedTime;

        if (GoingToTemple == false && (TemplePlayBackTime <= 0 || TemplePlayBackTime >= 1))
        {
            TempleAnimator.Play("TempleIdle");
        }
        else
        {
            TempleAnimator.SetBool("Show", false);
            TempleAnimator.SetFloat("Speed", -1.0f);
        }
    }
    void JardinFalse()
    {
        AnimatorStateInfo JardincurrentState = JardinAnimator.GetCurrentAnimatorStateInfo(0);
        float JardinPlayBackTime = JardincurrentState.normalizedTime;

        if (GoingToJardin == false && (JardinPlayBackTime <= 0 || JardinPlayBackTime >= 1))
        {
            JardinAnimator.Play("JardinIdle");
        }
        else
        {
            Debug.Log("Lac2");
            JardinAnimator.SetBool("Show", false);
            JardinAnimator.SetFloat("Speed", -1.0f);
        }
    }
    void LacFalse()
    {
        AnimatorStateInfo LaccurrentState = LacAnimator.GetCurrentAnimatorStateInfo(0);
        float LacPlayBackTime = LaccurrentState.normalizedTime;

        if (GoingToLac == false && (LacPlayBackTime <= 0 || LacPlayBackTime >= 1))
        {
            LacAnimator.Play("LacIdle");
        }
        else
        {
            JardinAnimator.SetBool("Show", false);
            LacAnimator.SetFloat("Speed", -1.0f);
        }
    }
  
}

