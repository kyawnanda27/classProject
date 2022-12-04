using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Distractor : MonoBehaviour
{
    const int MAX_DIST = 3;
    [SerializeField] GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float xMinLeft= -12.82f;
        float xMaxLeft = -11.58f;
        float yMinLeft = 3.51f;
        float yMaxLeft = 9.4f;
        float xMinRight = 24.21f;
        float xMaxRight = 25.36f;
        float yMinRight = 3.51f;
        float yMaxRight = 9.4f;
        int sideDetector = 0;
        Vector2 position;

        for(int i = 0; i < MAX_DIST; i++)
        {
            sideDetector = Random.Range(1,10);
            if(sideDetector % 2 == 0)
                position = new Vector2(Random.Range(xMinLeft, xMaxLeft), Random.Range(yMinLeft, yMaxLeft));
            else
                position = new Vector2(Random.Range(xMinRight, xMaxRight), Random.Range(yMinRight, yMaxRight));
            Instantiate(balloon, position, Quaternion.identity);
        }
    }
}
