using UnityEngine;
using UnityEngine.UI;

public class Call : MonoBehaviour
{
    public Image titleImg;
    public GameObject pressAny;
    public GameObject btnSet;

    void CallPressAny()
    {
            pressAny.SetActive(true);      
    }

    void OffPressAny()
    {
        pressAny.SetActive(false);
    }

    void CallMenu()
    {
        btnSet.SetActive(true);
    }
}
