using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    [SerializeField]
    RawImage texture;
    [SerializeField]
    List<VideoPlayer> playerList;
    [SerializeField]
    Animator anim;

    int clicked;
    bool timer = false;
    float time = 0;
    bool tapped = false;
    // Start is called before the first frame update
    void Start()
    {
        VideoRestart();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            
            time += Time.deltaTime;
            if (time >= 1.5f)
            {
                if (tapped) 
                {
                    anim.gameObject.SetActive(true);
                    tapped = false;
                }

            }
            if(time >= 2)
            {
                timer = false;
                time = 0;
            }
        }

        if (Input.GetMouseButtonDown(0)&& !timer)
        {
            
                anim.SetTrigger("Axe_hitted");
                timer = true;
                if (clicked == 2)
                {
                    tapped = true;
                    VideoRestart();
                    
                }
            
        }

    }
        public void VideoRestart()
    {

        playerList[1].gameObject.SetActive(false);
        playerList[2].gameObject.SetActive(false);
        playerList[0].gameObject.SetActive(true);
       
        playerList[0].Stop() ;
        playerList[0].Play();
        anim.gameObject.SetActive(true);
        clicked = 0;
        
    }

    public void UseAxe()
    {
        
            playerList[clicked].Pause();
            playerList[clicked].gameObject.SetActive(false);
            clicked++;
            if (clicked == 2) { anim.gameObject.SetActive(false); }
            
            playerList[clicked].gameObject.SetActive(true);
            playerList[clicked].Play();

        
    }










}
