using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timeText, ammoText;


    void Start()
    {
        InvokeRepeating("TimeChange", 0f, 1f);//repeat TimeChange function each second
    }

    private void TimeChange()
    {
        timeText.text = (int)Time.realtimeSinceStartup/60 + ":" + (int)Time.realtimeSinceStartup % 60;
    }

    public void TimeStop()
    {
        CancelInvoke("TimeChange");
    }

    public void AmmoChanged(int ammo)
    {
        ammoText.text = "ammo : " + ammo.ToString();
    }
}
