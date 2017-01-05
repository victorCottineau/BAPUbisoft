using UnityEngine;
using System.Collections;

public class choix : MonoBehaviour {
    public Animator animator;
    //public GameObject Trig1;
   

    // Use this for initialization
    void Start () { 
    }

    // Update is called once per frame

    void OnTriggerStay(Collider col) {
        if (col.gameObject.name == "box trigger 1")
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                animator.SetBool("Trigger 2", true);
                //animator.SetBool("Wait", true);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("Trigger 3", true);
                //animator.SetBool("Wait", true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("Trigger 4", true);
                //animator.SetBool("Wait", true);
            }

        }
    }

    /*void OnTriggerEnter(Collider col)
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        animator.SetBool("Wait", true);
    }

    void OnTriggerExit (Collider col)
    {
        animator.SetBool("Wait", false);
    }*/



    void Update() {
        
    }
}



