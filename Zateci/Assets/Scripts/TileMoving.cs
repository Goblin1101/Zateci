using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMoving : MonoBehaviour
{
    RectTransform tiles_position;
    Vector3 move_distance = new(-6.5f, 8.8f);


    // Start is called before the first frame update
    void Start()
    {
        tiles_position = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChoosePrevious();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        { 
            ChooseNext(); 
        }
    }
    void ChooseNext()
    {

            tiles_position.Translate(move_distance);

    }
    void ChoosePrevious()
    {
            tiles_position.Translate(-move_distance);
    }
}
