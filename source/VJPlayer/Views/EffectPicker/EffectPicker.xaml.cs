using System;
using System.Windows;
using VJPlayer.ViewModels;

namespace VJPlayer.Views
{
    /// <summary>
    /// Interaction logic for EffectPicker.xaml
    /// </summary>
    public partial class EffectPicker : Window, IEffectPickerView
    {
        public EffectPicker()
        {
            InitializeComponent();
        }

        public Action EffectChecked { get; set; }

        public void ShowWindow()
        {
            var viewModel = (IEffectsViewModel)DataContext;
            effectsListBox.ItemsSource = viewModel.Effects;
            Show();
        }

        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            EffectChecked.Invoke();
        }
    }
}
