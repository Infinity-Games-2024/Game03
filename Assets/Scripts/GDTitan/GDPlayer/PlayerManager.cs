using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isGameWin;

    public static Vector2 lastCheckPointPos = new Vector2(-3, 0);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;//!!!

    public CinemachineVirtualCamera VCam;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;

    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        //Below 4 lines were commented in 28th June Friday
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        //Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        GameObject player = Instantiate(playerPrefabs[characterIndex],lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        //isGameOver = false;

        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0);//Store Date after exit, 0 is the default value
        isGameOver = false;
        isGameWin = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(numberOfCoins);
        //coinsText.text = "" + numberOfCoins;//Option1 Works
        coinsText.text = numberOfCoins.ToString();
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        if (isGameWin)
        {
            lastCheckPointPos = new Vector2(0, 0);
            gameWinScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//This also works
    }
}
