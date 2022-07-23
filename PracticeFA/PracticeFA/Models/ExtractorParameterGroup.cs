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
    public class ExtractorParameterGroup
    {
        public ObservableCollection<ExtractorParameter> ExtractorParameters { get; set; }

        private ExtractorParameter selectedExtractorParameter;
        public ExtractorParameter SelectedExtractorParameter
        {
            get { return selectedExtractorParameter; }
            set
            {
                selectedExtractorParameter = value;
                foreach (var parameter in ExtractorParameters)
                {
                    parameter.IsAnyParameterGroup = false;
                }

                selectedExtractorParameter.IsAnyParameterGroup = true;

                if (extractorParameterGroupStackPanel.Children.Count > 1)
                    extractorParameterGroupStackPanel.Children.RemoveAt(1);
                extractorParameterGroupStackPanel.Children.Add(selectedExtractorParameter.ExtractorParameterStackPanel);
            }
        }

        /// <summary>
        /// ANy, Req,OPt
        /// </summary>
        public string Type { get; set; }

        private StackPanel extractorParameterGroupStackPanel;

        public StackPanel ExtractorParameterGroupStackPanel
        {
            get
            {
                extractorParameterGroupStackPanel = new StackPanel();
                extractorParameterGroupStackPanel.Orientation = Orientation.Horizontal;
                extractorParameterGroupStackPanel.Margin = new Thickness(5, 0, 0, 0);
                switch (Type)
                {
                    case "Any":
                        AddComboBox();
                        break;
                    case "Optional":
                    case "Required":
                        foreach (var parameter in ExtractorParameters)
                        {
                            extractorParameterGroupStackPanel.Children.Add(parameter.ExtractorParameterStackPanel);
                        }
                        break;
                }
                return extractorParameterGroupStackPanel;
            }
        }

        private void AddComboBox()
        {
            Binding myBinding;
            ComboBox comboBox = new ComboBox();
            comboBox.DisplayMemberPath = "Name";
            comboBox.Width = 100;
            myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("ExtractorParameters"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, myBinding);

            myBinding = new Binding
            {
                Source = this,
                Path = new PropertyPath("SelectedExtractorParameter"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, myBinding);
            extractorParameterGroupStackPanel.Children.Add(comboBox);
        }

    }
}
