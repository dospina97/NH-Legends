using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// holds the refs to all the Text, Images on the card
public class OneCardManager : MonoBehaviour {

    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text NameText;
    public Text ConditionText;
    public Text DescriptionText;
    public Text HealthText;
    public Text AttackText;
    public Text EscudoText;
    public Text IngenioText;
    public Text DestrezaText;

    [Header("Image References")]

    public Image CardGraphicImage;
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

    void Awake()
    {
        if (cardAsset != null)
            ReadCardFromAsset();
    }

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;

         //   CardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset()
    {

        // 1) Nombre de la carta
        NameText.text = cardAsset.name;

        // 2) Descripcion
        DescriptionText.text = cardAsset.Description;

        // 3) Cambiar sprite
        CardGraphicImage.sprite = cardAsset.CardImage;
        CardBodyImage.sprite = cardAsset.CardBody;

        // 3) Cambiar colores

        // Si es beozniano

        if (cardAsset.CardType == 1 && cardAsset.Soldier == true)
        {
            NameText.color= new Color32(255, 8, 96, 255);
            HealthText.color = new Color32(255, 8, 96, 255);

            DescriptionText.color = new Color32(229, 148, 250,255);
            AttackText.color = new Color32(229, 148, 250, 255);
            EscudoText.color = new Color32(229, 148, 250, 255);

        }
        else if (cardAsset.CardType == 1 && cardAsset.Soldier == false && cardAsset.MaxHealth == 0)
        {
            NameText.color = new Color32(255, 8, 96, 255);

            DescriptionText.color = new Color32(229, 148, 250, 255);
            ConditionText.color = new Color32(229, 148, 250, 255);
        }

        else if(cardAsset.CardType == 1 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(255, 8, 96, 255);
            HealthText.color = new Color32(255, 8, 96, 255);

            DescriptionText.color = new Color32(229, 148, 250, 255);
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

            DescriptionText.color = new Color32(26, 26, 26, 255);
            AttackText.color = new Color32(26, 26, 26, 255);
            EscudoText.color = new Color32(26, 26, 26, 255);

        }
        else if (cardAsset.CardType == 2 && cardAsset.Soldier == false && cardAsset.MaxHealth == 0)
            {
                NameText.color = new Color32(255, 30, 42, 255);

                DescriptionText.color = new Color32(26, 26, 26, 255);
                ConditionText.color = new Color32(26, 26, 26, 255);

            }

            else if (cardAsset.CardType == 2 && cardAsset.Soldier == false)
        {

            NameText.color = new Color32(255, 30, 42, 255);
            HealthText.color = new Color32(255, 30, 42, 255);

            DescriptionText.color = new Color32(26, 26, 26, 255);
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

            DescriptionText.color = new Color32(86, 4, 4, 255);
            AttackText.color = new Color32(86, 4, 4, 255);
            EscudoText.color = new Color32(86, 4, 4, 255);

        }
        else if (cardAsset.CardType == 3 && cardAsset.Soldier == false && cardAsset.MaxHealth == 0)
        {
            NameText.color = new Color32(255, 255, 255, 255);
            DescriptionText.color = new Color32(86, 4, 4, 255);
            ConditionText.color = new Color32(86, 4, 4, 255);

        }

        else if (cardAsset.CardType == 3 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(255, 255, 255, 255);
            HealthText.color = new Color32(255, 255, 255, 255);

            DescriptionText.color = new Color32(86, 4, 4, 255);
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

            DescriptionText.color = new Color32(26, 26, 26, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);

        }
        else if (cardAsset.CardType == 4 && cardAsset.Soldier == false && cardAsset.MaxHealth == 0)
        {
            NameText.color = new Color32(99, 30, 0, 255);
            DescriptionText.color = new Color32(26, 26, 26, 255);
            ConditionText.color = new Color32(255, 255, 255, 255);
        }

        else if (cardAsset.CardType == 4 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(99, 30, 0, 255);
            HealthText.color = new Color32(99, 30, 0, 255);

            DescriptionText.color = new Color32(26, 26, 26, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);
            IngenioText.color = new Color32(255, 255, 255, 255);
            DestrezaText.color = new Color32(255, 255, 255, 255);

        }

        // Si es Reptiliano

        if (cardAsset.CardType == 5 && cardAsset.Soldier == true)
        {
            NameText.color = new Color32(190, 234, 31,255);
            HealthText.color = new Color32(255, 153, 0, 255);

            DescriptionText.color = new Color32(19, 53, 4, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);

        }
        else if (cardAsset.CardType == 5 && cardAsset.Soldier == false && cardAsset.MaxHealth == 0)
        {
            NameText.color = new Color32(190, 234, 31, 255);
            DescriptionText.color = new Color32(19, 53, 4, 255);
            ConditionText.color = new Color32(255, 255, 255, 255);
        }

        else if (cardAsset.CardType == 5 && cardAsset.Soldier == false)
        {
            NameText.color = new Color32(190, 234, 31, 255);
            HealthText.color = new Color32(255, 153, 0, 255);

            DescriptionText.color = new Color32(19, 53, 4, 255);
            AttackText.color = new Color32(255, 255, 255, 255);
            EscudoText.color = new Color32(255, 255, 255, 255);
            IngenioText.color = new Color32(255, 255, 255, 255);
            DestrezaText.color = new Color32(255, 255, 255, 255);

        }

        //Tipo de carta

        if (cardAsset.MaxHealth != 0 && cardAsset.Soldier == false)
        {
            // Si la salud es diferente de 0 y no es Soldado, es Leyenda

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
        else if (cardAsset.Soldier == true)
        {
            //Es un subdito
            AttackText.text = cardAsset.Attack.ToString();
            HealthText.text = cardAsset.MaxHealth.ToString() + "PV";

            AttackIcon.sprite = cardAsset.AttackIcon;
            ShieldIcon.sprite = cardAsset.ShieldIcon;
            RecuadroIconA.sprite = cardAsset.RecuadroIcon;
            RecuadroIconS.sprite = cardAsset.RecuadroIcon;

        }
        else
        {
            //Es un efecto
            // 2) agrega condicion
            AttackIcon.sprite = cardAsset.AttackIcon;
            ShieldIcon.sprite = cardAsset.ShieldIcon;
            RecuadroIconI.sprite = cardAsset.RecuadroIcon;
            ConditionText.text = cardAsset.Condicion.ToString() + "+";

        }


        if (PreviewManager != null)
        {
            // this is a card and not a preview
            // Preview GameObject will have OneCardManager as well, but PreviewManager should be null there
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
}
