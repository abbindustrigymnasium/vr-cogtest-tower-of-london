using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGoalTowers : MonoBehaviour
{

    public GameObject imgPrefab;
    public Sprite DarkPlate;
    public Sprite OrangePlate;
    public Sprite SilverPlate;

    //public GameObject MyImage;

    void Start()
    {
    }


    public void ShowGoal(Level level)
    {
        Debug.Log(level);
        for (int i = 0; i < level.pegs.Length; i++)
        {
            for (int j = 0; j < level.pegs[i].goal.Length; j++)
            {
                GameObject img = Instantiate(imgPrefab, gameObject.transform) as GameObject;
                if (level.pegs[i].goal[j].color == "Orange")
                {
                    img.GetComponent<Image>().sprite = OrangePlate;
                    img.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
                    img.GetComponent<RectTransform>().sizeDelta = new Vector2(35 - 7.5f*level.pegs[i].goal[j].size, 5f);
                    img.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-64f + 64f*(i), -10.6f + 5*j, 0);
                }
                else if (level.pegs[i].goal[j].color == "Dark")
                {
                    img.GetComponent<Image>().sprite = DarkPlate;
                    img.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
                    img.GetComponent<RectTransform>().sizeDelta = new Vector2(35 - 7.5f*level.pegs[i].goal[j].size, 5f);
                    img.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-64f + 64f * (i), -10.6f + 5 * j, 0);


                }
                else if (level.pegs[i].goal[j].color == "Silver")
                {
                    img.GetComponent<Image>().sprite = SilverPlate;
                    img.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

                    img.GetComponent<RectTransform>().sizeDelta = new Vector2(35 - 7.5f*level.pegs[i].goal[j].size, 5f);
                    img.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-64f + 64f * (i), -10.6f + 5 * j, 0);


                }
            }
        }
    }
    void Update()
    {
        
    }
}
