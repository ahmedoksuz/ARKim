using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{  Camera cam;

    

    List<int> elektrons = new List<int>();
    bool isPlaced=true;

    public ElementClass Element;        

    GameObject prefeb;
   






    void Start()
    {
        prefeb = Maneger.CompoundFinderer.prefeb;

        

        cam=Maneger.CompoundFinderer.cam;
        prefeb=Maneger.CompoundFinderer.prefeb;
        
    }


    public void Update()
    {


        FingerElement();


      

    }

    //butona Tıklandığında 

    public void clic()
    {
        Destroy(Maneger.CompoundFinderer.instantiateionObj);
        isPlaced = true;
       
      
        if (isPlaced==true)
        {
           
            prefeb.transform.GetComponent<ElementsBehavior>().element = Element;
           if (Input.touchCount > 0)
           {

               Touch t1 = Input.GetTouch(0);
               
               Ray ray = Camera.main.ScreenPointToRay(t1.position);
              
              
               Maneger.CompoundFinderer.instantiateionObj = Instantiate(prefeb, cam.transform.position + (ray.direction * 13), Quaternion.identity);
               isPlaced = false;
              

           } 
        }  
        
    }


    // Bir element seçildiği taktirde bir element spawn eder ve seçilen elemente göre çevresindeki elektronları açar

    void RealSpawn(GameObject Kart,CardBehavior Script)
    {
        if (Script.element == null)
        {


            Script.element = Maneger.CompoundFinderer.instantiateionObj.GetComponent<ElementsBehavior>().element;
            isPlaced = true;

            Kart.transform.transform.Find("Element").gameObject.SetActive(true);
            ElektronOpen(Script.element.elektronCaunt, Kart);
            


        }
        else
        {

            ElektronClose(Kart);
            Script.element = null;

            Script.element = Maneger.CompoundFinderer.instantiateionObj.GetComponent<ElementsBehavior>().element;
            ElektronOpen(Script.element.elektronCaunt, Kart);


        }
    }


    //Elementin etrafındaki elektronları Açar
    void ElektronOpen(int elektronCount,GameObject Kart)
    {
        elektrons = new List<int>();

        Kart.transform.Find("Element").GetComponent<Renderer>().material = Kart.GetComponent<ElementClass>().elementMaterial;


        if (elektronCount > 2)elektronCount -= 2;elektronCount = elektronCount % 8;if (elektronCount==0)elektronCount = 8;
           
        
        for (int i = 0; i < elektronCount; i++) elektrons.Add(i);
        int choosing;

        for (int i = 0; i < elektronCount;)
        {
            choosing = Random.Range(0, 8);

            if (Kart.transform.Find("Element").transform.GetChild(choosing).gameObject.activeSelf == false)
            {
                Kart.transform.Find("Element").transform.GetChild(choosing).gameObject.GetComponent<Renderer>().material = Kart.GetComponent<ElementClass>().elektronMaterial;
                Kart.transform.Find("Element").transform.GetChild(choosing).gameObject.SetActive(true);
                i++;
            }

        }

    }


    //Elementin etrafındaki elektronları kapatır
   public void ElektronClose(GameObject Kart)
    {


        for (int i = 0; i < Kart.transform.Find("Element").childCount; i++)
        {
            if (Kart.transform.Find("Element").GetChild(i).gameObject.activeSelf==true)
            {
                Kart.transform.Find("Element").GetChild(i).gameObject.SetActive(false);
            }
           
        }

    }

   public void compoundDestroy(GameObject kart)
    {
        for (int i = 0; i < kart.transform.childCount; i++)
        {
            if (kart.transform.GetChild(i).name!="Element")
            {
                if (kart.GetComponent<CardBehavior>().compound != null)
                {
                    kart.GetComponent<CardBehavior>().compound = null;
                }
                Destroy(kart.transform.GetChild(i).gameObject);

                kart.GetComponent<CardBehavior>().compound = null;
            }

        }

    }


    //Butona tıklandığında parmağının ucunda bir element oluşturur ve tıkladığın karta yerleştirir
    public void FingerElement()
    {



        if (Input.touchCount > 0)
        {
            Touch t1 = Input.GetTouch(0);


            if (Maneger.CompoundFinderer.instantiateionObj != null)
            {
                //Spawn olan Elementi  ekranda parmağının olduğu yere taşır
                Ray ray = Camera.main.ScreenPointToRay(t1.position);

                Maneger.CompoundFinderer.instantiateionObj.transform.position = cam.transform.position + (ray.direction * 13);

                if (Physics.Raycast(ray, out RaycastHit hit, 3000))
                {
                    if (Maneger.CompoundFinderer.instantiateionObj != null)
                    {



                        if (t1.phase == TouchPhase.Began)
                        {

                            //elinde tuttuğun elementi tıkladığın kartın üstüne atar

                            

                            if (isPlaced == false)
                            {
                                if (hit.transform.gameObject.tag == "Card")
                                {

                                    Destroy(Maneger.CompoundFinderer.instantiateionObj);

                                    if (hit.transform.gameObject == Maneger.CompoundFinderer.Kart1)
                                    {


                                        compoundDestroy(Maneger.CompoundFinderer.Kart1);
                                        RealSpawn(Maneger.CompoundFinderer.Kart1, Maneger.CompoundFinderer.script1);
                                        
                                        isPlaced = true;

                                    }
                                    else if (hit.transform.gameObject == Maneger.CompoundFinderer.Kart2)
                                    {

                                        compoundDestroy(Maneger.CompoundFinderer.Kart2);

                                        RealSpawn(Maneger.CompoundFinderer.Kart2, Maneger.CompoundFinderer.script2);

                                        isPlaced = true;
                                    }
                                    else if (hit.transform.gameObject == Maneger.CompoundFinderer.Kart3)
                                    {

                                        compoundDestroy(Maneger.CompoundFinderer.Kart3);
                                        RealSpawn(Maneger.CompoundFinderer.Kart3, Maneger.CompoundFinderer.script3);

                                        isPlaced = true;

                                    }



                                }
                            }



                        }
                    }
                }

            }
        }

    }


    

    

}
