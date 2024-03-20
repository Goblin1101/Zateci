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
    RawImage texture;
    [SerializeField]
    List<VideoClip> clipList;
    [SerializeField]
    GameObject button;

    int clicked;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        VideoRestart();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {

            if (clicked < 2)
            {
                
                player.Pause();
                player.isLooping = false;
                clicked++;
                player.clip = clipList[clicked];
                player.Play();
            }
            
        }
        if(clicked == 2)
        {

            if (time <= 3) time += Time.deltaTime;
            else button.SetActive(true);
        }

    }
        public void VideoRestart()
    {
        time = 0;   
        button.SetActive(false);
        player.isLooping = true;
        player.clip = clipList[0];
        clicked = 0;
        player.Play();
    }












}
