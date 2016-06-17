<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Linije.aspx.cs" Inherits="GSP.Linije" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true">
        <asp:ListItem>autobus</asp:ListItem>
        <asp:ListItem>tramvaj</asp:ListItem>
        <asp:ListItem>trolejbus</asp:ListItem>
    </asp:DropDownList>

    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true">
        <asp:ListItem>Dnevna</asp:ListItem>
        <asp:ListItem>Noćna</asp:ListItem>
    </asp:RadioButtonList>
    
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
           <div class="divStyle" id="divStyle">
               <asp:Label ID="Label1" runat="server" Text= <%# DataBinder.Eval(Container.DataItem, "Naziv") %>>
                 <%# DataBinder.Eval(Container.DataItem, "Naziv") %></asp:Label>
           
               <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Click" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "Naziv") %>><%# DataBinder.Eval(Container.DataItem, "OpisLinije") %></asp:LinkButton>
                
            </div>
        </ItemTemplate>
       
    </asp:Repeater>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
