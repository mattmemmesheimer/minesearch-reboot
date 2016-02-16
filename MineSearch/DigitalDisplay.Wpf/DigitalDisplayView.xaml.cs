using System;
using System.Collections.ObjectModel;
using System.Windows;
using DigitalDisplay.Wpf.ViewModels;

namespace DigitalDisplay.Wpf
{
    /// <summary>
    /// Interaction logic for DigitalDisplayView.xaml
    /// </summary>
    public partial class DigitalDisplayView
    {
        #region Constants

        /// <summary>
        /// Defafult number of digits.
        /// </summary>
        private const uint DefaultDigits = 1;

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Value dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof (int), typeof (DigitalDisplayView),
                new PropertyMetadata(OnValueChanged));

        #endregion

        #region Properties

        /// <summary>
        /// Value to display.
        /// </summary>
        public int Value
        {
            get { return (int) GetValue(ValueProperty); }
            set
            {
                // Clamp the value
                value = Math.Max(_minValue, Math.Min(value, _maxValue));

                SetValue(ValueProperty, value);

                // Negative
                if (value < 0)
                {
                    // Create the string with the appropriate leading zeros
                    var valueString = value.ToString(string.Format("D{0}", _digits - 1));
                    DigitViewModels[0].MinusSign = true;
                    // Skip over the minus sign
                    for (int i = 1; i < Digits; i++)
                    {
                        var digit = uint.Parse(valueString.Substring(i, 1));
                        // Always reset the minus sign flag if setting an actual value
                        DigitViewModels[i].MinusSign = false;
                        DigitViewModels[i].Value = digit;
                    }
                }
                // Positive
                else
                {
                    // Create the string with the appropriate leading zeros
                    var valueString = value.ToString(string.Format("D{0}", _digits));
                    for (int i = 0; i < Digits; i++)
                    {
                        var digit = uint.Parse(valueString.Substring(i, 1));
                        // Always reset the minus sign flag if setting an actual value
                        DigitViewModels[i].MinusSign = false;
                        DigitViewModels[i].Value = digit;
                    }
                }
            }
        }

        /// <summary>
        /// Number of digits.
        /// </summary>
        public uint Digits
        {
            get { return _digits; }
            set
            {
                if (_digits != value)
                {
                    if (value == 0)
                    {
                        throw new ArgumentOutOfRangeException("value", value,
                            @"Display must have at least one digit.");
                    }

                    _digits = value;
                    // Calculate the min value we can have (one less digit due to the minus sign).
                    _minValue = - (((int)Math.Pow(10, _digits - 1)) - 1);
                    // Calculate the max value we can have.
                    _maxValue = ((int)Math.Pow(10, _digits)) - 1;
                    // Create a view model for each digit.
                    DigitViewModels.Clear();
                    for (int i = 0; i < _digits; i++)
                    {
                        DigitViewModels.Add(new DigitViewModel());
                    }
                }
            }
        }

        /// <summary>
        /// Digit view models.
        /// </summary>
        public ObservableCollection<DigitViewModel> DigitViewModels { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalDisplayView"/> class.
        /// </summary>
        public DigitalDisplayView()
        {
            DigitViewModels = new ObservableCollection<DigitViewModel>();
            Digits = DefaultDigits;
            InitializeComponent();
        }

        private static void OnValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as DigitalDisplayView;
            if (control == null)
            {
                return;
            }
            control.Value = (int) e.NewValue;
        }

        #region Fields

        private uint _digits;
        private int _minValue;
        private int _maxValue;

        #endregion
    }
}
