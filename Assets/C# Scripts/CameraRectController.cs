using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRectController : MonoBehaviour
{
    public Vector2 AspectRatio = new(9, 16);
    public Camera gameCamera;
    private Vector2 _lastResolution;
    
    private void Start()
    {
        SetCameraRectForSpecifiedAspectRatio();
    }

    private void Update()
    {
        if(!Mathf.Approximately(_lastResolution.x, Screen.width) || !Mathf.Approximately(_lastResolution.y, Screen.height))
            SetCameraRectForSpecifiedAspectRatio();
    }

    public void SetCameraRectForSpecifiedAspectRatio()
    {
        var currentResolution = new Vector2(Screen.width, Screen.height);

        var currentAspectRatio = currentResolution.x / currentResolution.y;
        var newAspectRatio = AspectRatio.x / AspectRatio.y;
        
        var scaledRectHeight = currentAspectRatio / newAspectRatio;
        var cameraRect = gameCamera.rect;
        if (Mathf.Approximately(newAspectRatio, currentAspectRatio))
        {
            cameraRect.height = 1;
            cameraRect.width = 1;
            cameraRect.x = 0;
            cameraRect.y = 0;
            gameCamera.rect = cameraRect;
            
            return;
        }
        if (scaledRectHeight < 1.0f)
        {
            cameraRect.width = 1.0f;    
            cameraRect.x = 0;

            cameraRect.height = scaledRectHeight;
            cameraRect.y = (1.0f - scaledRectHeight) / 2.0f;
        }
        else if(scaledRectHeight > 1.0f)
        {
            var scaledRectWidth = 1.0f / scaledRectHeight;
            cameraRect.height = 1.0f;
            cameraRect.y = 0;

            cameraRect.width = scaledRectWidth;
            cameraRect.x = (1.0f - scaledRectWidth) / 2.0f;
        }
        gameCamera.rect = cameraRect;
        _lastResolution = currentResolution;
    }
}
