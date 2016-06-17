<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinijaOpis.aspx.cs" Inherits="GSP.LinijaOpis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Stajališta"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Smer:"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true">
        <asp:ListItem Selected="True">A</asp:ListItem>
        <asp:ListItem>B</asp:ListItem>
    </asp:RadioButtonList>
    
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           <div class="divStyle" id="divStyle">
                 <%# DataBinder.Eval(Container.DataItem, "Naziv") %>
            </div>
        </ItemTemplate>
       
    </asp:Repeater>
             <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="true">
        <asp:ListItem Selected="True">Radni dan</asp:ListItem>
        <asp:ListItem>Subota</asp:ListItem>
        <asp:ListItem>Nedelja</asp:ListItem>
    </asp:RadioButtonList>
                  
                      <asp:Panel ID="container" runat="server"></asp:Panel>
                     </div>
           <%-- <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
           <div class="divStyle" id="divStyle">
                 <%# DataBinder.Eval(Container.DataItem, "Vreme") %>
            </div>
        </ItemTemplate>
       
    </asp:Repeater>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>
