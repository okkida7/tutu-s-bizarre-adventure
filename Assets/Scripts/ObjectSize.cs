using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 squareSize = GetComponent<Renderer>().bounds.size;
        Debug.Log(squareSize.x);
        Debug.Log(squareSize.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
