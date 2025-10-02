using TarefasApp.Models;
using TarefasApp.Repository;

namespace TarefasApp.Pages;

public partial class AddPage : ContentPage
{
    private readonly TaskRepository taskRepository;
    public AddPage()
    {
        InitializeComponent();

        taskRepository = new TaskRepository();
    }

    private async void onAdd(object sender, EventArgs e)
    {
        var task = currentTask();

        if (task != null)
        {
            taskRepository.Add(task);
            await Navigation.PopModalAsync();
        }
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

    private TaskModel currentTask()
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text) ||
            string.IsNullOrWhiteSpace(txtPriority.Text))
        {
            DisplayAlert("", "Preencha todos os campos!", "Ok");
            return null;
        }

        if (!short.TryParse(txtPriority.Text, out short priority))
        {
            DisplayAlert("", "O campo prioridade deve ser numérico!", "Ok");
            return null;
        }

        return new TaskModel(
            Guid.NewGuid(),
            txtTitle.Text,
            txtDescription.Text,
            txtCreated.Date,
            priority
        );
    }
}