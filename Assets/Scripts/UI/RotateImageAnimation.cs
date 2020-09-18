using UnityEngine;

/// <summary>
/// Class to rotate the loading image when active
/// </summary>
public class RotateImageAnimation : MonoBehaviour {
    
    private float rotationZAngle = 0f;

    void Update() {
        rotationZAngle += 3;
        if (rotationZAngle > 360) rotationZAngle = 0;
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, rotationZAngle);
    }
}
