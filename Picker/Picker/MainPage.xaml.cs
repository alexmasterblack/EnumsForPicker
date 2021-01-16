using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Picker
{
    public partial class MainPage : ContentPage
    {
        public string Split(string str)
        {
            return Regex.Replace(str, "[A-Z]", " $0").Trim();
        }
        private Items selectedItem;
        public Items SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                }
            }
        }
        public List<string> ItemsNames
        {
            get
            {
                return Enum.GetNames(typeof(Items)).Select(b => Split(b)).ToList();
            }
        }
        public string Text { get; set; }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected.Text = "Вы выбрали: " + (sender as Xamarin.Forms.Picker)?.SelectedItem.ToString();
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
