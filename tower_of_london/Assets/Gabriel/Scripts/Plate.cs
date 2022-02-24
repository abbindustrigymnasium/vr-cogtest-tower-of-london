using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public enum Colour
    {
        Orange,
        Silver,
        Dark
    }
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public Colour colour { get { return _colour; } }
    public Size size { get { return _size; } }
    public bool isOnTop { get { return _isOnTop; } }

    [SerializeField]
    private Colour _colour;
    [SerializeField]
    private Size _size;
    [SerializeField]
    private bool _isOnTop;
    private void Start()
    {
        string plateName = gameObject.name;
        int charLocation = plateName.IndexOf('(', System.StringComparison.Ordinal);
        string plateType = plateName.Substring(0, charLocation);

        if (plateType == "PlateLargeOrange")
        {
            _colour = Colour.Orange;
            _size = Size.Large;
        }
        else if (plateType == "PlateLargeDark")
        {
            _colour = Colour.Dark;
            _size = Size.Large;
        }
        else if (plateType == "PlateLargeSilver")
        {
            _colour = Colour.Silver;
            _size = Size.Large;

        }
        else if (plateType == "PlateMediumOrange")
        {
            _colour = Colour.Orange;
            _size = Size.Medium;
        }
        else if (plateType == "PlateMediumDark")
        {
            _colour = Colour.Dark;
            _size = Size.Medium;

        }
        else if (plateType == "PlateMediumSilver")
        {
            _colour = Colour.Silver;
            _size = Size.Medium;

        }
        else if (plateType == "PlateSmallOrange")
        {
            _colour = Colour.Orange;
            _size = Size.Small;
        }
        else if (plateType == "PlateSmallDark")
        {
            _colour = Colour.Dark;
            _size = Size.Small;

        }
        else if (plateType == "PlateSmallSilver")
        {
            _colour = Colour.Silver;
            _size = Size.Small;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TowerCollider"))
        {
            Debug.Log("Entered");
            gameObject.transform.SetParent(other.transform, false);

            //Vector3 position = gameObject.transform.position;
            //gameObject.transform.Translate(new Vector3(0, 3, 0) * Time.deltaTime);
            //transform.position = new Vector3(0, 1, 0);
            //transform.SetPositionAndRotation(new Vector3(0, 3, 0), Quaternion.identity);
            //gameObject.transform.localPosition = new Vector3(0, 3, 0);

            //Vector3 pos = transform.position;
            //pos.y = 3;
            //transform.position = pos;




        }
    }

}
