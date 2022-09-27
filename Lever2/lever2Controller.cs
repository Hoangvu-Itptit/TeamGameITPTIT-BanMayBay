using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lever2Controller : MonoBehaviour
{
    public Text replaytext;
    public Button replayButton;
    public Button quitButton;
    public Button nextleverButton;
    public GameObject aeteroidPretabs;
    public GameObject enemyPretabs;
    public GameObject windowplay;
    private float timer;
    private float timeraeteroid;
    // Start is called before the first frame update
    void Start()
    {
        replayButton.onClick.AddListener(OnReplaybuttonClick);
        quitButton.onClick.AddListener(OnQuitbuttonClick);
        // nextleverButton.onClick.AddListener(OnnextLeverbuttonClick);
        timer = timeraeteroid = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeraeteroid += Time.deltaTime;
        if (timer >= 0.5f)
        {
            Instantiate(enemyPretabs, new Vector3(UnityEngine.Random.Range(-globalValue.screenWidth/2f, globalValue.screenWidth/2f), 5, 0), Quaternion.identity);
            timer = 0f;
        }

        if (timeraeteroid >= 0.75f)
        {
            Instantiate(aeteroidPretabs,
                new Vector3(UnityEngine.Random.Range(-globalValue.screenWidth / 2f, globalValue.screenWidth / 2f), 5,
                    0), Quaternion.identity);
            timeraeteroid = 0f;
        }
        
    }

    private void OnReplaybuttonClick()
    {
        SceneManager.LoadScene("Gameplay");
    }
    private void OnQuitbuttonClick()
    {
        Application.Quit();
    }
    private void OnnextLeverbuttonClick()
    {
        SceneManager.LoadScene("Lever2");
    }
    public void Win()
    {
        windowplay.SetActive(true);
        replaytext.text = "WIN!";
    }

    public void Lose()
    {
        windowplay.SetActive(true);
        replaytext.text = "LOSE";
    }
}
