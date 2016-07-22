<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GSP.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlLinije" DataTextField="Naziv" DataValueField="Naziv"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="SqlLinije" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="Select ID, Naziv from Linija"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Value="A"></asp:ListItem>
        <asp:ListItem Value="B"></asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList3" runat="server">
        <asp:ListItem Value="radni">Radni dan</asp:ListItem>
        <asp:ListItem Value="subota">Subota</asp:ListItem>
        <asp:ListItem Value="nedelja">Nedelja</asp:ListItem>
    </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Refresh" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlRedVoznje" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
            <asp:BoundField DataField="Vreme" HeaderText="Vreme" SortExpression="Vreme"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlRedVoznje" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listRedVoznjeByLinijaAndSmerAndDan" SelectCommandType="StoredProcedure" UpdateCommand="updateRedVoznjeByLinija" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="Linija" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="DropDownList2" PropertyName="SelectedValue" Name="Smer" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="DropDownList3" PropertyName="SelectedValue" Name="Dan" Type="String"></asp:ControlParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Vreme" Type="String"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
