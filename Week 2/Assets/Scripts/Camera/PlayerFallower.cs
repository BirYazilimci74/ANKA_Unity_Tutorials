using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallower : MonoBehaviour
{
    [SerializeField] private PlayerController tank;
    [SerializeField] private Vector3 CameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position + CameraPosition;
    }
}