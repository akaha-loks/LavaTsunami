using TMPro;
using UnityEngine;
using YG;

public class LeaderBoardUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textMeshPro;

    public void Start()
    {
        YG2.InterstitialAdvShow();

        float totalSecRecordTime = PlayerPrefs.GetFloat("totalSec1", 999);
        float totalSecRecordTime2 = PlayerPrefs.GetFloat("totalSec2", 999);
        float totalSecRecordTime3 = PlayerPrefs.GetFloat("totalSec3", 999);

        Debug.Log(PlayerPrefs.GetFloat("totalSec1", 999));
        YG2.SetLBTimeConvert("1Level", totalSecRecordTime);
        YG2.SetLBTimeConvert("2Level", totalSecRecordTime2);
        YG2.SetLBTimeConvert("3Level", totalSecRecordTime3);

        if(PlayerPrefs.GetString("lang") == "en")
        {
            textMeshPro[0].text = "Time: " + totalSecRecordTime.ToString("F2") + "sec";
            textMeshPro[1].text = "Time: " + totalSecRecordTime2.ToString("F2") + "sec";
            textMeshPro[2].text = "Time: " + totalSecRecordTime3.ToString("F2") + "sec";
        }
        else if(PlayerPrefs.GetString("lang") == "ru")
        {
            textMeshPro[0].text = "Время: " + totalSecRecordTime.ToString("F2") + "сек";
            textMeshPro[1].text = "Время: " + totalSecRecordTime2.ToString("F2") + "сек";
            textMeshPro[2].text = "Время: " + totalSecRecordTime3.ToString("F2") + "сек";
        }
    }
}
