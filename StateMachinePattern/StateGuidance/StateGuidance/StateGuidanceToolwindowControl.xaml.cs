//------------------------------------------------------------------------------
// <copyright file="StateGuidanceToolwindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using EnvDTE;

namespace StateGuidance
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for StateGuidanceToolwindowControl.
    /// </summary>
    public partial class StateGuidanceToolwindowControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateGuidanceToolwindowControl"/> class.
        /// </summary>
        public StateGuidanceToolwindowControl(IServiceProvider serviceProvider)
        {
            this.InitializeComponent();

            _serviceProvider = serviceProvider;

            DTE dte = _serviceProvider.GetService(typeof(DTE)) as DTE;

            if (dte != null)
            {
                dte.Events.DocumentEvents.DocumentOpened += OnDocumentOpened;
            }
        }

        private void OnDocumentOpened(Document document)
        {
            button1.Content = document.Name;

        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "StateGuidanceToolwindow");
        }
    }
}