using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(3);
    }

    public void SetResolutionTo16by9()
    {
        SetResolution(16, 9);
        Debug.Log("Changed to 16:9");
    }

    public void SetResolutionToFullHD()
    {
        SetResolution(1920, 1080);
        Debug.Log("Changed to Full HD");
    }

    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
