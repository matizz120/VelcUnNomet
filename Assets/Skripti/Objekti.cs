using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Objekti : MonoBehaviour
{
    //GameObject, kas uzglabā visus velkamos objektus
    public GameObject autobuss;
    public GameObject atroMasina;
    public GameObject atkritumuMasina;
    //Uzglabās velkamo objektu sākotnējās pazīcijas koordinātas (lai zinātu, kur aizmest objektu, ja tas nolikts nepareizajā vietā)
    //Objekti paliek Public, taču paslēpj no Inspector loga
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    [HideInInspector]
    public Vector2 bussKoord;
    //Uzglabās ainā esošo kanvu
    public Canvas kanva;
    //Uzglabās skaņas avotu, kurā atskaņot audio failu
    public AudioSource skanasAvots;
    //Masivs, kas uzglabā audio failus
    public AudioClip[] skanaKoAtskanot;
    //Uzglabās objektu, kurš ir pēdējais pārvietotais
    public GameObject pedejaisVilktais = null;
    //Mainīgais atbild par to vai objekts ir nolikts pareizi vai nepareizi
    [HideInInspector]
    public bool vaiIstajaVieta = false;
    private void Awake()
    {
        atkrKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atroKoord = atroMasina.GetComponent<RectTransform>().localPosition;
        bussKoord = autobuss.GetComponent<RectTransform>().localPosition;
    }
}