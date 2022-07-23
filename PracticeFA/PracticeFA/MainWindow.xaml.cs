using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using PracticeFA.Models;

namespace PracticeFA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Extractor> extractors = new ObservableCollection<Extractor>();
        private ObservableCollection<TaskItem> taskItems;
        public bool AllCheckCondition;

        public event PropertyChangedEventHandler PropertyChanged;


        private string _fromParent;

        public string FromParent
        {
            get { return _fromParent; }
            set
            {
                _fromParent = value;
                RaisePropertyChanged(nameof(FromParent));
            }
        }



        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            this.TaskItems = new ObservableCollection<TaskItem>();
            this.Loaded += MainWindow_Loaded;
            this.DataContext = this;

            this.FromParent = "long";

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            await PopulateDataAsync();

            Add_Click(null, null);
        }



        private async Task PopulateDataAsync()
        {
            string filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Extractors.xml");
            var xml = await File.ReadAllTextAsync(filePath);
            try
            {
                var serializer = new XmlSerializer(typeof(ExtractorsUIConfig));
                using (var reader = new StringReader(xml))
                {
#pragma warning disable CA3075 // Insecure DTD processing in XML
                    var serializedExtractors = (ExtractorsUIConfig)serializer.Deserialize(reader);
#pragma warning restore CA3075 // Insecure DTD processing in XML
                    foreach (var item in serializedExtractors.TextFeatureExtractor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "string", ExtractorType = "TextFeatureExtractor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);

                    }

                    foreach (var item in serializedExtractors.BuiltInTextFeatureExtractor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "string", ExtractorType = "BuiltInTextFeatureExtractor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);
                    }

                    foreach (var item in serializedExtractors.BuiltInNumericExtractor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "long", ExtractorType = "BuiltInNumericFeatureExtractor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);
                    }

                    foreach (var item in serializedExtractors.TextProcessor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "bool", ExtractorType = "TextProcessor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);
                    }

                    foreach (var item in serializedExtractors.FunctionalProcessor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "bool", ExtractorType = "FunctionalProcessor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);
                    }

                    foreach (var item in serializedExtractors.ObjectExtractor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "object", ExtractorType = "ObjectExtractor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);
                    }

                    foreach (var item in serializedExtractors.NumericFeatureExtractor)
                    {
                        Extractor extractor = new Extractor { Name = item.Name, ExtractorDataType = "long", ExtractorType = "NumericFeatureExtractor" };
                        extractor.ExtractorParameterGroups = GetExtractorParameterGroups(item.ParameterGroup);
                        this.extractors.Add(extractor);
                    }
                }
            }
            catch (Exception exception)
            {
                var message = exception.Message;
            }
        }

        /// <summary>
        /// method to fill param
        /// </summary>
        /// <param name="name">param input</param>
        /// <param name="parameterGroups">param group</param>
        /// <param name="type"> type input</param>
        /// <param name="extractordatatype"> extractor data type</param>
        /// <returns> task item</returns>
        private ObservableCollection<ExtractorParameterGroup> GetExtractorParameterGroups(List<ParameterGroup> parameterGroups)
        {
            var extractorParameterGroups = new ObservableCollection<ExtractorParameterGroup>();

            foreach (var pg in parameterGroups)
            {
                ExtractorParameterGroup extractorParameterGroup = new ExtractorParameterGroup();
                extractorParameterGroup.Type = pg.Type;
                extractorParameterGroup.ExtractorParameters = new ObservableCollection<ExtractorParameter>();

                foreach (var parameter in pg.Parameter)
                {
                    var extractorParameter = new ExtractorParameter()
                    {
                        Template = parameter.Template,
                        Name = parameter.Name,
                        DefaultValue = parameter.Default,
                        GroupType = pg.Type,
                        DataType = parameter.Type,
                        MaxValue = parameter.MaxValue,
                        MinValue = parameter.MinValue,
                    };
                    extractorParameter.Values = new ObservableCollection<string>(parameter.AllowedValues);
                    extractorParameterGroup.ExtractorParameters.Add(extractorParameter);
                }
                extractorParameterGroups.Add(extractorParameterGroup);
            }
            return extractorParameterGroups;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            extractors = new ObservableCollection<Extractor>();
            await PopulateDataAsync();
            TaskItem listItem = new TaskItem()
            {
                Extractors = extractors,
            };
            this.TaskItems.Add(listItem);
        }

        public ObservableCollection<TaskItem> TaskItems
        {
            get => taskItems;
            set
            {
                taskItems = value;
                RaisePropertyChanged(nameof(TaskItems));
            }
        }

        private TaskItem selectedTaskItem;
        public TaskItem SelectedTaskItem
        {
            get => selectedTaskItem;
            set
            {
                selectedTaskItem = value;
                RaisePropertyChanged(nameof(SelectedTaskItem));
            }
        }

        ///// <summary>
        ///// Method to Save Extractors
        ///// </summary>
        ///// <exception cref="Exception"> throw ex</exception>
        public void SaveExtractors()
        {
            if (this.taskItems.Count == 0)
            {
                Close();
                return;
            }

            ExtractorsUIConfig extractorsUIConfig = new ExtractorsUIConfig();

            foreach (var item in taskItems)
            {
                if (item.Id == null)
                {
                    MessageBox.Show("Please Enter value for ID");
                    return;
                }

                FeatureExtractor featureExtractor = new FeatureExtractor();
                featureExtractor.Name = item.SelectedExtractor.Name;
                featureExtractor.ParameterGroup = new List<ParameterGroup>();
                featureExtractor.Name = item.SelectedExtractor.Name;
                foreach (var group in item.SelectedExtractor.ExtractorParameterGroups)
                {
                    if (item.SelectedExtractor.ExtractorType == "TextFeatureExtractor")
                    {
                    }
                    foreach (var parameter in group.ExtractorParameters)
                    {
                        ValidateExtractorParameterGroup(parameter);
                    }
                }
            }
        }

        /// <summary>
        /// This method will validate the textbox
        /// </summary>
        /// <param name="item">ListSet Item</param>
        /// <param name="label">TextBox Label</param>
        /// <param name="value">TexBox Entered Value</param>
        /// <returns>whether textbox is validated or not</returns>
        public void ValidateExtractorParameterGroup(ExtractorParameter parameter)
        {
            if (parameter.GroupType == "Required")
            {
                if (string.IsNullOrEmpty(parameter.SelectedValue))
                {
                    MessageBox.Show("Please Fill data for " + parameter.Name);
                    return;
                }
                else
                {
                    if ((parameter.DataType == "long") && !long.TryParse(parameter.SelectedValue, out long result))
                    {
                        MessageBox.Show("Please enter long datatype for " + parameter.Name);
                        return;
                    }

                    if ((parameter.DataType == "double") && !double.TryParse(parameter.SelectedValue, out double resultdouble))
                    {
                        MessageBox.Show("Please enter double datatype for " + parameter.Name);
                        return;
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveExtractors();
        }


        private void Extractor_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}

// TODO: Closing the Extractor Row
//2. UI Alignments for both parent and child
//3.Multiselect combo box show selected items in comma separated
//4.Two Any's
//5. Dynamic populating Controls
