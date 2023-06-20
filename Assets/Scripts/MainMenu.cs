using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Drawing;
using System.Windows.Input;

using System.IO;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void InfoGet()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "a.chm");
        Process.Start(path);

    }
    


    public void ExitGame()
    {
        Application.Quit();
    }
}
