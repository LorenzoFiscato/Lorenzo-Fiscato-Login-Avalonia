using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaLoginApplication.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _saluto = "Benvenuto. Scrivi il nome per effetuare il login";
    [ObservableProperty] private string _btnLog = "LOGIN";
    [ObservableProperty] private string? _txtNome;
    [ObservableProperty] private string _avviso = "";
    [ObservableProperty] private bool _isTxtEnabled = true;
    
    private string _nomeUtente = "";
    private bool _hasLogged;
    
    [RelayCommand]
    private void BtnLogClick()
    {
        Avviso = "";
        
        if(_hasLogged)
        {
            ChangeBools(false, true);
            ChangeText("Arrivederci. Scrivi il nome per effetuare il login", "LOGIN");
            return;
        }
        
        if (string.IsNullOrEmpty(TxtNome))
        {
            Avviso = "Inserisci un nome valido";
            return;
        }

        _nomeUtente = TxtNome;
        
        ChangeBools(true, false);
        ChangeText($"Benvenuto {_nomeUtente}", "LOGOUT");
        TxtNome = null;
    }

    private void ChangeText(string saluto, string btnLog)
    {
        Saluto = saluto;
        BtnLog =  btnLog;
    }

    private void ChangeBools(bool hasLogged, bool isTxtEnabled)
    {
        _hasLogged = hasLogged;
        IsTxtEnabled = isTxtEnabled;
    }
}