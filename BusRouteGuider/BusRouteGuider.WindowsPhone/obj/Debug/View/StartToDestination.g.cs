﻿

#pragma checksum "C:\Users\Nands\Documents\Visual Studio 2013\Projects\BusRouteGuider\BusRouteGuider\BusRouteGuider.WindowsPhone\View\StartToDestination.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D59E4BB25D08EA8F0146DEE3308AE9F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusRouteGuider
{
    partial class StartToDestination : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.Menu_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 23 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.Map_ItemClick;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 32 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target)).TextChanged += this.AutoSuggestBox_TextChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 44 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target)).TextChanged += this.AutoSuggestBox_TextChanged;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 55 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AllRoutesBtn_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 58 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.BestRoutesBtn_Click;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 61 "..\..\View\StartToDestination.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.cancelBtn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


