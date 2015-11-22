﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[AddComponentMenu("Scripts/VisualScripts/Loja/Shop Content")]
public class Shop_Content : MonoBehaviour
{

    Sprite Sprite;
    public Image Imagem;
    public Text Nome, Quantidade;
    public EventTrigger eventos;
    public Shop Loja;
    public int indiceDoItem = 0;
    Text descricao;
    // Use this for initialization
    void Start()
    {
        Loja = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
        if (Loja)
        {
            Nome.text = Loja.Produtos[indiceDoItem].Nome + "\tPreço: " + Loja.Produtos[indiceDoItem].Preco;
            Quantidade.text = "0";
            Sprite = Loja.Produtos[indiceDoItem].Img;
            Imagem.sprite = Sprite;
            descricao = GameObject.Find("Descricao_Painel").GetComponent<Text>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { Descricao(); });
        eventos.triggers.Add(entry);

    }

    // Update is called once per frame
    void Update()
    {
        if(!Loja)
        {
            Loja = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
            Nome.text = Loja.Produtos[indiceDoItem].Nome + "\tPreço: " + Loja.Produtos[indiceDoItem].Preco;
            Quantidade.text = "0";
            Imagem.sprite = Loja.Produtos[indiceDoItem].Img;
        }
        else
        {
            Quantidade.text = Loja.Quantidades[indiceDoItem].ToString();
        }
        
        
    }

    public void AumentarQuantidade()
    {
        if (Loja)
            Quantidade.text = Loja.AumentarQuantidade(indiceDoItem).ToString();
    }
    public void DiminuirQuantidade()
    {
        if (Loja)
            Quantidade.text = Loja.DiminuirQuantidade(indiceDoItem).ToString();
    }
    public void Descricao()
    {
        if (Loja)
            Loja.ItemSelect = indiceDoItem;
    }
    

}
