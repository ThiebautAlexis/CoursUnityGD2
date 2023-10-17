using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset; 
    [SerializeField] private float cameraSpeed = 5.0f;

    private void Update()
    {
        FollowTarget(); 
    }

    private void FollowTarget()
    {
        Vector3 _followingPosition = playerTransform.position + offset;
        transform.position = Vector3.MoveTowards(transform.position, _followingPosition, cameraSpeed * Time.deltaTime); 
    }
}
