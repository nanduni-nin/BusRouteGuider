﻿

#pragma checksum "C:\Users\Nands\Documents\Visual Studio 2013\Projects\BusRouteGuider\BusRouteGuider\BusRouteGuider.Windows\View\AllRoutes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2B16726040A348D7004CBACEB7F84874"
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
    partial class AllRoutes : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 11 "..\..\View\AllRoutes.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.Menu_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 17 "..\..\View\AllRoutes.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.TxtBlckHelp_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 18 "..\..\View\AllRoutes.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.TxtBlckMap_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 21 "..\..\View\AllRoutes.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


