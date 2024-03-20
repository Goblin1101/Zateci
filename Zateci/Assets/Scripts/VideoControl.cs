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
                playerList[clicked].Pause();
                playerList[clicked].gameObject.SetActive(false);
                clicked++;
                playerList[clicked].gameObject.SetActive(true);
                playerList[clicked].Play();
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
        playerList[1].gameObject.SetActive(false);
        playerList[2].gameObject.SetActive(false);
        playerList[0].gameObject.SetActive(true);
        playerList[0].Stop() ;
        playerList[0].Play();
        clicked = 0;

    }












}
