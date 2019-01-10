using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHints : MonoBehaviour {

    
    public Texture2D image;
    public Texture2D image1;
    private int countDownTimerDelay;
    private int countDownTimerStartTime;
    public GameObject startHintsScript;

    public static float startTimer, timer = 2;

    public static StartHints Instance { get { return Instance;  } }
    private static StartHints instance = null;

    private void Start()
    {
        startTimer = timer;
    }

    private void Update()
    {
        startTimer -= Time.deltaTime;
        beginTime();
    }
    
    void beginTime()
    {
        if (startTimer >= 0)
        {
            Time.timeScale = 0.1f;
            Debug.Log("Slow time");
        }
        else if (startTimer <= 0 || Input.GetKeyDown(key: KeyCode.KeypadEnter))
        {
            Time.timeScale = 1f;
            Debug.Log("fast time");
            startHintsScript.SetActive(false);
            timer = 0;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = null;
        }
        countdownTimerReset(2);
    }

    private void OnGUI()
    {
        //GUILayout.Label(CountdownTimerImage());
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(CountdownTimerImage());
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }

    Texture2D CountdownTimerImage()
    {
        switch (coutdownTimerSecondsRemaining())
        {
            case 1:
                return image ;
            case 2:
                return image1;
            default:
                return null;
        }
    }

    int coutdownTimerSecondsRemaining()
    {
        int elapsedSeconds = (int)(Time.time - countDownTimerStartTime);
        int secondsLeft = (countDownTimerDelay - elapsedSeconds);
        return secondsLeft;
    }

    void countdownTimerReset(int delayInSeconds)
    {
        countDownTimerDelay = delayInSeconds;
        countDownTimerStartTime = (int)Time.time;
    }
}
