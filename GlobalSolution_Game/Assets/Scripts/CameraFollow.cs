using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 0; 

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset);
        transform.position = Vector3.Slerp(target.position, newPos, followSpeed * Time.deltaTime);
    }
}
