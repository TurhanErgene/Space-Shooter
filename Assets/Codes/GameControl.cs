using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float waitStart;
    public float waitCreate;
    public float waitLoop;
    public Text text;
    public Text gameOverText;
    public Text restartText;
    int score;
    bool gameOver = false;
    bool restart = false;

    void Start()
    {
        score = 0;
        text.text = "Score: " + score;
        
        StartCoroutine(create());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && restart)
        {
            SceneManager.LoadScene("VS Astroids");
        }
    }
    IEnumerator create () 
    {
        yield return new WaitForSeconds(waitStart);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                //Randomly asteroid spawner between random values by using Random.Range(inputs 2 values)
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);

                yield return new WaitForSeconds(waitCreate);
            }

            if (gameOver)
            {
                restartText.text = "Press R to restart";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waitLoop);

        }
    }

    public void Score(int scorePlus) 
    {
        score += scorePlus;
        text.text = "Score: " + score;
        Debug.Log(score);
    }

    public void GameOver() 
    {
        
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
