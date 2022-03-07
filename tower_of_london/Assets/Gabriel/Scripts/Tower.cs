using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //[System.NonSerialized]
    public List<Plate> PlatesOnTower = new List<Plate>();
    //[System.NonSerialized]
    public List<Disk> goal = new List<Disk>();

    public bool isCorrect; 


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.childCount - 2) > PlatesOnTower.Count)
        {
            if (PlatesOnTower.Count != 0)
            {
            PlatesOnTower[PlatesOnTower.Count - 1].isOnTop = false;
            }
            PlatesOnTower.Add(gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Plate>());
            PlatesOnTower[PlatesOnTower.Count - 1].isOnTop = true;
            isCorrect = checkIfCorrect();


        }
        else if ((gameObject.transform.childCount - 2) < PlatesOnTower.Count)
        {
            PlatesOnTower.RemoveAt(PlatesOnTower.Count - 1);

            if (PlatesOnTower.Count != 0)
            {
                PlatesOnTower[PlatesOnTower.Count - 1].isOnTop = true;
            }
            isCorrect = checkIfCorrect();
        }
    }

    private bool checkIfCorrect()
    {
        if (PlatesOnTower.Count == goal.Count)
        {
            for (int i = 0; i < goal.Count; i++)
            {
                if (goal[i].color != PlatesOnTower[i].colour.ToString())
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}