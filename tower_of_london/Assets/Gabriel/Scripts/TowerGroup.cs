using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGroup : MonoBehaviour
{
    public enum Formation
    {
        Standard,
        TwoInVision,
        OneInVision
    }

    public Transform playerPos;
    //public Formation formation;
    public GameObject platePrefab;
    public Formation formationProp
    {
        get { return _formation; }
        set
        {
            _formation = value;
            Debug.Log("Setter Triggered");
            switch (value)
            {
                case Formation.Standard:
                    {
                        Debug.Log("Setting standard");
                        Debug.Log(playerPos.position.x);
                        Tower1.transform.position = new Vector3(playerPos.position.x - spacing, playerPos.position.y, playerPos.position.z + distance);
                        Tower2.transform.position = new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z + distance);
                        Tower3.transform.position = new Vector3(playerPos.position.x + spacing, playerPos.position.y, playerPos.position.z + distance);

                        _formation = Formation.Standard;
                        //Set locations infront
                        break;
                    }
                case Formation.TwoInVision:
                    {
                        _formation = Formation.Standard;

                        break;
                    }
                case Formation.OneInVision:
                    {
                        _formation = Formation.Standard;

                        break;
                    }

            }
        }
    }
    public Formation formation; 
    private Formation _formation;

    private GameObject Tower1;
    private GameObject Tower2;
    private GameObject Tower3;
    private float distance = 8f;
    private float spacing = 4f;

    void Start()
    {
        Tower1 = gameObject.transform.GetChild(0).gameObject;
        Tower2 = gameObject.transform.GetChild(1).gameObject;
        Tower3 = gameObject.transform.GetChild(2).gameObject;
        formationProp = formation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
