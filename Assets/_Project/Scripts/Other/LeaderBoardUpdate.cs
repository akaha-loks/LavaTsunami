using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class LeaderBoardUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textMeshPro;

    public void Start()
    {
        YG2.InterstitialAdvShow();
   
        StartCoroutine(GetLB2and3());

        if (PlayerPrefs.GetString("lang") == "en")
        { 
            textMeshPro[0].text = $"Time: {PlayerPrefs.GetInt("min", 59)} : {PlayerPrefs.GetInt("sec", 59)} : {PlayerPrefs.GetInt("milSec", 59)}";
            textMeshPro[1].text = $"Time: {PlayerPrefs.GetInt("min2", 59)} : {PlayerPrefs.GetInt("sec2", 59)} : {PlayerPrefs.GetInt("milSec2", 59)}";
            textMeshPro[2].text = $"Time: {PlayerPrefs.GetInt("min3", 59)} : {PlayerPrefs.GetInt("sec3", 59)} : {PlayerPrefs.GetInt("milSec3", 59)}";
        }
        else
        {
            textMeshPro[0].text = $"Время: {PlayerPrefs.GetInt("min", 59)} : {PlayerPrefs.GetInt("sec", 59)} : {PlayerPrefs.GetInt("milSec", 59)}";
            textMeshPro[1].text = $"Время: {PlayerPrefs.GetInt("min2", 59)} : {PlayerPrefs.GetInt("sec2", 59)} : {PlayerPrefs.GetInt("milSec2", 59)}";
            textMeshPro[2].text = $"Время: {PlayerPrefs.GetInt("min3", 59)} : {PlayerPrefs.GetInt("sec3", 59)} : {PlayerPrefs.GetInt("milSec3", 59)}";
        }
    }

    private IEnumerator GetLB2and3()
    {
        yield return new WaitForSeconds(1.5f);
        SetLBLevel1();
        yield return new WaitForSeconds(1.5f);
        SetLBLevel2();
        yield return new WaitForSeconds(1.5f);
        SetLBLevel3();
        YG2.GetLeaderboard("1Level");
        YG2.GetLeaderboard("2Level2");
        YG2.GetLeaderboard("3Level32");
    }

    private void SetLBLevel1()
    {
        YG2.SetLBTimeConvert("1Level", PlayerPrefs.GetFloat("totalSec1", 3540));
    }
    private void SetLBLevel2()
    {
        YG2.SetLBTimeConvert("2Level2", PlayerPrefs.GetFloat("totalSec2", 3540));
    }
    private void SetLBLevel3()
    {
        YG2.SetLBTimeConvert("3Level32", PlayerPrefs.GetFloat("totalSec3", 3540));
    }
}
