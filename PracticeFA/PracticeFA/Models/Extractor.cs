using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFA.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Controls;

    /// <summary>
    /// The Class Extractor
    /// </summary>
    public class Extractor : INotifyPropertyChanged
    {
        /// <summary>
        /// event prop change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise Property Changed
        /// </summary>
        /// <param name="propertyName">Selected Property</param>
        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// gets or sets Name
        /// </summary>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.RaisePropertyChanged(nameof(this.Name));
            }
        }

        /// <summary>
        /// The extractordatatype
        /// </summary>
        private string extractordatatype;

        /// <summary>
        /// gets or sets Extractordatatype
        /// </summary>
        public string ExtractorDataType
        {
            get { return this.extractordatatype; }
            set { this.extractordatatype = value; }
        }

        /// <summary>
        /// The Extractor Type
        /// </summary>
        private string extractorType;

        /// <summary>
        /// gets or sets ExtractorType
        /// </summary>
        public string ExtractorType
        {
            get => this.extractorType;
            set
            {
                this.extractorType = value;
                this.RaisePropertyChanged(nameof(this.ExtractorType));
            }
        }

        /// <summary>
        /// The parameters
        /// </summary>
        private ObservableCollection<ExtractorParameterGroup> extractorParameterGroups;

        /// <summary>
        /// gets or sets Parameters
        /// </summary>
        public ObservableCollection<ExtractorParameterGroup> ExtractorParameterGroups
        {
            get => this.extractorParameterGroups;
            set
            {
                this.extractorParameterGroups = value;
                this.RaisePropertyChanged(nameof(this.ExtractorParameterGroups));
            }
        }
    }
}
