using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int min;
    private int sec;
    private int milSec;

    [SerializeField] private float totalTimeSec = 3540;

    [SerializeField] private int delta;
    [SerializeField] private TextMeshProUGUI _TimerText;

    [SerializeField] private TextMeshProUGUI _FinishTimeText;
    [SerializeField] private TextMeshProUGUI _FinishRecordTimeText;

    private void Start()
    {
        StartCoroutine(ITimerCount());
    }

    private void OnEnable()
    {
        Finish.Finished += RecordTime;
    }
    private void OnDisable()
    {
        Finish.Finished -= RecordTime;
    }

    private IEnumerator ITimerCount()
    {
        while (true)
        {
            if(milSec == 60)
            {
                sec++;
                milSec = 0;
                if (sec == 60)
                {
                    min++;
                    sec = 0;
                }
            }
            milSec += delta;
            _TimerText.text = min.ToString("D2") + " : " + sec.ToString("D2") + " : " + milSec.ToString("D2");
            yield return new WaitForSeconds(0.0007f);
        }
    }

    private void RecordTime()
    {
        StopCoroutine(ITimerCount());

        UpdateFinishTimes();
        Debug.Log("FINISH");
    }

    private float TotalSec()
    {
        return totalTimeSec = sec + (min * 60) + (milSec * 0.01f);
    }

    private void NewRecordTime()
    {
        switch (PlayerPrefs.GetInt("levelCount", 1))
        {
            case 1:
                if (CanSetNewRecord(PlayerPrefs.GetInt("min", 59), PlayerPrefs.GetInt("sec", 59), PlayerPrefs.GetInt("milSec", 59)))
                {
                    PlayerPrefs.SetInt("min", min);
                    PlayerPrefs.SetInt("sec", sec);
                    PlayerPrefs.SetInt("milSec", milSec);

                    totalTimeSec = TotalSec();
                    PlayerPrefs.SetFloat("totalSec1", totalTimeSec);
                    Debug.Log("Saved");
                }
                if (PlayerPrefs.GetString("lang") == "en")
                    _FinishRecordTimeText.text = "Record: " + PlayerPrefs.GetInt("min", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("sec", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("milSec", 59).ToString("D2");
                else if (PlayerPrefs.GetString("lang") == "ru")
                    _FinishRecordTimeText.text = "Рекорд: " + PlayerPrefs.GetInt("min", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("sec", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("milSec", 59).ToString("D2");
                break;
            case 2:
                if (CanSetNewRecord(PlayerPrefs.GetInt("min2", 59), PlayerPrefs.GetInt("sec2", 59), PlayerPrefs.GetInt("milSec2", 59)))
                {
                    PlayerPrefs.SetInt("min2", min);
                    PlayerPrefs.SetInt("sec2", sec);
                    PlayerPrefs.SetInt("milSec2", milSec);

                    totalTimeSec = TotalSec();
                    PlayerPrefs.SetFloat("totalSec2", totalTimeSec);
                    Debug.Log("Saved2");
                }
                if (PlayerPrefs.GetString("lang") == "en")
                    _FinishRecordTimeText.text = "Record: " + PlayerPrefs.GetInt("min2", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("sec2", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("milSec2", 59).ToString("D2");
                else if (PlayerPrefs.GetString("lang") == "ru")
                    _FinishRecordTimeText.text = "Рекорд: " + PlayerPrefs.GetInt("min2", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("sec2", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("milSec2", 59).ToString("D2");
                break;
            case 3:
                if (CanSetNewRecord(PlayerPrefs.GetInt("min3", 59), PlayerPrefs.GetInt("sec3", 59), PlayerPrefs.GetInt("milSec3", 59)))
                {
                    PlayerPrefs.SetInt("min3", min);
                    PlayerPrefs.SetInt("sec3", sec);
                    PlayerPrefs.SetInt("milSec3", milSec);

                    totalTimeSec = TotalSec();
                    PlayerPrefs.SetFloat("totalSec3", totalTimeSec);
                    Debug.Log("Saved3");
                }
                if (PlayerPrefs.GetString("lang") == "en")
                    _FinishRecordTimeText.text = "Record: " + PlayerPrefs.GetInt("min3", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("sec3", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("milSec3", 59).ToString("D2");
                else if (PlayerPrefs.GetString("lang") == "ru")
                    _FinishRecordTimeText.text = "Рекорд: " + PlayerPrefs.GetInt("min3", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("sec3", 59).ToString("D2") + " : " + PlayerPrefs.GetInt("milSec3", 59).ToString("D2");
                break;
        }        
    }

    private bool CanSetNewRecord(int minCash, int secCash, int milSecCash)
    {
        int savedMin = minCash;
        int savedSec = secCash;
        int savedMilSec = milSecCash;

        if (min < savedMin)
        {
            return true;
        }
        else if (min == savedMin)
        {
            if (sec < savedSec)
            {
                return true;
            }
            else if (sec == savedSec)
            {
                if (milSec < savedMilSec)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void UpdateFinishTimes()
    {
        NewRecordTime();
        if (PlayerPrefs.GetString("lang") == "en")
            _FinishTimeText.text = "Time: " + min.ToString("D2") + " : " + sec.ToString("D2") + " : " + milSec.ToString("D2");
        else if (PlayerPrefs.GetString("lang") == "ru")
            _FinishTimeText.text = "Время: " + min.ToString("D2") + " : " + sec.ToString("D2") + " : " + milSec.ToString("D2"); 
    }
}