using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AFK_Timer : MonoBehaviour
{
    [SerializeField]
    float max_afk_time;
    float afk_time = 0;
    bool timer = false;

    [SerializeField]   
    public UnityEvent OnTimerEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !timer)
            TimerStart();

            if (timer)
        {
            if (Input.GetMouseButtonDown(0)) { afk_time = 0; }
            afk_time += Time.deltaTime;
         // Debug.Log(afk_time);
        }
        if (afk_time >= max_afk_time)
        {
            timer = false;
            afk_time = 0;
            OnTimerEnd.Invoke();
        }
    }
    public void TimerStart()
    {
        timer = true;
    }



}
