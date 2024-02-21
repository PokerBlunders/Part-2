using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static PlayerSelector CurrentSelection { get; private set; }
    public static void SetCurrentSelection(PlayerSelector player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }
        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }
}
