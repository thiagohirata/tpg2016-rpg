using UnityEngine;
using System.Collections;

public class RPGCharHPIndicator : MonoBehaviour {
    Camera targetCamera;
    UnityEngine.UI.Text uitext;
    RPGFightChar character;

	// Use this for initialization
	void Start () {
        targetCamera = Camera.main;
        uitext = GetComponentInChildren<UnityEngine.UI.Text>();
        character = GetComponentInParent<RPGFightChar>();

    }
	
	// Update is called once per frame
	void Update () {
        //atualiza o número
        uitext.text = character.currentHp.ToString() + "\n" + character.charName;

        //alinha com a câmera
        this.transform.LookAt(targetCamera.transform);
	}
}
