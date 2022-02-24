using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGroup : MonoBehaviour
{
    #region Private enums
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
    #endregion

    #region Public serializable variables
    public GameObject[] platePrefabs;
    public TextAsset levelsFile;

    public Levels levelsInJson;
    public Levels testLevelsInJson;
    #endregion

    #region Private variables
    #endregion

    void Start()
    {
        levelsInJson = JsonUtility.FromJson<Levels>(levelsFile.text);
        testLevelsInJson = JsonUtility.FromJson<Levels>(levelsFile.text);

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
            GameObject newPlate;
            if (plates1[i] == 0 || plates1[i] == 1 || plates1[i] == 2)
            {
                newPlate = Instantiate(platePrefabs[plates1[i]], new Vector3(-6.7f, 1+i, 2.8f), Quaternion.identity, GameObject.Find("Tower1").transform) as GameObject;
                //newPlate.transform.parent = GameObject.Find("Tower1").transform;
                //newPlate.transform.localPosition = new Vector3(-2.7f, 1 + i, 2.8f);
                if (i == plates1.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower1").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());
            }
            else
            {
                newPlate = Instantiate(platePrefabs[plates1[i]], new Vector3(-4, 2 + i, 0), Quaternion.identity, GameObject.Find("Tower1").transform) as GameObject;
                //newPlate.transform.parent = GameObject.Find("Tower1").transform;
                //newPlate.transform.localPosition = new Vector3(0, 2 + i, 0);
                if (i == plates1.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower1").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());

        }

        }

        for (int i = 0; i < plates2.Length; i++)
        {
            GameObject newPlate;
            if (plates2[i] == 0 || plates2[i] == 1 || plates2[i] == 2)
            {
                
                newPlate = Instantiate(platePrefabs[plates2[i]], new Vector3(-2.7f, 1 + i, 2.8f), Quaternion.identity, GameObject.Find("Tower2").transform) as GameObject;
                //newPlate.transform.parent = GameObject.Find("Tower2").transform;
                //newPlate.transform.localPosition = new Vector3(-2.7f, 1 + i, 2.8f);
                if (i == plates2.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower2").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());

            }
            else
            {
                newPlate = Instantiate(platePrefabs[plates2[i]], new Vector3(0, 2 + i, 0), Quaternion.identity, GameObject.Find("Tower2").transform) as GameObject;
                //newPlate.transform.parent = GameObject.Find("Tower2").transform;
                //newPlate.transform.localPosition = new Vector3(0, 2 + i, 0);
                if (i == plates2.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower2").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());
            }

        }

        for (int i = 0; i < plates3.Length; i++)
        {
            GameObject newPlate;
            if (plates3[i] == 0 || plates3[i] == 1 || plates3[i] == 2)
            {
                newPlate = Instantiate(platePrefabs[plates3[i]], new Vector3(1.3f, 1 + i, 2.8f), Quaternion.identity, GameObject.Find("Tower3").transform) as GameObject;
                //newPlate.transform.parent = GameObject.Find("Tower3").transform;
                //newPlate.transform.localPosition = new Vector3(-2.7f, 1 + i, 2.8f);
                if (i == plates3.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower3").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());

            }
            else
            {
                newPlate = Instantiate(platePrefabs[plates3[i]], new Vector3(4, 2 + i, 0), Quaternion.identity, GameObject.Find("Tower3").transform) as GameObject;
                //newPlate.transform.parent = GameObject.Find("Tower3").transform;
                //newPlate.transform.localPosition = new Vector3(0, 2 + i, 0);
                if (i == plates3.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower3").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());

            }

        }

    }

}
