using UnityEngine;
using UnityEngine.UI;

public class PizzaPriceComparer : MonoBehaviour
{
    // Round pizza input fields
    public InputField priceInput1, diameterInput1;
    public InputField priceInput2, diameterInput2;
    public Text pricePerCMText1, pricePerCMText2;
    public GameObject Panel1, Panel2, Panel3;

    public Color highlightColor = new Color(0, 255, 0, 0.5f);
    private Color defaultColor = new Color(0, 0, 0, 0.5f);

    // Square pizza input fields
    public InputField priceInput3, widthInput, lengthInput;
    public Text pricePerCMText3;

    // Button
    public Button calculateButton;

    void Start()
    {
        // Add a listener to your button
        calculateButton.onClick.AddListener(CalculatePrices);
    } 

    void HighlightBestPricePanel(float pricePerArea1, float pricePerArea2, float pricePerArea3)
    {
        // Find the best price
        float bestPrice = Mathf.Min(pricePerArea1, pricePerArea2, pricePerArea3);

        // Highlight the corresponding panel
        if (bestPrice == pricePerArea1)
            HighlightPanel(Panel1);
        else if (bestPrice == pricePerArea2)
            HighlightPanel(Panel2);
        else if (bestPrice == pricePerArea3)
            HighlightPanel(Panel3);
    }

    void CalculatePrices()
    {
        // Reset panel highlights
        ResetPanelHighlights();

        // Initialize prices with a high value
        float pricePerArea1 = float.MaxValue;
        float pricePerArea2 = float.MaxValue;
        float pricePerArea3 = float.MaxValue;

        // Calculate for round pizzas
        if (!string.IsNullOrEmpty(priceInput1.text) && !string.IsNullOrEmpty(diameterInput1.text))
            pricePerArea1 = CalculateRoundPizza(priceInput1, diameterInput1, pricePerCMText1);

        if (!string.IsNullOrEmpty(priceInput2.text) && !string.IsNullOrEmpty(diameterInput2.text))
            pricePerArea2 = CalculateRoundPizza(priceInput2, diameterInput2, pricePerCMText2);

        // Calculate for square pizza
        if (!string.IsNullOrEmpty(priceInput3.text) && !string.IsNullOrEmpty(widthInput.text) && !string.IsNullOrEmpty(lengthInput.text))
            pricePerArea3 = CalculateSquarePizza(priceInput3, widthInput, lengthInput, pricePerCMText3);

        // Determine and highlight the best price panel
        HighlightBestPricePanel(pricePerArea1, pricePerArea2, pricePerArea3);
    }

    void HighlightPanel(GameObject panel)
    {
        Image panelImage = panel.GetComponent<Image>();
        if (panelImage != null)
            panelImage.color = highlightColor;
    }

    void ResetPanelHighlights()
    {
        ResetPanelColor(Panel1);
        ResetPanelColor(Panel2);
        ResetPanelColor(Panel3);
    }

    void ResetPanelColor(GameObject panel)
    {
        Image panelImage = panel.GetComponent<Image>();
        if (panelImage != null)
            panelImage.color = defaultColor;
    }

    float CalculateRoundPizza(InputField priceInput, InputField diameterInput, Text resultText)
    {
        float price = float.Parse(priceInput.text);
        float diameter = float.Parse(diameterInput.text);
        float radius = diameter / 2;
        float area = Mathf.PI * radius * radius;
        float pricePerCM = price / area;

        resultText.text = pricePerCM.ToString("F4");
        return pricePerCM;
    }

    float CalculateSquarePizza(InputField priceInput, InputField widthInput, InputField lengthInput, Text resultText)
    {
        float price = float.Parse(priceInput.text);
        float width = float.Parse(widthInput.text);
        float length = float.Parse(lengthInput.text);
        float area = width * length;
        float pricePerCM = price / area;

        resultText.text = pricePerCM.ToString("F4");
        return pricePerCM;
    }
}
