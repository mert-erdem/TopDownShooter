using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class EndSceneController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI time;
    
    void Start()
    {
        time.text = PlayerPrefs.GetString("TIME");
    }
}
