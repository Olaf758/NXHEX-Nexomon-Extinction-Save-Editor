using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nexomon1Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace NEXHEX
{
    public partial class Nex1ViewModel : ObservableObject
    {
        private bool unitbool = true;
        [ObservableProperty]
        private string _actualNexomonName;
        [ObservableProperty]
        private Slot<Unit> _actualNexomon;
        [ObservableProperty]
        private SaveData _actualSave;
        [ObservableProperty]
        private Nex1SlotManager _nex1SlotManagerUnit;
        partial void OnActualNexomonChanged(Slot<Unit>? oldValue, Slot<Unit> newValue)
        {
            if (unitbool)
            {
                unitbool = false;
                if (newValue.Content != null)
                    ActualNexomonName = NexomonNames[NexomonNames.IndexOf(newValue.Content.name)];
                unitbool = true;
            }
        }
        partial void OnActualNexomonNameChanged(string? oldValue, string newValue)
        {
            if (unitbool)
            {
                unitbool = false;
                ActualNexomon = new Slot<Unit>(new Unit(newValue, 1));
                unitbool = true;
            }
        }
        public Nex1ViewModel(string path)
        {
            NexomonNames = Consts.MonstersNames;
            foreach (string name in NexomonNames)
            {
                Debug.WriteLine(name);
            }
            Skills = Consts.Skills;
            ActualSave = new SaveData(path);
            foreach (Slot<Unit> unit in ActualSave.playerParty.Units)
            {
                Debug.WriteLine(unit.Content.name);
            }
            ActualNexomonName = NexomonNames[0];
            ActualNexomon = new Slot<Unit>(new Unit(ActualNexomonName, 1));
            Nex1SlotManagerUnit = new Nex1SlotManager(this);
        }
        [RelayCommand]
        public void AddToStorage()
        {
            ActualSave.playerHatchery.Monsters.Add(new Slot<Unit>(ActualNexomon.Content));
        }
        [RelayCommand]
        public void GetThemAll()
        {
            ActualSave.playerHatchery.GetAll(ActualSave);
        }
    }
    public partial class Nex1ViewModel : ObservableObject
    {
        public ObservableCollection<string> NexomonNames { get; set; }
        public ObservableCollection<Skill> Skills {  get; set; }
    }
}
