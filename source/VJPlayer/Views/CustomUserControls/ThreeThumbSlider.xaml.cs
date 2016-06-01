using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VJPlayer.Views.CustomUserControls
{
    /// <summary>
    /// Interaction logic for ThreeThumbSlider.xaml
    /// </summary>
    public partial class ThreeThumbSlider : UserControl
    {
        public event EventHandler LowerValueChanged;
        public event EventHandler MiddleValueChanged;
        public event EventHandler UpperValueChanged;

        public event EventHandler UpperSliderDragStarted;
        public event EventHandler UpperSliderDragCompleted;

        public event EventHandler MiddleSliderDragStarted;
        public event EventHandler MiddleSliderDragCompleted;

        public event EventHandler LowerSliderDragStarted;
        public event EventHandler LowerSliderDragCompleted;

        public ThreeThumbSlider()
        {
            InitializeComponent();
            Loaded += Slider_Loaded;

        }

        void Slider_Loaded(object sender, RoutedEventArgs e)
        {
            LowerSlider.ValueChanged += LowerSlider_ValueChanged;
            UpperSlider.ValueChanged += UpperSlider_ValueChanged;
            MiddleSlider.ValueChanged += MiddleSlider_ValueChanged;
        }

        public void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MiddleSlider.Value = Math.Max(MiddleSlider.Value, LowerSlider.Value);

            if (LowerSlider.Value > UpperSlider.Value)
                LowerSlider.Value = UpperSlider.Value;
        }

        public void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MiddleSlider.Value = Math.Min(MiddleSlider.Value, UpperSlider.Value);

            if (UpperSlider.Value < LowerSlider.Value)
                LowerSlider.Value = UpperSlider.Value;
        }

        public void MiddleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MiddleValueChanged(this, e);
        }

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(ThreeThumbSlider), new UIPropertyMetadata(0d));

        public double LowerValue
        {
            get { return (double)GetValue(LowerValueProperty); }
            set { SetValue(LowerValueProperty, value); }
        }

        public static readonly DependencyProperty LowerValueProperty =
            DependencyProperty.Register("LowerValue", typeof(double), typeof(ThreeThumbSlider), new UIPropertyMetadata(0d));

        public double UpperValue
        {
            get { return (double)GetValue(UpperValueProperty); }
            set { SetValue(UpperValueProperty, value); }
        }

        public static readonly DependencyProperty UpperValueProperty =
            DependencyProperty.Register("UpperValue", typeof(double), typeof(ThreeThumbSlider), new UIPropertyMetadata(0d));

        public double MiddleValue
        {
            get { return (double)GetValue(MiddleValueProperty); }
            set { SetValue(MiddleValueProperty, value); }
        }

        public static readonly DependencyProperty MiddleValueProperty =
            DependencyProperty.Register("MiddleValue", typeof(double), typeof(ThreeThumbSlider), new UIPropertyMetadata(0d));

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(ThreeThumbSlider), new UIPropertyMetadata(1d));


        public void MiddleSliderDragStartedEvent(object sender, RoutedEventArgs e)
        {
            MiddleSliderDragStarted?.Invoke(this, e);
        }

        public void MiddleSliderDragCompletedEvent(object sender, RoutedEventArgs e)
        {
            MiddleSliderDragCompleted?.Invoke(this, e);
        }

        public void UpperSliderDragStartedEvent(object sender, RoutedEventArgs e)
        {
            UpperSliderDragStarted?.Invoke(this, e);
        }

        public void UpperSliderDragCompletedEvent(object sender, RoutedEventArgs e)
        {
            UpperSliderDragCompleted?.Invoke(this, e);
        }

        public void LowerSliderDragStartedEvent(object sender, RoutedEventArgs e)
        {
            LowerSliderDragStarted?.Invoke(this, e);
        }

        public void LowerSliderDragCompletedEvent(object sender, RoutedEventArgs e)
        {
            LowerSliderDragCompleted?.Invoke(this, e);
        }


    }
}
