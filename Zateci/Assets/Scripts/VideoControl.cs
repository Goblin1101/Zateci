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
    VideoPlayer player;

    [SerializeField]
    int max_time_first;
    [SerializeField]
    RawImage texture;
    [SerializeField]
    Image scar;
    [SerializeField]
    Image text;


    int clicked;

    // Start is called before the first frame update
    void Start()
    {
        scar.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        clicked = 0;
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if (clicked == 1)
            {
                scar.gameObject.SetActive(false);
                player.Play();
                clicked++;

            }
            if (clicked == 0)
            {
                player.Pause();
                scar.gameObject.SetActive(true);
                player.frame = 160;
                clicked++;
          //      Debug.Log(clicked);
            }
            
        }

        if (player.frame == max_time_first && clicked == 0)
        {
            player.Pause();
            player.frame = 12;
            player.Play();
        }
        if (player.frame == 179)
        {
            texture.gameObject.SetActive(false);
            text.gameObject.SetActive(true);
        }



    }
        public void VideoRestart()
    {
        
        scar.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        texture.gameObject.SetActive(true);
        clicked = 0;
        player.Stop();
        player.Play();
        //Debug.Log("ресет");
    }












}
