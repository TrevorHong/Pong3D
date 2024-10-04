using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    private int player1score = 0;
    private int player2score = 0;
    public TMP_Text text;
    public TMP_Text winningtext;
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(Player.name == "Player1Wall")
        {
            player1score++;
            text.text = $"{player1score}";
            if(player1score == 3)
            {
                winningtext.text = "Player 2 Wins!";
                Invoke("ChangeScene", 5f);
            }
        }
        else if(Player.name == "Player2Wall")
        {
            player2score++;
            text.text = $"{player2score}";
            if (player2score == 3)
            {
                winningtext.text = "Player 1 Wins!";
                Invoke("ChangeScene", 5f);
            }
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
