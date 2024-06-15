using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public List<LevelScore> levelScores = new List<LevelScore>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(string levelName, int score)
    {
        LevelScore levelScore = levelScores.Find(l => l.levelName == levelName);
        if (levelScore == null)
        {
            levelScore = new LevelScore { levelName = levelName };
            levelScores.Add(levelScore);
        }
        levelScore.scores.Add(new PlayerScore { name = NameInputManager.playerName, score = score });
        levelScore.scores.Sort((a, b) => b.score.CompareTo(a.score));
    }

    public int GetPlayerRank(string levelName)
    {
        LevelScore levelScore = levelScores.Find(l => l.levelName == levelName);
        if (levelScore != null)
        {
            for (int i = 0; i < levelScore.scores.Count; i++)
            {
                if (levelScore.scores[i].name == NameInputManager.playerName)
                {
                    return i + 1;
                }
            }
        }
        return -1;
    }

    public float GetPlayerPercentage(string levelName)
    {
        LevelScore levelScore = levelScores.Find(l => l.levelName == levelName);
        if (levelScore != null)
        {
            int playerRank = GetPlayerRank(levelName);
            if (playerRank > 0)
            {
                return 100f * playerRank / levelScore.scores.Count;
            }
        }
        return -1;
    }
}

[System.Serializable]
public class LevelScore
{
    public string levelName;
    public List<PlayerScore> scores = new List<PlayerScore>();
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;
}