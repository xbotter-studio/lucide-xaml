using CommunityToolkit.Mvvm.Input;
using LucideIcons.MAUI.Sample.Models;

namespace LucideIcons.MAUI.Sample.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}