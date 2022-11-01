using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontal * vertical);
        
        if(transform.position.y < -5)
        {
            loseScreen.SetActive(true);
            Debug.Log("BAŞARAMADIK ABI :(");
        }
        else if(transform.position.z > 150)
        {
            winScreen.SetActive(true);
            Debug.Log("BAŞARDIIIINNN!!!");
        }
    }
    public void PlayAgain()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
}