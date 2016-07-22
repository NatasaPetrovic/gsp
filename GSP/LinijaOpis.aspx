<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinijaOpis.aspx.cs" Inherits="GSP.LinijaOpis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 card">
            <div class="row">
                <div id="DivNaziv" runat="server" class="col-md-12 card-head center">
                </div>
                <hr>
                <div class="col-md-6">
                    <label>Početno stajalište</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Naziv" DataValueField="Smer"></asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listTerminusByLinija" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="linija" Name="Linija" Type="String"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-md-6">
                    <label>Dan</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem Value="radni" Selected="True">Radni dan</asp:ListItem>
                        <asp:ListItem Value="subota">Subota</asp:ListItem>
                        <asp:ListItem Value="nedelja">Nedelja</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <hr>
                <div class="col-md-12 center headline margin">
                    Spisak polazaka
                </div>
                <div id="Polasci" class="row" runat="server">
                </div>
                <hr>
                <div class="col-md-12 col-sm-12 col-xs-12 headline center margin">
                    Spisak Stajališta
                </div>
                <div runat="server" id="Stajalista" class="row">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
