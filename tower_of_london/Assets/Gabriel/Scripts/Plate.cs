using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    #region Public non-serializable variables. 
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
    #endregion

    #region Serializable props
    public Colour colour { get { return _colour; } }
    public Size size { get { return _size; } }
    public bool isOnTop { get { return _isOnTop; }  set {
            _isOnTop = value;
            gameObject.GetComponent<Rigidbody>().isKinematic = !value;
        } }

    [SerializeField]
    private Colour _colour;
    [SerializeField]
    private Size _size;
    [SerializeField]
    private bool _isOnTop;
    #endregion

    #region Private variables
    private string Tower;
    #endregion


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
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("TowerCollider") && other.transform.name != gameObject.transform.parent.name) 
        {
            gameObject.transform.SetParent(other.transform, true);
            if (size != Size.Large)
            {
            gameObject.transform.localPosition = new Vector3(0, 3, 0);

            }
            else
            {
                gameObject.transform.localPosition = new Vector3(-2.7f, 3, 2.8f);

            }
        }
    }


}
