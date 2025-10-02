using System.Collections.ObjectModel;
using TarefasApp.Pages;
using TarefasApp.Models;
using TarefasApp.Repository;
using System.Threading.Tasks;
using Microsoft.Maui.Controls; 

namespace TarefasApp;

public partial class MainPage : ContentPage
{
    private readonly TaskRepository taskRepository;

    public MainPage()
    {
        InitializeComponent();
        taskRepository = new TaskRepository();
    }

    // 1. LÓGICA DE CARREGAMENTO E MENSAGEM DE LISTA VAZIA
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTasks();
    }

    private void LoadTasks()
    {
        
        var tasks = taskRepository.List();

        listTasks.ItemsSource = new ObservableCollection<TaskModel>(tasks);

        // Lógica da mensagem de lista vazia (controla lblNoTasks e listTasks.IsVisible)
        if (tasks == null || tasks.Count == 0)
        {
            listTasks.IsVisible = false;
            lblNoTasks.IsVisible = true;
        }
        else
        {
            listTasks.IsVisible = true;
            lblNoTasks.IsVisible = false;
        }
    }

    // 2. NAVEGAÇÃO PARA ADICIONAR TAREFA (Encapsulada em NavigationPage)
    private async void OnAddTask(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new AddPage()));
    }

    
    private async void OnViewDetailsClicked(object sender, EventArgs e)
    {
        
        if (((Button)sender).CommandParameter is TaskModel task)
        {
            await Navigation.PushAsync(new Pages.DetailsPage(task));
        }
    }
    
}