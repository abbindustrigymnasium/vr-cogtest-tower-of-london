using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool setOnTop;
    bool prevOnTop;

    void Start()
    {
        prevOnTop = !setOnTop;
    }

    void Update()
    {
        if (setOnTop != prevOnTop)
        {
            gameObject.GetComponent<Plate>().isOnTop = setOnTop;
            prevOnTop = setOnTop;
        }
    }
}
