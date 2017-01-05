using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetourDebut : MonoBehaviour {

    public Animator animator;
    public Animator animatorpanelhaut;
    public Animator animatorpanelbas;
   // public GameObject PanelFlash ;
    public GameObject PanelHaut;
    public GameObject PanelBas;
    public bool flash;
    /* int i = 0;
    float pivothx ;
    float pivothy ;
    float pivotbx ;
    float pivotby ;
    */
    

    void Start () {
     
    }

    void OnTriggerStay(Collider col){
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Example());
        }  
    }

    IEnumerator Example()
    {
              
        animatorpanelhaut.SetBool("panel haut ferme", true);
        animatorpanelbas.SetBool("panel bas ferme", true);

        yield return new WaitForSeconds(3);
        animator.Play("AtoTrigger1", -1, 1f);
        //(PanelFlash.gameObject).SetActive(false);
        animator.SetBool("Trigger 2", false);
        animator.SetBool("Trigger 3", false);
        animator.SetBool("Trigger 4", false);
        yield return new WaitForSeconds(3);

        animatorpanelhaut.SetBool("panel haut ferme", false);
        animatorpanelhaut.Play("ouvert", -1, 1f);
        animatorpanelbas.SetBool("panel bas ferme", false);
        animatorpanelbas.Play("ouvert2", -1, 1f);

        /*
        for (i = 0; i < 10; i++){
            pivothx = pivothx - 1;
            pivothy = pivothy - 1;
            pivotbx = pivotbx + 1;
            pivotby = pivotby + 1;
        }
        */
    }
    
    void Update()
    {
        
    }
}
