using UnityEngine;
using System.Collections;

public class TargetButtonBehaviour : MonoBehaviour {
    RPGFight rpgFight; //carregado em Start()
    UnityEngine.UI.Text uitext; //carregado em Start()
    UnityEngine.UI.Button button;

    public int targetIndex;


    // Use this for initialization
    void Start () {
        rpgFight = GetComponentInParent<RPGFight>();
        uitext = GetComponentInChildren<UnityEngine.UI.Text>();

        //pluga, programaticamente, o onClick do botão ao OnClick deste behaviour
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => OnClick());
    }

    void Update () {

        RPGFightChar targetChar = null;
        if(rpgFight.targetList.Count > targetIndex)
        {
            targetChar = rpgFight.targetList[targetIndex];
        }

        if (targetChar != null)
        {
            button.interactable = true;
            uitext.text = targetChar.charName;
        } else
        {
            button.interactable = false;
            uitext.text = "";
        }
    }

    void OnClick()
    {
        rpgFight.ChooseTarget(targetIndex);

    }
}
