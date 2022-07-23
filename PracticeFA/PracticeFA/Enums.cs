using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFA
{
    /// <summary>
    /// Hash Value
    /// </summary>
    public enum HashValue
    {
        /// <summary>
        /// The String
        /// </summary>
        True = 0,

        /// <summary>
        /// zthe Long
        /// </summary>
        False = 1,
    }

    /// <summary>
    /// The Template
    /// </summary>
    public enum Template
    {
        /// <summary>
        /// The TextBox
        /// </summary>
        TextBox = 0,

        /// <summary>
        /// The ComboBox
        /// </summary>
        ComboBox = 1,

        /// <summary>
        /// The MultilineTextBox
        /// </summary>
        MultilineTextBox = 2,

        /// <summary>
        /// The CheckBox
        /// </summary>
        CheckBox = 3,

        /// <summary>
        /// The MultiSelectComboBox
        /// </summary>
        MultiSelectComboBox = 4,
    }
}
