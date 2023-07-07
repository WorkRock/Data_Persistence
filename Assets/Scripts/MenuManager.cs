using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerInput;
    public TextMeshProUGUI bestScoreText;

    public string savedmaxScorePlayer;
    public int savedMaxScore;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadPlayerData();
        LoadText();
    }

    public void LoadText()
    {
        savedmaxScorePlayer = DataManager.Instance.maxPlayerName;
        savedMaxScore = DataManager.Instance.maxScore;
        bestScoreText.text = "Saved Best Score - Name : " + savedmaxScorePlayer + " / Score : " + savedMaxScore;
    }

    public void StartGame()
    {
        if (playerInput.text == "")
        {
            playerInput.text = "Default";
        }
        DataManager.Instance.inputPlayerName = playerInput.text;
        DataManager.Instance.SavePlayerData();
        SceneManager.LoadScene(1);
    }
    
    public void ResetScore()
    {
        DataManager.Instance.ResetData();
        LoadText();
    }

    public void EndGame()
    {
        DataManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Unity 플레이어를 종료하는 원본 코드
#endif
    }
}
