using UnityEngine;

public class Enemy : MonoBehaviour 
{ 
    public void SetBaseRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}