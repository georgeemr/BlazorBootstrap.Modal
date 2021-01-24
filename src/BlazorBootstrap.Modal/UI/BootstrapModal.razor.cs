﻿using BlazorBootstrap.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorBootstrap.Modal.UI
{
    public class BootstrapModalBase : ComponentBase, IDisposable
    {
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

        protected void ShowModal(string title, RenderFragment content)
        {
            Title = title;
            IsVisible = true;
            // Se puede cambiar esto a un JS
            Content = content;

            StateHasChanged();
        }

        protected void CloseModal()
        {
            Title = string.Empty;
            IsVisible = false;
            Content = null;
        }
    }
}
