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

    // Start is called before the first frame update
    void Start()
    {
        content_position = GetComponent<RectTransform>();
        isDoubleClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_porition = Input.mousePosition;

        #region DoubleClick

        if (Input.GetMouseButtonDown(0) && !isDoubleClicked)
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
                Debug.Log("dasda"); 
            clicked = 0;
            clicktime = 0;
            isDoubleClicked = true;
            content_position.Translate(new Vector3(0, 13));
        }
        else if (clicked > 2 || Time.time - clicktime > 1)
        {
            clicked = 0;
        }
        #endregion

        #region Sliding
        if (Input.GetMouseButton(0) && isDoubleClicked)
        {

            if (content_position.localPosition.y < 13) { content_position.Translate(new Vector3(0, 13f - content_position.localPosition.y));Debug.Log("¬низ"); }
            if (content_position.localPosition.y > 25) { content_position.Translate(new Vector3(0, - (content_position.localPosition.y - 25f))); Debug.Log("¬верх"); }

            if ((current_porition != prev_position) && content_position.localPosition.y >= 13f && content_position.localPosition.y <= 25.0f)
            {

                content_position.Translate(slide_velocity * Time.deltaTime * new Vector3(0, current_porition.y - prev_position.y).normalized);
            }

            

            prev_position = current_porition;
        }
        #endregion
    }

}
