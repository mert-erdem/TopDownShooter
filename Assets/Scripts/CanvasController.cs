using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;


    private void Start()
    {
        InvokeRepeating("TimeChange", 0f, 1f);
    }

    private void TimeChange()
    {
        timeText.text = (int)Time.realtimeSinceStartup/60 + ":" + (int)Time.realtimeSinceStartup % 60;
    }

}
