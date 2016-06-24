<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pretraga.aspx.cs" Inherits="GSP.Pretraga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            od
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Naziv" AutoPostBack ="true" DataValueField="ID"></asp:DropDownList>

            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listOpstina" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            do
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="Naziv" AutoPostBack ="true" DataValueField="ID"></asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Detaljnije" OnClick="Button1_Click" />
            <br/> 
            <asp:DropDownList ID="DropDownList3" runat="server" Visible="false" DataSourceID="SqlDataSource2" DataTextField="Naziv" DataValueField="ID"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listStajalisteByOpstina" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="OpstinaID" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DropDownList ID="DropDownList4" runat="server" Visible="false" DataSourceID="SqlDataSource3" DataTextField="Naziv" DataValueField="ID"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listStajalisteByOpstina" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" PropertyName="SelectedValue" Name="OpstinaID" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="btn" runat="server" Text="Pronađi" OnClick="btn_Click" />
            <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           <div class="divStyle" id="divStyle">
                 <%# DataBinder.Eval(Container.DataItem, "Naziv") %>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    
           
        </ContentTemplate> 
    </asp:UpdatePanel>
</asp:Content>
