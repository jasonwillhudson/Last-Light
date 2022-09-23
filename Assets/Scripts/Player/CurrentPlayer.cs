using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentPlayer", menuName = "Scriptable Objects/Player/Current Player")]
public class CurrentPlayer : ScriptableObject
{
    public PlayerDetail playerDetail;
    public string playerName;

}
