using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public Dropdown dropItLikeItBeHot;
    public RPGCameraController cam;
    public GameObject[] characters;
    [SerializeField] GameObject toControl;
    InputManager inputMan;
    public static gameManager instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        toControl = characters[0];
        inputMan = GetComponent<InputManager>();
        inputMan.objectToControl = toControl; 
    }
   
	public void switchChar()
    {
        toControl = characters[dropItLikeItBeHot.value];
        inputMan.switchCharacter(toControl);
        cam.target = toControl.transform;

    }

    public GameObject getControlled()
    {
        return toControl;
    }
}
