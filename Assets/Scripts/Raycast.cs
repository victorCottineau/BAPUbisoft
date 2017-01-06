using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Animator Joueur;

    public Animator TempleAnimator;
    public Animator JardinAnimator;
    public Animator LacAnimator;

    Camera camera;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public float looking;

    public AudioClip soundeffectdepart;
    public AudioClip soundtemple;
    public AudioClip soundjardin;
    public AudioClip soundlac;

    private AudioSource zic;

    public GameObject joueur;

    void Awake()
    {
        zic = GetComponent<AudioSource>();
    }

    void Start()
    {
        looking = 0.0f;
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        //Debug.Log(looking);

        //déplace la caméra avec la souris
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * -Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);

        //Raycast au centre de l'écran
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(x, y));
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
                    JardinAnimator.SetBool("Show", false);
                    JardinAnimator.SetFloat("Speed", -1.0f);
                    //Lac false
                    LacAnimator.SetBool("Show", false);
                    LacAnimator.SetFloat("Speed", -1.0f);

                   
                    zic.Stop();
                    zic.PlayOneShot(soundtemple);
                   

                    looking++;
                    if (looking >= 170)
                    {
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
                    TempleAnimator.SetBool("Show", false);
                    TempleAnimator.SetFloat("Speed", -1.0f);
                    //Lac false
                    LacAnimator.SetBool("Show", false);
                    LacAnimator.SetFloat("Speed", -1.0f);

                    zic.Stop();
                    zic.PlayOneShot(soundjardin);

                    looking++;
                    if (looking >= 170)
                    {
                        Joueur.SetBool("Trigger 3", true);
                        zic.PlayOneShot(soundeffectdepart);
                    }
                }
                //Detecte une collision avec le lac
                else if (hit.collider.tag == "Lac")
                {
                    //Lac true
                    LacAnimator.SetBool("Show", true);
                    LacAnimator.SetFloat("Speed", 1.0f);

                    //Temple false
                    TempleAnimator.SetBool("Show", false);
                    TempleAnimator.SetFloat("Speed", -1.0f);
                    //Jardin false
                    JardinAnimator.SetBool("Show", false);
                    JardinAnimator.SetFloat("Speed", -1.0f);

                    zic.Stop();
                    zic.PlayOneShot(soundlac);

                    looking++;
                    if (looking >= 170)
                    {
                        Joueur.SetBool("Trigger 4", true);
                        zic.PlayOneShot(soundeffectdepart);
                    }
                }
                else
                {
                    //Temple false
                    TempleAnimator.SetBool("Show", false);
                    TempleAnimator.SetFloat("Speed", -1.0f);
                    //Jardin false
                    JardinAnimator.SetBool("Show", false);
                    JardinAnimator.SetFloat("Speed", -1.0f);
                    //Lac false
                    LacAnimator.SetBool("Show", false);
                    LacAnimator.SetFloat("Speed", -1.0f);

                    looking = 0;
                }
            }


        }

       
        }
    /*
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "box trigger 1")
        {
            print("bouh");
            if (looking >= 170)
            {
                print("coucou");
                zic.PlayOneShot(soundeffectdepart);
            }
        }
    }*/
}

