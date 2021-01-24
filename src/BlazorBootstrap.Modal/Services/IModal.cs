using Microsoft.AspNetCore.Components;
using System;

namespace BlazorBootstrap.Modal.Services
{
    public interface IModal
    {
        string Id { get; set; }
        ModalConfiguration Configuration { get; set; }

        event Action<string, RenderFragment> OnShow;

        event Action OnClose;

        void Show<T>(string title, ModalConfiguration configuration, params ModalParameter[] parameters)
            where T : ComponentBase;

        void Close();
    }
}
