using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Converter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public double[,] massive = new double[,]
        {
            { 1.0, 0.001, 0.000621 },
            { 1000.0, 1.0, 0.621371 },
            { 1609.34, 1.61, 1.0 }
        };

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            // Try to parse the input text to a double
            if (double.TryParse(textInput.Text, out double variable))
            {
                int selectedIndex1 = myPicker1.SelectedIndex;
                int selectedIndex2 = myPicker2.SelectedIndex;
                // Check if the selected indices are valid
                if (selectedIndex1 != -1 && selectedIndex2 != -1)
                {
                    // Calculate the result using the massive array
                    double result = massive[selectedIndex1, selectedIndex2] * variable;
                    selectedStateLabel.Text = $"Результат: {result}   ({(string)myPicker2.SelectedItem})";
                }
                else
                {
                    selectedStateLabel.Text = "Пожалуйста, выберите оба элемента.";
                }
            }
            else
            {
                selectedStateLabel.Text = "Пожалуйста, введите корректное число.";
            }
        }
        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculator());
        }
    }
}
