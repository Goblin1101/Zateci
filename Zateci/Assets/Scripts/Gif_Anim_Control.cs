using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gif_Anim_Control : MonoBehaviour
{
    [SerializeField]
    Animator Axe_anim;
    [SerializeField]
    Animator Shell_anim;

    int clicked = 0;

    bool timer = false;
    float time = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            time += Time.deltaTime;
            if (time >= 0.8)
            {
                timer = false;
                time = 0;
            }
        }
        else
        {
            if (clicked == 3)
            {   

                ResetAnim();
            }

            if (Input.GetMouseButtonDown(0))
            {
                timer = true;
                clicked++;
                //               Axe_anim.SetTrigger("Axe_hitted");
                HitAxe();
            }
        }
    }
    public void ResetAnim()
    {
        clicked = 0;
        Shell_anim.SetInteger("count", 3);
        Axe_anim.gameObject.SetActive(true);
        time = 0;
        timer = true;
    }
    public void HitAxe()
    {
        Shell_anim.SetInteger("count", clicked);
        
        if (clicked == 2) 
        {
            Axe_anim.gameObject.SetActive(false);
        }
    }
}
