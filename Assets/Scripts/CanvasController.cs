using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timeText, ammoText;
    public float time;

    void Start() => InvokeRepeating("TimeChange", 0f, 1f);//repeat TimeChange function for each second

    private void TimeChange()
    {
        time = Time.timeSinceLevelLoad;
        timeText.text = (int)Time.timeSinceLevelLoad/60 + ":" + (int)Time.timeSinceLevelLoad % 60;
    }

    //game over state
    public void TimeStop() => CancelInvoke("TimeChange");

    public void AmmoChanged(int ammo) => ammoText.text = "ammo : " + ammo.ToString();
}
