using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float displayDuration = 3.0f;
    public GameObject player;
    public CanvasGroup exitBG;
    public CanvasGroup overBG;

    bool isPlayerExit;
    bool isPlayerOver;
    float timer;

    void Start()
    {
        player = GetComponent<GameObject>();

        exitBG.gameObject.SetActive(false);
        overBG.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerExit)
        {
            Endlevel(exitBG, true);
        }
        else if (isPlayerOver)
        {
            Endlevel(overBG, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerExit = true;
        }
    }

    void Endlevel(CanvasGroup imageCanvas, bool doQuit)
    {
        if (isPlayerExit)
        {
            exitBG.gameObject.SetActive(true);
        }
        else if (isPlayerOver)
        {
            overBG.gameObject.SetActive(true);
        }

        timer += Time.deltaTime;

        exitBG.alpha = timer / fadeDuration;
        overBG.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayDuration)
        {
            if (doQuit)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void CaughtPlayer()
    {
        isPlayerOver = true;
    }
}