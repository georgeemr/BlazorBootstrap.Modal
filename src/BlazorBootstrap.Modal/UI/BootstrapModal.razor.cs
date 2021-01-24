using BlazorBootstrap.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorBootstrap.Modal.UI
{
    public class BootstrapModalBase : ComponentBase, IDisposable
    {
        [Inject] Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        [Inject] public IModal ModalService { get; set; }

        public string Title { get; set; }

        public bool IsVisible { get; set; }

        public RenderFragment Content { get; set; }

        public void Dispose()
        {
            ModalService.OnShow -= ShowModal;
            ModalService.OnClose -= CloseModal;
        }

        protected override void OnInitialized()
        {
            ModalService.OnShow += ShowModal;
            ModalService.OnClose += CloseModal;

            StateHasChanged();
        }

        protected async void ShowModal(string title, RenderFragment content)
        {
            Title = title;
            IsVisible = true;
            Content = content;
            await JSRuntime.InvokeVoidAsync("ShowTheModal", this.ModalService.Id);
            StateHasChanged();
        }

        protected async void CloseModal()
        {
            await JSRuntime.InvokeVoidAsync("HideTheModal", this.ModalService.Id);
            Title = string.Empty;
            IsVisible = false;
            Content = null;
        }
    }
}
