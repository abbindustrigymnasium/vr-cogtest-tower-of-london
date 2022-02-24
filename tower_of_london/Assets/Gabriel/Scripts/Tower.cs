using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //[System.NonSerialized]
    public List<Plate> PlatesOnTower = new List<Plate>();
    //[System.NonSerialized]
    public List<Plate> goal = new List<Plate>();


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.childCount - 2) > PlatesOnTower.Count && PlatesOnTower.Count != 0)
        {
            Debug.Log(gameObject);
            Debug.Log(PlatesOnTower.Count);

            PlatesOnTower[PlatesOnTower.Count - 1].isOnTop = false;
            PlatesOnTower.Add(gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Plate>());
            PlatesOnTower[PlatesOnTower.Count - 1].isOnTop = true;

        }
        else if ((gameObject.transform.childCount - 2) < PlatesOnTower.Count)
        {
            Debug.Log(gameObject);
            Debug.Log(PlatesOnTower.Count);
            PlatesOnTower.RemoveAt(PlatesOnTower.Count - 1);

            PlatesOnTower[PlatesOnTower.Count - 1].isOnTop = true;

        }
    }
}