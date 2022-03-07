using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Disk
{
    public string color;
    public int size;

    public Disk(int _size, string _color)
    {
        color = _color;
        size = _size;
    }

}
