using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaPriceComparer : MonoBehaviour
{
    // UI elements for the first column
    public Dropdown shapeDropdown1;
    public InputField priceInput1;
    public InputField diameterInput1;
    public Text pricePerCmText1;

    // UI elements for the second column
    public Dropdown shapeDropdown2;
    public InputField priceInput2;
    public InputField diameterInput2;
    public Text pricePerCmText2;

    // UI elements for the third column
    public Dropdown shapeDropdown3;
    public InputField priceInput3;
    public InputField diameterInput3;
    public Text pricePerCmText3;
    
    
    


    public void CalculatePrices()
    {
        // Perform the calculations
        CalculatePriceForInput(priceInput1, diameterInput1, pricePerCmText1, shapeDropdown1);
        CalculatePriceForInput(priceInput2, diameterInput2, pricePerCmText2, shapeDropdown2);
        CalculatePriceForInput(priceInput3, diameterInput3, pricePerCmText3, shapeDropdown3);
    }

    private void CalculatePriceForInput(InputField priceInput, InputField sizeInput, Text resultText, Dropdown shapeDropdown)
    {
        if(float.TryParse(priceInput.text, out float price) && float.TryParse(sizeInput.text, out float size))
        {
            float area;
            if (shapeDropdown.value == 1) // Assuming '0' is the index for Round
            {
                // Calculate area for round pizza
                area = Mathf.PI * Mathf.Pow(size / 2, 2);
            }
            else // Assuming '1' is the index for Square
            {
                // Calculate area for square pizza
                area = size * size;
            }

            float pricePerCm = price / area;
            resultText.text = $"{pricePerCm:0.##} per cm²";
        }
        else
        {
            resultText.text = "Invalid input";
        }
    }
}