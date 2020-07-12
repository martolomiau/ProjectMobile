using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomPatrol : MonoBehaviour
{
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minSpeed;
    public float maxSpeed;
    public float SecondsToMaxDifficulty;
    float Speed;

    Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();

    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            Speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercentage());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }

    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    float GetDifficultyPercentage()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / SecondsToMaxDifficulty);
    }
}
