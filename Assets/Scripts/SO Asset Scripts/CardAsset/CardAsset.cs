using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TargetingOptions
{
    NoTarget,
    AllCreatures, 
    EnemyCreatures,
    YourCreatures, 
    AllCharacters, 
    EnemyCharacters,
    YourCharacters
}

public class CardAsset : ScriptableObject 
{
    // this object will hold the info about the most general card
    [Header("General info")]
    public CharacterAsset characterAsset;  // if this is null, it`s a neutral card
    [TextArea(2,3)]
    public string Description;  // Description for spell or character
	public Sprite CardImage;
    public Sprite CardBody;
    public Sprite AttackIcon;
    public Sprite ShieldIcon;
    public Sprite DestrezaIcon;
    public Sprite IngenioIcon;
    public Sprite RecuadroIcon;
    public int Condicion;
    public int CardType;
    public int MovementCost = 1;
 

    [Header("Creature Info")]
    public int MaxHealth;
    public int Attack;
    public int Escudo;
    public int Destreza;
    public int Ingenio;
    public int AttacksForOneTurn = 1;
    public bool Soldier;
    public bool Taunt;
    public bool Charge;
    public string CreatureScriptName;
    public int specialCreatureAmount;

    [Header("SpellInfo")]
    public string SpellScriptName;
    public int specialSpellAmount;
    public TargetingOptions Targets;

}
