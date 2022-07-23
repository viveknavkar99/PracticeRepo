using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PracticeFA.Models
{
    public class ExtractorParameter
    {
        /// <summary>
        /// The template
        /// </summary>
        public Template Template { get; set; }

        /// <summary>
        /// The Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Default Value
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        public string GroupType { get; set; }

        /// <summary>
        /// The Values
        /// </summary>
        public ObservableCollection<string> Values { get; set; }

        /// <summary>
        /// The Data Type
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// The Selected Value
        /// </summary>
        public string SelectedValue { get; set; }

        /// <summary>
        /// The Minimum Value
        /// </summary>
        public string MinValue { get; set; }

        /// <summary>
        /// The Maximum Value
        /// </summary>
        public string MaxValue { get; set; }

        /// <summary>
        /// The Maximum Value
        /// </summary>
        public bool IsAnyParameterGroup { get; set; }

        private StackPanel extractorParameterStackPanel;

        public StackPanel ExtractorParameterStackPanel
        {
            get
            {
                extractorParameterStackPanel = new StackPanel();
                extractorParameterStackPanel.Orientation = Orientation.Horizontal;
                extractorParameterStackPanel.Margin = new Thickness(5, 0, 0, 0);
                
                switch (Template)
                {
                    case Template.TextBox:
                        AddTextBox();
                        break;

                    case Template.ComboBox:
                        AddComboBox();
                        break;

                    case Template.MultilineTextBox:
                        AddMultiLineTextBox();
                        break;

                    case Template.CheckBox:
                        AddCheckBox();
                        break;

                    case Template.MultiSelectComboBox:
                        break;
                }
                return extractorParameterStackPanel;
            }
        }

        private void AddTextBox()
        {
            if (!IsAnyParameterGroup)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = Name,
                    VerticalAlignment = VerticalAlignment.Center
                };
                extractorParameterStackPanel.Children.Add(textBlock);
            } 

            TextBox textBox = new TextBox();
            textBox.Width = 100;
            textBox.Margin = new Thickness(5, 0, 0, 0);
            Binding myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("SelectedValue"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(textBox, TextBox.TextProperty, myBinding);
            extractorParameterStackPanel.Children.Add(textBox);
        }

        private void AddComboBox()
        {
            Binding myBinding;
            ComboBox comboBox = new ComboBox();
            comboBox.Width = 100;
            myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("Values"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, myBinding);

            myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("SelectedValue"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, myBinding);
            extractorParameterStackPanel.Children.Add(comboBox);
        }

        private void AddMultiLineTextBox()
        {
            if (!IsAnyParameterGroup)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = Name,
                    VerticalAlignment = VerticalAlignment.Center
                };
                extractorParameterStackPanel.Children.Add(textBlock);
            }

            TextBox multiLineTxtBox = new TextBox();
            multiLineTxtBox.AcceptsReturn = true;
            multiLineTxtBox.TextWrapping = TextWrapping.Wrap;
            multiLineTxtBox.Width = 100;
            multiLineTxtBox.Margin = new Thickness(5, 0, 0, 0);
            
            Binding myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("SelectedValue"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(multiLineTxtBox, TextBox.TextProperty, myBinding);
            extractorParameterStackPanel.Children.Add(multiLineTxtBox);
        }

        private void AddCheckBox() 
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Content = Name;
            Binding myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("SelectedValue"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(checkBox, CheckBox.IsCheckedProperty, myBinding);
            extractorParameterStackPanel.Children.Add(checkBox);
        }
    }
}
