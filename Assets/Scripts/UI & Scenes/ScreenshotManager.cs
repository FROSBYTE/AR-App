using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast;

public class ScreenshotManager : MonoBehaviour
{
    [Header("ScreenShot Save References")]
    public string savedImagePath; // Stores the path of the saved image

    [Header("Bool References")]
    public bool isSaved; // Flag to track if the current screenshot has been saved
    public bool canShow;

    [Header("UI References")]
    public GameObject[] uiButtons; // Reference to the UI buttons that need to be hidden

    private byte[] pngShot;
    private string screenshotName;

    private RenderTexture renderTexture; // Render texture to capture the screen without UI buttons

    public void ScreenShot()
    {
        // Create a new render texture with the screen dimensions
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // Set the camera to render to the render texture
        Camera.main.targetTexture = renderTexture;

        StartCoroutine(CaptureScreenshotCoroutine());
    }

    private IEnumerator CaptureScreenshotCoroutine()
    {
        yield return new WaitForEndOfFrame();

        // Create a new texture from the render texture
        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        screenshotName = "AR-App" + DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss") + ".jpg";
        pngShot = tex.EncodeToPNG();

        // Reset the camera target texture
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        SaveScreenShot();
    }

    public void SaveScreenShot()
    {
        savedImagePath = null;
        NativeGallery.SaveImageToGallery(pngShot, "AR App Screenshots", screenshotName, onSaveComplete);
    }

    public void onSaveComplete(bool success, string path)
    {
        if (success)
        {
            Toast.Show("Screenshot Saved to Gallery", 2f);
            savedImagePath = path; // Store the path of the saved image
            Debug.Log("Success: " + path);
            isSaved = true; // Set the flag to indicate that the current screenshot has been saved
        }
        else
        {
            Debug.Log("Failed");
        }
    }
}
