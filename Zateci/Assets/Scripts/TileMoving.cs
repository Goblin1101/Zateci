using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMoving : MonoBehaviour
{
    RectTransform content_position;
    Vector3 prev_position = new(361.4f, 222.6f);


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
            content_position.Translate(current_porition - prev_position );
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            prev_position = current_porition;
        }
    }

}
