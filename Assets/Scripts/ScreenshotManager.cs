using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
    string folderPath = Directory.GetCurrentDirectory() + "/Output/";

    public void TakeScreenshot()
    {
        StartCoroutine(Screenshot());
    }

    IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();

        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        if (!Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
            Debug.Log("Folder created");
        }
        else
        {
            Debug.Log("The folder already exists");
        }

        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath + screenshotName));
        Debug.Log(folderPath + screenshotName);
    }
}
