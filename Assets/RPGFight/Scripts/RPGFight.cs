using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class RPGFight : MonoBehaviour {

    /// <summary>
    /// animator que controla o fluxo da interface do jogo
    /// </summary>
    Animator stateMachineAnimator;


    public Queue<RPGFightChar> characterQueue;
    public RPGFightChar currentChar;
    public List<RPGFightChar> teamAList;
    public List<RPGFightChar> teamBList;


    public int chosenAttack;
    public List<RPGFightChar> targetList;
    public RPGFightChar chosenTarget;


    // Use this for initialization
    void Start () {
        RPGFightChar[] allCharacters = this.GetComponentsInChildren<RPGFightChar>();
        characterQueue = new Queue<RPGFightChar>(allCharacters);
        currentChar = characterQueue.Dequeue();

        stateMachineAnimator = this.GetComponent<Animator>();

        //monta a lista dos times
        teamAList = new List<RPGFightChar>();
        teamBList = new List<RPGFightChar>();

        //configura a propriedade charIndex de cada personagem da luta
        int i = 0;
        foreach(RPGFightChar c in allCharacters)
        {
            c.charIndex = i++;
            if(c.team == Team.TeamA)
            {
                teamAList.Add(c);
            } else
            {
                teamBList.Add(c);
            }
        }
	}

    public void ChooseAttack(int attackIndex)
    {
        this.chosenAttack = attackIndex;
        stateMachineAnimator.SetTrigger("AttackChosen");

        if(currentChar.team == Team.TeamA)
        {
            this.targetList = teamBList;
        } else
        {
            this.targetList = teamAList;
        }
        
    }

    public void ChooseTarget(int targetIndex)
    {
        this.chosenTarget = this.targetList[targetIndex];
        stateMachineAnimator.SetTrigger("TargetChosen");
    }

    public void ShowAttackAnimation()
    {
        this.currentChar.GetComponent<Animator>().SetTrigger("Attack3Trigger");
    }

    public void ShowTargetEffectAnimation()
    {
        this.chosenTarget.GetComponent<Animator>().SetTrigger("GetHit1Trigger");
    }


    public void ExecuteTurn()
    {
        AttackType attackType = currentChar.attackList[this.chosenAttack];
        this.chosenTarget.currentHp -= attackType.damageAmount;

        this.currentChar = null;
        while (currentChar == null && characterQueue.Count > 0)
        {
            this.currentChar = characterQueue.Dequeue();
        }

        if(currentChar == null)
        {
            RPGFightChar[] allCharacters = this.GetComponentsInChildren<RPGFightChar>();
            characterQueue = new Queue<RPGFightChar>(allCharacters);
            currentChar = characterQueue.Dequeue();
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
