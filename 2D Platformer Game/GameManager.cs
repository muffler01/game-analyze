using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;

    public int health;
    public PlayerMove player;
    public GameObject[] stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRetryButton;

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }
    public void NextStage()
    {
        // Change Stage
        if (stageIndex < stages.Length - 1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        // Game Clear
        else
        {
            // Player Control Lock
            Time.timeScale = 0;
            // Result UI
            Debug.Log("Game Clear!");
            // Restart Button UI
            UIRetryButton.SetActive(true);
            Text buttonText = UIRetryButton.GetComponentInChildren<Text>();
            buttonText.text = "Clear!";
            UIRetryButton.SetActive(true);
        }

        // Calculate Point
        totalPoint += stagePoint;
        stagePoint = 0;
    }
    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 1, 1, 0.4f);
        }

        else
        {
            // All Health UI Off
            UIhealth[0].color = new Color(1, 1, 1, 0.4f);
            // Player Die Effect
            player.OnDie();
            // Result UI
            Debug.Log("Game Over");
            // Retry Button UI
            UIRetryButton.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Respawn
            if (health > 1)
            {
                PlayerReposition();
            }

            // Health Down
            HealthDown();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-5, 0, -1);
        player.VelocityZero();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
