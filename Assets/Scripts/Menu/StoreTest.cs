using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreTest : MonoBehaviour
{
    
    public Text Creditos;

    
    public int CreditosInt = 550;


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        Creditos.text = CreditosInt.ToString(); 

    }

    public void BuyTest5()
    {
        CreditosInt -= 5;
        Creditos.text = CreditosInt.ToString();

    }

    public void BuyTest15()
    {

        CreditosInt -= 15;
        Creditos.text = CreditosInt.ToString();

    }

    public void BuyTest40()
    {
        CreditosInt -= 40;
        Creditos.text = CreditosInt.ToString();


    }
}
