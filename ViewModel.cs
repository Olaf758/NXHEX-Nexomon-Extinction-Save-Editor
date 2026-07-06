using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace NEXHEX
{
    public partial class ViewModel : ObservableObject
    {
        public readonly TopLevel _topLevel;
        public readonly MainWindow _window;
        [ObservableProperty]
        private SaveFileManager _saveFileManagerUnit;
        [ObservableProperty]
        private Object currentViewModel;
        public ViewModel(MainWindow window)
        {
            _window = window;
            _topLevel = _window;
            CurrentViewModel = new Nex2ViewModel();
            SaveFileManagerUnit = new SaveFileManager(this);
        }
    }

}
