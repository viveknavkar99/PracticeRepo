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
    /// Class Task Item
    /// </summary>
    public class TaskItem : INotifyPropertyChanged
    {

        /// <summary>
        /// The isSelectedRowId
        /// </summary>
        private bool isSelectedRowId;

        /// <summary>
        /// get or set IsSelectedRowId
        /// </summary>
        public bool IsSelectedRowId
        {
            get => this.isSelectedRowId;
            set
            {
                this.isSelectedRowId = value;
                this.RaisePropertyChanged(nameof(this.IsSelectedRowId));
            }
        }

        /// <summary>
        /// The ID
        /// </summary>
        private string id;

        /// <summary>
        /// gets or sets Id
        /// </summary>
        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
                this.RaisePropertyChanged(nameof(this.Id));
            }
        }

        /// <summary>
        /// The extractors
        /// </summary>
        private ObservableCollection<Extractor> extractors;

        /// <summary>
        /// gets or sets extractors
        /// </summary>
        public ObservableCollection<Extractor> Extractors
        {
            get => this.extractors;
            set
            {
                this.extractors = value;
                this.RaisePropertyChanged(nameof(this.Extractors));
            }
        }

        /// <summary>
        /// the selected extractor
        /// </summary>
        private Extractor selectedExtractor;

        /// <summary>
        /// gets or sets SelectedExtractor
        /// </summary>
        public Extractor SelectedExtractor
        {
            get => this.selectedExtractor;
            set
            {
                this.selectedExtractor = value;
                if (this.selectedExtractor != null)
                {
                    ControlsStackPanel = GetControlsStackPanel();
                }
                this.RaisePropertyChanged(nameof(this.SelectedExtractor));
            }
        }

        private StackPanel controlsStackPanel;
        public StackPanel ControlsStackPanel
        {
            get
            {
                return controlsStackPanel;
            }
            set
            {
                controlsStackPanel = value;
                RaisePropertyChanged(nameof(ControlsStackPanel));
            }
        }

        private StackPanel GetControlsStackPanel()
        {
            controlsStackPanel = new StackPanel();
            if (selectedExtractor != null)
            {
                controlsStackPanel.Orientation = Orientation.Horizontal;
                foreach (var group in selectedExtractor.ExtractorParameterGroups)
                {
                    controlsStackPanel.Children.Add(group.ExtractorParameterGroupStackPanel);
                }
            }
            return controlsStackPanel;
        }

        /// <summary>
        /// Property Changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise Property Changed
        /// </summary>
        /// <param name="propertyName">selected Property</param>
        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
