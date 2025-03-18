using UnityEngine;
using YG;

public class SaveToLeaderBoard : MonoBehaviour
{
    private void Awake()
    {
        float bestTimeLevel1 = PlayerPrefs.GetFloat("BestTime_Level1", float.MaxValue);
        float bestTimeLevel2 = PlayerPrefs.GetFloat("BestTime_Level2", float.MaxValue);
        float bestTimeLevel3 = PlayerPrefs.GetFloat("BestTime_Level3", float.MaxValue);

        if (bestTimeLevel1 < float.MaxValue)
        {
            YandexGame.NewLBScoreTimeConvert("1Level", bestTimeLevel1);
        }
        if (bestTimeLevel2 < float.MaxValue)
        {
            YandexGame.NewLBScoreTimeConvert("2Level", bestTimeLevel2);
        }
        if (bestTimeLevel3 < float.MaxValue)
        {
            YandexGame.NewLBScoreTimeConvert("3Level", bestTimeLevel3);
        }
    }
}
