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

    // Start is called before the first frame update
    void Start()
    {
        content_position = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_porition = Input.mousePosition;

        

        if (Input.GetMouseButton(0))
        {

            if (content_position.localPosition.y < 0) { content_position.Translate(new Vector3(0, Time.deltaTime)); }
            if (content_position.localPosition.y > 25) { content_position.Translate(new Vector3(0, -Time.deltaTime)); }

            if ((current_porition != prev_position) && content_position.localPosition.y >= 0.0f && content_position.localPosition.y <= 25.0f)
            {

                content_position.Translate(slide_velocity * Time.deltaTime * new Vector3(0, current_porition.y - prev_position.y).normalized);
            }

            

            prev_position = current_porition;
        }

    }

}
