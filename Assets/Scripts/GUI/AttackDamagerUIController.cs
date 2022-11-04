using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackDamagerUIController : MonoBehaviour
{
    public static AttackDamagerUIController instance;
    //public GameObject Player;

    public Text DamageText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //UpdateAttackDamage();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttackDamage();
    }

    public void UpdateAttackDamage()
    {
        DamageText.text = "AD " + Player.instance.attackDamage.ToString();
        //DamageText.text = 10.ToString();
    }


}
