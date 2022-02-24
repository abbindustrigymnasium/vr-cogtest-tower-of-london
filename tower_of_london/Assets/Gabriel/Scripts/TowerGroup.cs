using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGroup : MonoBehaviour
{
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

        SpawnPlates(levelsInJson.levels[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Spawns plates base on the passed level. 
    /// </summary>
    /// <param name="level">Object of type Level that represents the level that is getting spawned in. </param>
    void SpawnPlates(Level level)
    {
        GameObject newPlate;

        for (int j = 0; j < level.pegs.Length; j++)
        {
            for (int i = 0; i < level.pegs[j].disks.Length; i++)
            {
                if (level.pegs[j].disks[i].size == 1)
                {
                    if (level.pegs[j].disks[i].color == "Dark")
                    {
                        newPlate = Instantiate(platePrefabs[-3 + level.pegs[j].disks[i].size * 3], new Vector3(-6.7f + 4*j, 1 + i, 2.8f), Quaternion.identity, GameObject.Find(level.pegs[j].tower).transform) as GameObject;

                    }
                    else if (level.pegs[j].disks[i].color == "Orange")
                    {
                        newPlate = Instantiate(platePrefabs[-2 + level.pegs[j].disks[i].size * 3], new Vector3(-6.7f + 4 * j, 1 + i, 2.8f), Quaternion.identity, GameObject.Find(level.pegs[j].tower).transform) as GameObject;
                    }
                    else
                    {
                        newPlate = Instantiate(platePrefabs[-1 + level.pegs[j].disks[i].size * 3], new Vector3(-6.7f + 4 * j, 1 + i, 2.8f), Quaternion.identity, GameObject.Find(level.pegs[j].tower).transform) as GameObject;

                    }
                }
                else
                {
                    if (level.pegs[j].disks[i].color == "Dark")
                    {
                        newPlate = Instantiate(platePrefabs[-3 + level.pegs[j].disks[i].size * 3], new Vector3(-4 + 4 * j, 2 + i, 0), Quaternion.identity, GameObject.Find(level.pegs[j].tower).transform) as GameObject;

                    }
                    else if (level.pegs[j].disks[i].color == "Orange")
                    {
                        newPlate = Instantiate(platePrefabs[-2 + level.pegs[j].disks[i].size * 3], new Vector3(-4 + 4 * j, 2 + i, 0), Quaternion.identity, GameObject.Find(level.pegs[j].tower).transform) as GameObject;
                    }
                    else
                    {
                        newPlate = Instantiate(platePrefabs[-1 + level.pegs[j].disks[i].size * 3], new Vector3(-4 + 4 * j, 2 + i, 0), Quaternion.identity, GameObject.Find(level.pegs[j].tower).transform) as GameObject;

                    }

                }
                if (i == level.pegs[j].disks.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find(level.pegs[j].tower).GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());
            }
        }
    }


        
    /// <summary>
    /// Spawn plates on every tower. Every plate on tower 1, All orange plates on tower 2, and all silver plates on tower 3. 
    /// </summary>
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
                if (i == plates1.Length - 1)
                {
                    newPlate.GetComponent<Plate>().isOnTop = true;
                }
                GameObject.Find("Tower1").GetComponent<Tower>().PlatesOnTower.Add(newPlate.GetComponent<Plate>());
            }
            else
            {
                newPlate = Instantiate(platePrefabs[plates1[i]], new Vector3(-4, 2 + i, 0), Quaternion.identity, GameObject.Find("Tower1").transform) as GameObject;
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
