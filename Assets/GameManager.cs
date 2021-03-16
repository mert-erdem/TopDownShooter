using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void GameOver()
    {
        StartCoroutine(LoadEnd());
    }

    IEnumerator LoadEnd()
    {
        CanvasController canvasController = GameObject.FindGameObjectWithTag("ui").GetComponent<CanvasController>();
        canvasController.TimeStop();
        string time = canvasController.timeText.text; PlayerPrefs.SetString("TIME", time);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("EndScene");
    }
}
