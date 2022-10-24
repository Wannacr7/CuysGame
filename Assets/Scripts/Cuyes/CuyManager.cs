using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCuy{
    Amarillo,
    Cafe,
    Rojo

}


public class CuyManager : MonoBehaviour
{
    public TypeCuy colorCuy;
    public CuysStats stat;
    //public PathFollower movementControl;

    private Vector2 targetPos;
    private void Start() {
        targetPos = Vector2.zero;
    }
    

    private void Update() {

        Look(targetPos);
    }
    private void LateUpdate() {
        
        targetPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

    private void Look(Vector2 targetPosition)
    {
        Vector2 thisPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
        Vector2 forward = thisPosition - targetPosition;
        float radians = Mathf.Atan2(forward.y, forward.x);
        RotateZ(radians);
    }
     private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }



}
