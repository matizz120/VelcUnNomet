using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Jāimportē, lai varētu strādāt ar EventSystem
using UnityEngine.EventSystems;
public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler{
    //Uzglabāt norādi uz Objektu skriptu
    public Objekti objektuSkripts;
    //Velkamam objektam piestiprinātā komponente
    private CanvasGroup kanvasGrupa;
    //Vilktā objekta atrašanās vietas koordinātu maiņai
    private RectTransform velkObjRectTransf;

    void Awake()
    {
        //Piekļūst objektam piesaistītajai CanvasGroup komponentei
        kanvasGrupa = GetComponent<CanvasGroup>();
        //Piekļūst objekta RectTransform komponentei
        velkObjRectTransf = GetComponent<RectTransform>();
    }

    //Nostrādā nospiežot peles klikšķi uz objekta
    public void OnPointerDown(PointerEventData notikums)
    {
        Debug.Log("Uzklikšķināts uz velkamā objekta!");
    }

    //Nostrādā uzsākot vilkšanu
    public void OnBeginDrag(PointerEventData notikums)
    {
        //Attīra pēdējo vilkto objektu
        objektuSkripts.pedejaisVilktais = null;
        Debug.Log("Uzsākta vilkšana!");
        //Uzsākot vilkt objektu tas paliek nedaudz caurspīdīgs
        kanvasGrupa.alpha = 0.6f;
        //Lai objektam varētu iet cauri raycast stars
        kanvasGrupa.blocksRaycasts = false;
    }
    //Nostrādā reāli notiekot vilkšanai
    public void OnDrag(PointerEventData notikums)
    {
        Debug.Log("Notiek vilkšana!");
        velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
    }
    public void OnEndDrag(PointerEventData notikums){
        objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
        Debug.Log("Pēdējais vilktais objekts: "+objektuSkripts.pedejaisVilktais);
         Debug.Log("Beidzas!");
         //Atlaižot objektu paliek necaurspīdīgs
         kanvasGrupa.alpha = 1f;

         //Pārbauda vai objekts ir vienkārši nomest vai arī nomests pareizajā vietā
         if(objektuSkripts.vaiIstajaVieta == false){
            //Ja nav nomests pareizajā vietā, atkal padara velkamu
            kanvasGrupa.blocksRaycasts = true;
         }else{
             //Ja objekts nolikts pareizajā vietā, izmērā, rotācijā , tad pēdējo vilkto attīra
             objektuSkripts.pedejaisVilktais = null;
         }
         // Ja viens objekts nomests pareizajā vietā, tad lai varētu tuorpināt pārvietot pārējos objektus
         objektuSkripts.vaiIstajaVieta = false;
    }
}
