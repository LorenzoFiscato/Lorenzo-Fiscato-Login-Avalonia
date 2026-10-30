using System.Collections.ObjectModel;
using AvaloniaLoginApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaLoginApplication.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _saluto = "Benvenuto. Seleziona un utente dalla lista per effetuare il login";
    [ObservableProperty] private string _btnLog = "LOGIN";
    [ObservableProperty] private string? _txtPassword;
    [ObservableProperty] private string _avviso = "";
    [ObservableProperty] private bool _isTxtEnabled;
    [ObservableProperty] private bool _isBtnEnabled;
    [ObservableProperty] private Utente? _selectedUtente;
    
    

    public ObservableCollection<Utente> Utenti { get; set; } = new ObservableCollection<Utente>
    {
        new Utente { Nome = "Mario", Password = "Password123" },
        new Utente { Nome = "Luigi", Password = "Segreta45" },
        new Utente { Nome = "Anna", Password = "MiaPassword!" }
    };
    
    private bool _hasLogged;


    partial void OnSelectedUtenteChanged(Utente? value)
    {
        if (value != null) AggiornaUi((Utente)value);
    }

    [RelayCommand]
    private void BtnLogClick()
    {
        Avviso = "";
        
        if (_hasLogged)
        {
            AggiornaForm($"Arrivederci {SelectedUtente?.Nome}. Logout effettuato con successo", false, "", true, "LOGIN");
            return;
        }

        if(TxtPassword != SelectedUtente?.Password)
        {
            Avviso = "Password errata. Riprova";
            return;
        }

        if (TxtPassword == null)
        {
            Avviso = "Inserisci la password";
            return;
        }
        
        AggiornaForm($"Benvenuto {SelectedUtente?.Nome}. Login effettuato con successo", true, "", false, "LOGOUT");

        
        
        
        
    }
    
    private void AggiornaUi(Utente utente)
    {
        SelectedUtente = utente;
        Saluto = $"Benvenuto {utente.Nome}. Inserisci la password per effettuare il login";
        IsTxtEnabled = true;
        IsBtnEnabled = true;
        BtnLog = "LOGIN";

    }

    private void AggiornaForm(string saluto, bool hasLogged, string txtPassword, bool isTxtEnabled, string btnLog, string avviso = "")
    {
        Saluto = saluto;
        _hasLogged = hasLogged;
        TxtPassword = txtPassword;
        IsTxtEnabled = isTxtEnabled;
        BtnLog = btnLog;
        Avviso = avviso;
    }
}