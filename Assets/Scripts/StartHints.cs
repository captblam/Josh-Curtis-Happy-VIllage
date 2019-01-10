using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHints : MonoBehaviour {

    public Texture2D welcomeImage;
    public Texture2D image;
    public Texture2D image1;
    public Texture2D image2;
    private int countDownTimerDelay;
    private int countDownTimerStartTime;

    public static float startTimer, timer = 5;

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
            Time.timeScale = 0.5f;
            Debug.Log("Slow time");
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("fast time");
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
        countdownTimerReset(3);
    }

    private void OnGUI()
    {
        GUILayout.Label(CountdownTimerImage());
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
            case 0:
                return image2;
            case 1:
                return image1 ;
            case 2:
                return image;
            case 3:
                return welcomeImage;
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
