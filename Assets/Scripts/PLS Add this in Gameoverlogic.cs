using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremanager1 : MonoBehaviour
{
    // Start is called before the first frame update
    void EndLevel()
{
    int playerScore = CalculateScore();
    string levelName = "Level 1"; // 根据实际关卡名称设置
    ScoreManager.Instance.AddScore(levelName, playerScore);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
