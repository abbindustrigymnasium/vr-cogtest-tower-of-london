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
    public GameObject[] platePrefabs;


    void Start()
    {
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

    }

}
