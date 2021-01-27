using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackSprite : MonoBehaviour
{
    public GameObject FrontCard;

    ElementClass element;
    CompoundClass compound;




    void Start()
    {

        


    }

    void Update()
    {    //Kartın Arka Resmini Çekiyor

        element = FrontCard.GetComponent<CardBehavior>().element;
        compound = FrontCard.GetComponent<CardBehavior>().compound;

        if (element != null)
        {

            gameObject.transform.parent.Find("CardImage").gameObject.GetComponent<Image>().sprite = element.cardImageBack;

        }
        else if (compound != null)
        {

           gameObject.transform.parent.Find("CardImage").gameObject.GetComponent<Image>().sprite = compound.cardImageBack;

        }
        else
        {
            gameObject.transform.parent.Find("CardImage").gameObject.GetComponent<Image>().sprite = FrontCard.GetComponent<CardBehavior>().defaultImage;
        }


       
    

       
    }
}
