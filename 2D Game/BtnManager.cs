using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnManager : MonoBehaviour
{
    public void InitBtnState()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

}

