//------------------------------------------------------------------------------
// <copyright file="StateGuidanceToolwindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Windows;

namespace StateGuidance
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("9d4efa20-c12f-42a9-8415-1c6bff22a7e7")]
    public class StateGuidanceToolwindow : ToolWindowPane
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateGuidanceToolwindow"/> class.
        /// </summary>
        public StateGuidanceToolwindow() : base(null)
        {
            this.Caption = "StateGuidanceToolwindow";
            _serviceProvider = StateGuidanceToolwindowCommand.Instance.ServiceProvider;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new StateGuidanceToolwindowControl(_serviceProvider);
        }


        public void AnalyseItem()
        {
            MessageBox.Show("angekommen");
        }
    }
}
