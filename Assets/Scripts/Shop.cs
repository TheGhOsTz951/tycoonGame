using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] int income; // Money generati ogni tot time dallo shop
    [SerializeField] Text incomeText; // Testo a schermo di income
    [SerializeField] float time; // Tempo di attesa per generare money

    private int quantity; // La quantita' dello shop posseduta
    [SerializeField] Text quantityText; // Testo a schermo di quantity
    
    [SerializeField] Button buyBtn; // Pulsante a schermo buy

    [SerializeField] Text shopPriceText; // Testo a schermo di shopPrice
    [SerializeField] int shopPrice; // Prezzo dello shop attuale
    [SerializeField] float priceIncPerc; // Percentuale incremento del prezzo ad ogni acquisto
    
    private float tempTime = 0; // Utilizzata per calcolare il tempo passato nella function update()
    private const float tempTimeCheck = 0.2f; // Serve per chiamare il metodo ogni tot secondi  

    /*
     * Aumenta la quantita' di shop posseduti
     * Amount: quantita' di shop da comprare
     */
    public void buyShop(int amount)
    {
        Finance finance = getFinance();

        // Se si hanno abbastanza soldi, compra l'amount di shop
        if (!finance.canRemoveMoney(this.shopPrice*amount)) return;
        finance.removeMoney(this.shopPrice*amount);

        this.quantity += amount;
        incShopPrice();
    }

    /*
     * Incrementa il prezzo degli shop ad ogni acquisto del singolo
     */
    private void incShopPrice()
    {
        this.shopPrice += (int) Mathf.Ceil((this.shopPrice * this.priceIncPerc) / 100);
        refreshTexts();
    }

    /*
     * Controlla se si hanno abbastanza soldi per poter comprare uno shop
     * dopodiche' imposta il colore del pulsante in base al risultato
     */
    private void checkIfAvaible()
    {
        Finance finance = getFinance();

        if(finance.canRemoveMoney(this.shopPrice))
        {
            buyBtn.GetComponent<Image>().color = Color.magenta;

        } else
        {
            buyBtn.GetComponent<Image>().color = Color.gray;
        }
    }

    // Aggiorna tutti i testi a schermo variabili con i valori attuali
    private void refreshTexts()
    {
        this.shopPriceText.GetComponent<Text>().text = this.shopPrice.ToString() + "$";
        this.quantityText.GetComponent<Text>().text = "x" + quantity.ToString();
        this.incomeText.GetComponent<Text>().text = (income * quantity).ToString() + "$/" + time.ToString() + "s";
        checkIfAvaible();
    }

    // Ottiene la classe finance per poter utilizzare i dati attuali interni
    private Finance getFinance()
    {
        GameObject fin = GameObject.Find("GameFinance");
        Finance finance = fin.GetComponent<Finance>();

        return finance;
    }

    // Return quanto guadagna lo shop
    public int getIncome()
    {
        return income*quantity;
    }

    public float getTime()
    {
        return time;
    }

    private void Start()
    {
        this.quantity = 0;
        refreshTexts();
    }
    private void Update()
    {
        tempTime += Time.deltaTime;

        if(tempTime > tempTimeCheck)
        {
            tempTime = 0;
            checkIfAvaible();
        }
    }
}
