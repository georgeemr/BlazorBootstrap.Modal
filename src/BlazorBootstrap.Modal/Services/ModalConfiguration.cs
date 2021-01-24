using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBootstrap.Modal.Services
{
    public class ModalConfiguration
    {
        public bool ShowHeader { get; set; }
        public bool ShowFooter { get; set; }
        public string Size { get; set; }
        public bool VerticallyCentered { get; set; }
        public bool StaticBackdrop { get; set; } // data-backdrop="static" data-keyboard="false"
        public bool Keyboard { get; set; }
        public bool FadeAnimation { get; set; }
        public bool ScrollableBodyContent { get; set; } // .modal-dialog-scrollable

        // @(IsVisible ? "d-block show": "d-none")

        public ModalConfiguration()
        {
            this.ShowHeader = true;
            this.ShowFooter = true;
            this.VerticallyCentered = false;
            this.Size = ModalSize.Default;
            this.StaticBackdrop = false;
            this.ScrollableBodyContent = false;
            this.FadeAnimation = true;
        }
    }

    public struct ModalSize
    {
        public const string Default = "";
        public const string Small = "modal-sm";
        public const string Large = "modal-lg";
        public const string FullScreen = "modal-full";
    }
}
