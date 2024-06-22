using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text rankText;
    public Text percentageText;
    public string levelName;

    void Start()
    {
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        int rank = ScoreManager.Instance.GetPlayerRank(levelName);
        float percentage = ScoreManager.Instance.GetPlayerPercentage(levelName);

        rankText.text = "Rank: " + rank.ToString();
        percentageText.text = "Top: " + percentage.ToString("F2") + "%";
    }
}