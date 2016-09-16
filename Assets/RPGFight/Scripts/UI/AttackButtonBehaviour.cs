using UnityEngine;
using System.Collections;

public class AttackButtonBehaviour : MonoBehaviour {
    RPGFight rpgFight; //carregado em Start()
    UnityEngine.UI.Text uitext; //carregado em Start()
    public int attackIndex; //qual o índice do ataque associado a este botão

    // Use this for initialization
    void Start () {
        rpgFight = GetComponentInParent<RPGFight>();
        uitext = GetComponentInChildren<UnityEngine.UI.Text>();

        //pluga, programaticamente, o onClick do botão ao OnClick deste behaviour
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => OnClick());
    }
	
	// Update is called once per frame
	void Update () {
        RPGFightChar currentChar = rpgFight.currentChar;
        if(currentChar != null)
        {
            if(currentChar.attackList.Count > attackIndex)
            {
                AttackType attackType = currentChar.attackList[attackIndex];
                uitext.text = attackType.attackName;
            }
        }
	}

    void OnClick()
    {
        rpgFight.ChooseAttack(attackIndex);
    }
}
