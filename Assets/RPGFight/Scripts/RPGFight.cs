using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGFight : MonoBehaviour {
    private List<Team> teams;
    public List<RPGFightChar> characterList;
    public RPGFightChar currentChar;

	// Use this for initialization
	void Start () {
        characterList = new List<RPGFightChar>(this.GetComponentsInChildren<RPGFightChar>());
        currentChar = characterList[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
