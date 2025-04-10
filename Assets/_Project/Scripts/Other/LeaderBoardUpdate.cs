using TMPro;
using UnityEngine;
using YG;

public class LeaderBoardUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textMeshPro;

    public void Start()
    {
        float totalSecRecordTime = PlayerPrefs.GetFloat("totalSec1", 999);
        float totalSecRecordTime2 = PlayerPrefs.GetFloat("totalSec2", 999);
        float totalSecRecordTime3 = PlayerPrefs.GetFloat("totalSec3", 999);

        Debug.Log(PlayerPrefs.GetFloat("totalSec1", 999));
        YG2.SetLBTimeConvert("1Level", totalSecRecordTime);
        YG2.SetLBTimeConvert("2Level", totalSecRecordTime2);
        YG2.SetLBTimeConvert("3Level", totalSecRecordTime3);

        textMeshPro[0].text = "you: " + totalSecRecordTime.ToString("F2") + "sec";
        textMeshPro[1].text = "you: " + totalSecRecordTime2.ToString("F2") + "sec";
        textMeshPro[2].text = "you: " + totalSecRecordTime3.ToString("F2") + "sec";
    }
}
