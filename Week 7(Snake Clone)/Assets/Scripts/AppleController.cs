using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    [SerializeField] private GrownController grownController;
    [SerializeField] private TMP_Text scoreText;
    private int score;
    
    public void RePosition()
    {
        transform.position = SpawnPosition();
    }
    
    private Vector3 SpawnPosition()
    {
        var xPos = Random.Range(1, 21);
        var yPos = Random.Range(1, 21);
        Vector3 position = new Vector3(xPos, yPos, 0);
        
        foreach (var part in grownController.snake)
        {
            if (part.transform.position == position)
            {
                Debug.Log("Yılanaaa");
                return SpawnPosition();
            }
        }
        return position;
    }

    public void EarnPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
