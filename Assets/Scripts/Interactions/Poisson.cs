using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisson : MonoBehaviour
{

    public Animator PoissonAnimator;

    Camera CameraJoueur;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    public Renderer rend;

    void Start()
    {
        PoissonAnimator.SetFloat("Speed", 0.0f);
        CameraJoueur = GetComponent<Camera>();
    }

    void Update()
    {
        //déplace la caméra avec la souris
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * -Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);

        //Raycast au centre de l'écran
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        RaycastHit hit;
        Ray ray = CameraJoueur.ScreenPointToRay(new Vector3(x, y));
        Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));

        //Detecte une collision avec le Raycast
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Poisson")
                {
                    rend.material.color = Color.red;
                    PoissonAnimator.SetFloat("Speed", 1.0f);
                }
                else if (hit.collider.tag != "Poisson")
                {
                    rend.material.color = Color.blue;
                    PoissonAnimator.SetFloat("Speed", 0.0f);
                }
            }
        }
    }
}