using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMoving : MonoBehaviour
{
    [SerializeField]
    float slide_velocity;

    RectTransform content_position;
    Vector3 prev_position;

    bool isDoubleClicked;
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.3f;

    [SerializeField]
    float max_afk_time;
    [SerializeField]
    float min_touch_time;


    float touch_time = 0;
    float afk_time;
    bool timer = false;
    // Start is called before the first frame update
    void Start()
    {
        content_position = GetComponent<RectTransform>();
        isDoubleClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 current_porition = Input.mousePosition * 100;

        #region DoubleClick

        if (Input.GetMouseButtonDown(0) && !isDoubleClicked)
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            //Debug.Log("Двойной клик"); 
            clicked = 0;
            clicktime = 0;
            isDoubleClicked = true;
            content_position.Translate(new Vector3(0, 1400));
        }
        else if (clicked > 2 || Time.time - clicktime > 1)
        {
            clicked = 0;
        }
        #endregion

        #region Sliding
        if (Input.GetMouseButton(0) && isDoubleClicked)
        {
            if (touch_time <= min_touch_time)
            {
                touch_time += Time.deltaTime;
         //     Debug.Log(touch_time);
            }
            else
            {
                if (content_position.localPosition.y < 14) { content_position.Translate(new Vector3(0, (14f - content_position.localPosition.y) * 100)); /*Debug.Log("Вниз");*/ }
                if (content_position.localPosition.y > 25) { content_position.Translate(new Vector3(0, -(content_position.localPosition.y - 25f) * 100)); /*Debug.Log("Вверх");*/ }

                if ((current_porition != prev_position) && content_position.localPosition.y >= 14f && content_position.localPosition.y <= 25.0f)
                {

                    content_position.Translate(slide_velocity * Time.deltaTime * (new Vector3(0, current_porition.y - prev_position.y).normalized * 100));
                }

            }

            prev_position = current_porition;

        }
        else if (Input.GetMouseButtonUp(0) && isDoubleClicked)
        {
            touch_time = 0;
       //   Debug.Log("Обнуление");
        }
        #endregion

        #region AFK_Timer

        if (isDoubleClicked)
        {
            timer = true;
            
            if (timer)
            {
                if (Input.GetMouseButton(0)) { afk_time = 0; }
                afk_time += Time.deltaTime;
      //        Debug.Log(time);
            }
            if (afk_time >= max_afk_time)
            {
                timer = false;
                afk_time = 0;
                isDoubleClicked = false;
                content_position.Translate(0, -(content_position.localPosition.y * 100), 0);
            }
        }

        #endregion
    }


}