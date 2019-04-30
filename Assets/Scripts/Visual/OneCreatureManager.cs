using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OneCreatureManager : MonoBehaviour 
{
    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text NameText;
    public Text HealthText;
    public Text AttackText;
    public Text EscudoText;
    public Text IngenioText;
    public Text DestrezaText;

    [Header("Image References")]
    public Image CreatureGraphicImage;
    public Image CardBodyImage;

    [Header("Icons")]

    public Image AttackIcon;
    public Image ShieldIcon;
    public Image DestrezaIcon;
    public Image IngenioIcon;
    public Image RecuadroIconA;
    public Image RecuadroIconS;
    public Image RecuadroIconD;
    public Image RecuadroIconI;


    //public Image CreatureGlowImage;

    void Awake()
    {
        if (cardAsset != null)
            ReadCreatureFromAsset();
    }

    private bool canAttackNow = false;
    public bool CanAttackNow
    {
        get
        {
            return canAttackNow;
        }

        set
        {
            canAttackNow = value;

            //CreatureGlowImage.enabled = value;
        }
    }

    public void ReadCreatureFromAsset()
    {
        // Change the card graphic sprite
        CreatureGraphicImage.sprite = cardAsset.CardImage;
        CardBodyImage.sprite = cardAsset.CardBody;
        AttackText.text = cardAsset.Attack.ToString();
        HealthText.text = cardAsset.MaxHealth.ToString();

        if (PreviewManager != null)
        {

            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        };

        // 3) Cambiar colores

        // Si es beozniano

        if (cardAsset.CardType == 1 && cardAsset.Soldier == true)
        {
            NameText.color = new Color32(255, 8, 96, 255);
            HealthText.color = new Color32(255, 8, 96, 255);
            AttackText.color = new Color32(229, 148, 250, 255);
            EscudoText.color = new Color32(229, 148, 250, 255);

        }
        else if (cardAsset.CardType == 1 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(255, 8, 96, 255);
            HealthText.color = new Color32(255, 8, 96, 255);
            AttackText.color = new Color32(229, 148, 250, 255);
            EscudoText.color = new Color32(229, 148, 250, 255);
            IngenioText.color = new Color32(229, 148, 250, 255);
            DestrezaText.color = new Color32(229, 148, 250, 255);

        }

        // Si es regimen

        if (cardAsset.CardType == 2 && cardAsset.Soldier == true)
        {
            NameText.color = new Color32(255, 30, 42, 255);
            HealthText.color = new Color32(255, 30, 42, 255);
            AttackText.color = new Color32(26, 26, 26, 255);
            EscudoText.color = new Color32(26, 26, 26, 255);

        }
        else if (cardAsset.CardType == 2 && cardAsset.Soldier == false)
        {

            NameText.color = new Color32(255, 30, 42, 255);
            HealthText.color = new Color32(255, 30, 42, 255);
            AttackText.color = new Color32(26, 26, 26, 255);
            EscudoText.color = new Color32(26, 26, 26, 255);
            IngenioText.color = new Color32(26, 26, 26, 255);
            DestrezaText.color = new Color32(26, 26, 26, 255);

        }

        // Si es Rebelde

        if (cardAsset.CardType == 3 && cardAsset.Soldier == true)
        {
            NameText.color = new Color32(255, 255, 255, 255);
            HealthText.color = new Color32(255, 255, 255, 255);
            AttackText.color = new Color32(86, 4, 4, 255);
            EscudoText.color = new Color32(86, 4, 4, 255);

        }
        else if (cardAsset.CardType == 3 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(255, 255, 255, 255);
            HealthText.color = new Color32(255, 255, 255, 255);
            AttackText.color = new Color32(86, 4, 4, 255);
            EscudoText.color = new Color32(86, 4, 4, 255);
            IngenioText.color = new Color32(86, 4, 4, 255);
            DestrezaText.color = new Color32(86, 4, 4, 255);

        }

        // Si es Hambur


        if (cardAsset.CardType == 4 && cardAsset.Soldier == true)
        {
            NameText.color = new Color32(99, 30, 0, 255);
            HealthText.color = new Color32(99, 30, 0, 255);

            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);

        }
        else if (cardAsset.CardType == 4 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(99, 30, 0, 255);
            HealthText.color = new Color32(99, 30, 0, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);
            IngenioText.color = new Color32(255, 255, 255, 255);
            DestrezaText.color = new Color32(255, 255, 255, 255);

        }

        // Si es Reptiliano

        if (cardAsset.CardType == 5 && cardAsset.Soldier == true)
        {
            NameText.color = new Color32(190, 234, 31, 255);
            HealthText.color = new Color32(255, 153, 0, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);

        }
        else if (cardAsset.CardType == 5 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(190, 234, 31, 255);
            HealthText.color = new Color32(255, 153, 0, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);
            IngenioText.color = new Color32(255, 255, 255, 255);
            DestrezaText.color = new Color32(255, 255, 255, 255);

        }

        AttackText.text = cardAsset.Attack.ToString();
        HealthText.text = cardAsset.MaxHealth.ToString() + "PV";

        // 4) Escudo
        EscudoText.text = cardAsset.Escudo.ToString(); ;

        // 5) Ingenio
        IngenioText.text = cardAsset.Ingenio.ToString();

        // 6) Destreza
        DestrezaText.text = cardAsset.Destreza.ToString();

        // 6) Iconos

        AttackIcon.sprite = cardAsset.AttackIcon;
        ShieldIcon.sprite = cardAsset.ShieldIcon;
        DestrezaIcon.sprite = cardAsset.DestrezaIcon;
        IngenioIcon.sprite = cardAsset.IngenioIcon;

        RecuadroIconA.sprite = cardAsset.RecuadroIcon;
        RecuadroIconS.sprite = cardAsset.RecuadroIcon;
        RecuadroIconI.sprite = cardAsset.RecuadroIcon;
        RecuadroIconD.sprite = cardAsset.RecuadroIcon;

    }	




    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount > 0)
        {
            DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }
}
