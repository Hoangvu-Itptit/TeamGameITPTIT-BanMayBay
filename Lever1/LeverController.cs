using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LeverController : MonoBehaviour
{
    public Text replaytext;
    public Button replayButton;
    public Button quitButton;
    public Button nextleverButton;
    public GameObject aeteroidPretabs;
    public GameObject windowplay;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        replayButton.onClick.AddListener(OnReplaybuttonClick);
        quitButton.onClick.AddListener(OnQuitbuttonClick);
        nextleverButton.onClick.AddListener(OnnextLeverbuttonClick);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            Instantiate(aeteroidPretabs, new Vector3(UnityEngine.Random.Range(-globalValue.screenWidth/2f, globalValue.screenWidth/2f), 5, 0), Quaternion.identity);
            timer = 0f;
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
