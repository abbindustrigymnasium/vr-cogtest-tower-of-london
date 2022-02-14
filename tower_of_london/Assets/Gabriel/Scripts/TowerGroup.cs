using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGroup : MonoBehaviour
{
    private enum PlateTypes{
        PlateLargeOrange,
        PlateLargeDark,
        PlateLargeSilver,
        PlateMedidumOrange,
        PlateMediumDark,
        PlateMediumSilver,
        PlateSmallOrange,
        PlateSmallDark,
        PlateSmallSilver
    }
    public enum Formation
    {
        Standard,
        TwoInVision,
        OneInVision
    }

    public Transform playerPos;
    //public Formation formation;
    public GameObject[] platePrefabs;
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
        SpawnPlates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlates()
    {
        int[] plates1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; 
        int[] plates2 = { 1, 4, 7 }; 
        int[] plates3 = { 2, 5, 8 };


        for (int i = 0; i < plates1.Length; i++)
        {
            if (plates1[i] == 0 || plates1[i] == 1 || plates1[i] == 2)
            {
                GameObject newPlate = Instantiate(platePrefabs[plates1[i]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newPlate.transform.parent = GameObject.Find("Tower1").transform;
                newPlate.transform.localPosition = new Vector3(-2.7f, 1 + i, 2.8f);
            }
            else
            {
                GameObject newPlate = Instantiate(platePrefabs[plates1[i]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newPlate.transform.parent = GameObject.Find("Tower1").transform;
                newPlate.transform.localPosition = new Vector3(0, 2 + i, 0);
            }

            }

        for (int i = 0; i < plates2.Length; i++)
        {
            if (plates2[i] == 0 || plates2[i] == 1 || plates2[i] == 2)
            {
                GameObject newPlate = Instantiate(platePrefabs[plates2[i]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newPlate.transform.parent = GameObject.Find("Tower2").transform;
                newPlate.transform.localPosition = new Vector3(-2.7f, 1 + i, 2.8f);
            }
            else
            {
                GameObject newPlate = Instantiate(platePrefabs[plates2[i]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newPlate.transform.parent = GameObject.Find("Tower2").transform;
                newPlate.transform.localPosition = new Vector3(0, 2 + i, 0);
            }

        }

        for (int i = 0; i < plates3.Length; i++)
        {
            if (plates3[i] == 0 || plates3[i] == 1 || plates3[i] == 2)
            {
                GameObject newPlate = Instantiate(platePrefabs[plates3[i]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newPlate.transform.parent = GameObject.Find("Tower3").transform;
                newPlate.transform.localPosition = new Vector3(-2.7f, 1 + i, 2.8f);
            }
            else
            {
                GameObject newPlate = Instantiate(platePrefabs[plates3[i]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newPlate.transform.parent = GameObject.Find("Tower3").transform;
                newPlate.transform.localPosition = new Vector3(0, 2 + i, 0);
            }

        }

        //Tower 1: All of them




        //GameObject newPlate3 = Instantiate(platePrefabs[6], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //newPlate3.transform.parent = GameObject.Find("Tower1").transform;
        //newPlate3.transform.localPosition = new Vector3(0, 2, 0);

    }

}
