using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 140f;
    [SerializeField]
    private Transform rotateAround;

    private Vector3 offsetFromCenter;

    private void Start()
    {
        offsetFromCenter = transform.position - rotateAround.position;
    }

    private void Update()
    {
        transform.position = rotateAround.position + offsetFromCenter;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; 
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 directionToMouse = targetPosition - rotateAround.position;

        Vector3 currentDirection = transform.position - rotateAround.position;

        float currentAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        float targetAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);
        float rotationDirection = angleDifference > 0 ? 1 : -1;

        float adjustedRotationSpeed = rotationSpeed * 2f;

        if (Mathf.Abs(angleDifference) > 0.5f)
        {
            transform.RotateAround(rotateAround.position, Vector3.forward, rotationDirection * adjustedRotationSpeed * Time.deltaTime);
        }

        offsetFromCenter = transform.position - rotateAround.position;

        Vector3 newDirection = targetPosition - transform.position;
        float lookAngle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, lookAngle);
    }
}
