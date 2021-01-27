        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class Maneger : MonoBehaviour
        {
           public static Maneger CompoundFinderer;
       

           public CompoundClass ansverCompound;

           public Camera cam;
           public GameObject prefeb;


           public CompoundClass[] Compounds;
           List<CompoundClass> foundObjects;
           List<CompoundClass> foundObjects2;
           CompoundClass foundCompound;

           public List<ElementClass> mobilElements;
           CompoundClass Result;


           public GameObject Kart1;
           public CardBehavior script1;
           public GameObject Kart2;
           public CardBehavior script2;
           public GameObject Kart3;
           public  CardBehavior script3;


            bool kart1Trigger;
            bool kart2Trigger;
            bool kart3Trigger;

  

            public GameObject instantiateionObj;

            void Awake()
            {
                if (CompoundFinderer != null)
                    GameObject.Destroy(CompoundFinderer);
                else
                    CompoundFinderer = this;

                DontDestroyOnLoad(this);


                foundObjects = new List<CompoundClass>();
                foundObjects2 = new List<CompoundClass>();

                script1 = Kart1.GetComponent<CardBehavior>();
                script2 = Kart2.GetComponent<CardBehavior>();
                script3 = Kart3.GetComponent<CardBehavior>();


            }

            private void Start()
            {



            }


            private void Update()
            {
                kart1Trigger = script1.isTrigger;
                kart2Trigger = script2.isTrigger;
                kart3Trigger = script3.isTrigger;
        
    
            //Bir kart seçer ve bileşiği onun üzerinde canlandırır

          
                if (null != CompoundFinderMeth())
                {

                    if (ansverCompound == null)
                    {

                        ansverCompound = CompoundFinderMeth();
                        ResultMeth();
                    

                    }
                    else if (ansverCompound != CompoundFinderMeth())
                    {
                        ansverCompound = CompoundFinderMeth();
                        ResultMeth();
                    }


                  ShowCompundModel();
                


                }




            }

           //Bileşik Modelini kartın üstünde canlandırmaya yarar
           public void ShowCompundModel()
           {


            if (script1.compound != null)
            {

                        compoundDestroy(Kart1);
                        GameObject go = Instantiate(script1.compound.compundModel, Kart1.transform);

                        go.transform.localScale = new Vector3(50, 200, 50);
                        go.transform.localPosition += new Vector3(0, 2, 0);


        }
            else if (script2.compound != null)
            {



                        compoundDestroy(Kart2);
                        GameObject go = Instantiate(script2.compound.compundModel, Kart2.transform);


                        go.transform.localScale = new Vector3(50, 200, 50);
                        go.transform.localPosition += new Vector3(0, 2, 0);


        }
            else if (script3.compound != null)
            {


                        compoundDestroy(Kart3);
                        GameObject go = Instantiate(script3.compound.compundModel, Kart3.transform);

                         go.transform.localScale = new Vector3(50, 200, 50);
                         go.transform.localPosition += new Vector3(0, 2, 0);

            }



        }


           //kartın üstünü temizler, bileşiği atar, üstüne ekleynecek kartı seçer 
 
           public void ResultMeth()
            {



                    if (kart1Trigger && kart2Trigger&&kart3Trigger)
                    {
                      if (script1.element != null && script2.element != null&&script3.element!=null)
                      {
                     
                      

                        if (script1.element.elektronCaunt >= script2.element.elektronCaunt&& script1.element.elektronCaunt >= script3.element.elektronCaunt)
                        {
                            script1.compound = ansverCompound;
                        }
                        else if (script2.element.elektronCaunt >= script1.element.elektronCaunt && script2.element.elektronCaunt >= script3.element.elektronCaunt)
                        {
                            script2.compound = ansverCompound;
                        }
                        else
                        {
                            script3.compound = ansverCompound;
                        }
                           script1.element = null;
                           script2.element = null;
                           script3.element = null;
                      
                           ElektronClose(Kart1);
                           ElektronClose(Kart2);
                           ElektronClose(Kart3);
                           ansverCompound = null;
                  
                      }

                    }
                    if (kart1Trigger&&kart2Trigger&& !kart3Trigger)
                    {
                  

                         if (script1.element != null && script2.element!=null)
                         {
                             if (script1.element.elektronCaunt > script2.element.elektronCaunt)
                             {
                                 script1.compound = ansverCompound;
                    
                    
                             }
                         }
                         else if (script1.compound != null)
                         {
                             script1.compound = ansverCompound;
                         }
                         else
                         {
                            script2.compound = ansverCompound;
                         }
                            script1.element = null;
                            script2.element = null;
                      
                            ElektronClose(Kart1);
                            ElektronClose(Kart2);
                            ansverCompound = null;
                              
                               
                  



                    }
                    if (kart2Trigger && kart3Trigger&& !kart1Trigger)
                    {
                  
                   
                        if (script2.element != null && script3.element != null)
                        {
                            if (script2.element.elektronCaunt > script3.element.elektronCaunt)
                            {
                                script2.compound = ansverCompound;
                   
                   
                            }
                        }
                        else if (script2.compound != null)
                        {
                            script2.compound = ansverCompound;
                        }
                        else
                        {
                           script3.compound = ansverCompound;
                        }

                        script2.element = null;
                        script3.element = null;
                  
                  
                        ElektronClose(Kart2);
                        ElektronClose(Kart3);
                  
                  
                  
                        ansverCompound = null;
                    




                    }
                    if (kart1Trigger && kart3Trigger&& !kart2Trigger)
                    {

                   

                         if (script1.element!=null&& script3.element != null)
                         {
                         if (script1.element.elektronCaunt > script3.element.elektronCaunt)
                         {  
                            script1.compound = ansverCompound;
                       
                     
                         }
                      }
                      else if (script1.compound != null)
                      {
                        script1.compound = ansverCompound;
                    
                      }
                      else
                      {  
                          script3.compound = ansverCompound;
                 
                      }

                        script1.element = null;
                        script3.element = null;
                  
                        ElektronClose(Kart1);
                        ElektronClose(Kart3);
                  
                        ansverCompound = null;
                  

                    }


  



            }



            //Trigırlanma olayına göre hangi founding methoduna gireceğini ayarlayan ve dışarıya bileşik döndüren method
            public CompoundClass CompoundFinderMeth()
            {
                Result = null;

                if (kart1Trigger == true && kart2Trigger == true && kart3Trigger == true)
                {
                    if (script1.element != null && script2.element != null && script3.element != null)
                    {
                        Result = Founding(script1.element, script2.element, script3.element);
               

                    }



                }
                else if (kart1Trigger == true && kart2Trigger == true && kart3Trigger == false)
                {
                    if (script1.element != null && script2.element != null)
                    {

                        Result = Founding(script1.element, script2.element);

             


                    }
                    else if (script1.compound != null)
                    {

                        Result = Founding(script1.compound, script2.element);


           
                    }
                    else if (script2.compound != null)
                    {
                        Result = Founding(script2.compound, script1.element);
       

             
                    }

                }
                else if (kart1Trigger == true && kart3Trigger == true && kart2Trigger == false)
                {
                    if (script1.element != null && script3.element != null)
                    {

                        Result = Founding(script1.element, script3.element);
               



                    }
                    else if (script1.compound != null)
                    {

                        Result = Founding(script1.compound, script3.element);
             

    

                    }
                    else if (script3.compound != null)
                    {
                        Result = Founding(script3.compound, script1.element);
     
  
                    }
                }
                else if (kart2Trigger == true && kart3Trigger == true && kart1Trigger == false)
                {
                    if (script2.element != null && script3.element != null)
                    {

                        Result = Founding(script2.element, script3.element);
               

  


                    }
                    else if (script2.compound != null)
                    {

                        Result = Founding(script2.compound, script3.element);
            

     

                    }
                    else if (script3.compound != null)
                    {
                        Result = Founding(script3.compound, script2.element);


  
                    }

                }
                else
                {

                    Result = null;
   
                }


     
                return Result;

            }

            //gelen iki elementin oluşturduğu bileşiği bulur
            public CompoundClass Founding(ElementClass element1, ElementClass element2)
            {


                foundObjects = new List<CompoundClass>();

                for (int i = 0; i < Compounds.Length; i++)
                {
                    for (int j = 0; j < Compounds[i].components.Length; j++)
                    {
                        if (element1.elektronCaunt == Compounds[i].components[j].elektronCaunt)
                        {


                            foundObjects.Add(Compounds[i]);

                        }
                    }
                }


                foundObjects2 = new List<CompoundClass>();

                for (int i = 0; i < foundObjects.Count; i++)
                {
                    for (int j = 0; j < foundObjects[i].components.Length; j++)
                    {
                        if (element2.elektronCaunt == foundObjects[i].components[j].elektronCaunt)
                        {

                            foundObjects2.Add(foundObjects[i]);

                        }
                    }
                }

                foundCompound = null;

                for (int i = 0; i < foundObjects2.Count; i++)
                {

                    if (foundObjects2[i].components.Length == 2)
                    {
                        if (element1 != element2)
                        {
                            foundCompound = foundObjects2[i];
                        }


                    }

                }








                return foundCompound;




            }


            //gelen üç elementin oluşturduğu bileşiği bulur
            public CompoundClass Founding(ElementClass element1, ElementClass element2, ElementClass element3)
            {


                foundObjects = new List<CompoundClass>();

                for (int i = 0; i < Compounds.Length; i++)
                {
                    for (int j = 0; j < Compounds[i].components.Length; j++)
                    {
                        if (element1.elektronCaunt == Compounds[i].components[j].elektronCaunt)
                        {
                            foundObjects.Add(Compounds[i]);

                        }
                    }
                }

                foundObjects2 = new List<CompoundClass>();

                for (int i = 0; i < foundObjects.Count; i++)
                {
                    for (int j = 0; j < foundObjects[i].components.Length; j++)
                    {
                        if (element2.elektronCaunt == foundObjects[i].components[j].elektronCaunt)
                        {
                            foundObjects2.Add(foundObjects[i]);

                        }
                    }
                }


                foundObjects = new List<CompoundClass>();

                for (int i = 0; i < foundObjects2.Count; i++)
                {
                    for (int j = 0; j < foundObjects2[i].components.Length; j++)
                    {
                        if (element3.elektronCaunt == foundObjects2[i].components[j].elektronCaunt)
                        {
                            foundObjects.Add(foundObjects2[i]);

                        }
                    }
                }



                foundObjects2 = new List<CompoundClass>();


                for (int i = 0; i < foundObjects.Count; i++)
                {
                    if (foundObjects[i].components.Length == 3)
                    {

                        if (element1.elektronCaunt == element2.elektronCaunt || element1.elektronCaunt == element3.elektronCaunt || element2.elektronCaunt == element3.elektronCaunt)
                        {

                            for (int j = 0; j < foundObjects[i].components.Length; j++)
                            {

                                if (foundObjects[i].components[j].elektronCaunt != element1.elektronCaunt && foundObjects[i].components[j].elektronCaunt != element2.elektronCaunt && foundObjects[i].components[j].elektronCaunt != element3.elektronCaunt)
                                {

                                }
                                else
                                {
                                    foundObjects2.Add(foundObjects[i]);
                                }



                            }


                        }


                    }
                }

                foundCompound = null;

                foundCompound = foundObjects2[0];

                List<ElementClass> sepet = new List<ElementClass>();

                for (int i = 0; i < foundObjects2[0].components.Length; i++)
                {
                    sepet.Add(foundObjects2[0].components[i]);
                }

      


                for (int i = 0; i < sepet.Count; i++)
                {
                    if (element1== sepet[i])
                    {
                        sepet.Remove(sepet[i]);

                    }

                }
                for (int i = 0; i < sepet.Count; i++)
                {
                    if (element2 == sepet[i])
                    {
                        sepet.Remove(sepet[i]);
                    }

                }
                for (int i = 0; i < sepet.Count; i++)
                {

                    if (element3 == sepet[i])
                    {
                        sepet.Remove(sepet[i]);

                    }

                }

                if (sepet.Count>0)
                {

                    return null;
                }
                else
                {
                    return foundCompound;
                }

        




            }


            //Bir bileşik ve bir element gelirse 
            public CompoundClass Founding(CompoundClass compound,ElementClass element)
            {

                if (compound.components.Length==2&& element != null)
                {
           
                    return Founding(compound.components[0], compound.components[1], element);
              

                
                }
                else
                {
                    return null;
                }



            }




            //Elementin etrafındaki elektronları kapatır
            public void ElektronClose(GameObject Kart)
        {


            for (int i = 0; i < Kart.transform.Find("Element").childCount; i++)
            {
                if (Kart.transform.Find("Element").GetChild(i).gameObject.activeSelf == true)
                {
                    Kart.transform.Find("Element").GetChild(i).gameObject.SetActive(false);
                }

            }

            if (Kart.transform.Find("Element").gameObject.activeSelf==true)
            {
                Kart.transform.Find("Element").gameObject.SetActive(false);
            }

        }


            public void compoundDestroy(GameObject kart)
            {
              for (int i = 0; i < kart.transform.childCount; i++)
              {
            
                  if (kart.transform.GetChild(i).name != "Element")
                  {
             
                      Destroy(kart.transform.GetChild(i).gameObject);


                  }
          
              }

            }


        }


