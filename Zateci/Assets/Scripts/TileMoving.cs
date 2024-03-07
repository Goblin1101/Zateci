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
            if (current_porition != prev_position)
            {
                content_position.Translate((new Vector3(0,prev_position.y - current_porition.y).normalized)*0.1f);
            }
            prev_position = current_porition;
        }

    }

}
