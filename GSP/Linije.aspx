<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Linije.aspx.cs" Inherits="GSP.Linije" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           <div class="divStyle" id="divStyle">
                 <%# DataBinder.Eval(Container.DataItem, "Naziv") %>
           
            
                <a href ="#"> <%# DataBinder.Eval(Container.DataItem, "OpisLinije") %></a>
            </div>
        </ItemTemplate>
       
    </asp:Repeater>
</asp:Content>
