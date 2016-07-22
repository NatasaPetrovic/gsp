<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Linije.aspx.cs" Inherits="GSP.Linije" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12 card">
            <div class="row">
                <div class="col-md-12 card-head">
                    <span>Pretraga linija</span>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" class="form-control">
                        <asp:ListItem>Izaberi...</asp:ListItem>
                        <asp:ListItem>Autobus</asp:ListItem>
                        <asp:ListItem>Tramvaj</asp:ListItem>
                        <asp:ListItem>Trolejbus</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" class="form-control">
                        <asp:ListItem>Dnevne linije</asp:ListItem>
                        <asp:ListItem>Nocne</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 pull-right filter-mar">
                    <div class="input-group">
                        <asp:TextBox ID="TxtFilter" runat="server" class="form-control" placeholder="Filtriraj linije..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Button1" runat="server" Text="Filtriraj" class="btn btn-default" OnClick="Button1_Click"/>
                        </span>
                    </div>
                </div>
            </div>
            <hr>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList1"/>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList2" />
                    <asp:AsyncPostBackTrigger ControlID="Button1" />
                </Triggers>
                <ContentTemplate>

                    <div id="result" runat="server" class="row list" Visible="false">
                        Rezultat pretrage
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>







</asp:Content>
