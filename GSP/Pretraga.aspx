<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pretraga.aspx.cs" Inherits="GSP.Pretraga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12 card">
            <div class="row">
                <div class="col-md-6 card-head">
                    <span>Pretraga po opstinama</span>


                    <div class="row">
                        <div class="col-md-12">
                            <label for="select1">Od:</label>
                            <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Naziv" AutoPostBack="true" DataValueField="ID"></asp:DropDownList>

                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listOpstina" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                        <div class="col-md-12">
                            <label for="select2">Do:</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="Naziv" AutoPostBack="true" CssClass="form-control" DataValueField="ID"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 card-head">
                    <span>
                        <asp:CheckBox ID="check" runat="server" CssClass="check" OnCheckedChanged="check_CheckedChanged" AutoPostBack="true" />
                        Pretraga po stajalištima</span>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="check" />
                        </Triggers>
                        <ContentTemplate>
                    <div id="pretragaStajaliste" runat="server" class="row">
                        <div class="col-md-12">
                            <label for="select3">Od:</label>
                            <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="Naziv" DataValueField="ID"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listStajalisteByOpstina" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="OpstinaID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="col-md-12">
                            <label for="select4">Do:</label>
                            <asp:DropDownList ID="DropDownList4" CssClass="form-control" runat="server" DataSourceID="SqlDataSource3" DataTextField="Naziv" DataValueField="ID"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="listStajalisteByOpstina" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownList2" PropertyName="SelectedValue" Name="OpstinaID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 btn-search">
                    <asp:Button ID="btn" runat="server" Text="Pronađi" OnClick="btn_Click" CssClass="btn btn-primary pull-right" />
                </div>
            </div>
            <div id="rezultat" runat="server" class="row" Visible ="false">
                <hr>
                <div class="col-md-12 res-head">
                    Rezultat:
                </div>
                <div class="col-md-6 results">
                    <b>Autobus:</b> <span id="spnAutobus" runat="server"></span>
                    <br>
                    <b>Trolejbus:</b><span id="spnTrolejbus" runat="server"></span><br>
                    <b>Tramvaj:</b><span id="spnTramvaj" runat="server"></span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
