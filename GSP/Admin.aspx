<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GSP.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Administracija polazaka pocetak -->
     <!-- Kontrole polazaka pocetak -->
    <asp:DropDownList ID="DdlLinije" runat="server" DataSourceID="SqlLinije" DataTextField="Naziv" DataValueField="Naziv" CssClass="form-control col-md-5"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="SqlLinije" ConnectionString='<%$ ConnectionStrings:GSPConnection %>' SelectCommand="Select ID, Naziv from Linija"></asp:SqlDataSource>
    <asp:DropDownList ID="DdlSmer" runat="server" CssClass="form-control col-md-5">
        <asp:ListItem Value="A"></asp:ListItem>
        <asp:ListItem Value="B"></asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DdlDan" runat="server" CssClass="form-control col-md-5">
        <asp:ListItem Value="radni">Radni dan</asp:ListItem>
        <asp:ListItem Value="subota">Subota</asp:ListItem>
        <asp:ListItem Value="nedelja">Nedelja</asp:ListItem>
    </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Refresh" OnClick="Button1_Click" CssClass="btn btn-default" />
    <asp:HiddenField ID="LinijaStajaliste" Visible="false" runat="server" />
    <!-- Kontrole polazaka kraj -->
    <!-- GridView pocetak -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" />
        </Triggers>
        <ContentTemplate>
    <asp:GridView ID="GvRedVoznje" ShowFooter="false" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ID") %>' ID="lblID"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vreme" SortExpression="Vreme">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Vreme") %>' ID="TextBox1"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Vreme") %>' ID="Label1"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Vreme") %>' ID="txtVreme"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LinijaStajalisteID" HeaderText="LinijaStajalisteID" SortExpression="LinijaStajalisteID"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" ID="btnEdit" CssClass="btn btn-default"></asp:Button>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="false" ID="btnUpdate" CssClass="btn btn-default"></asp:Button>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button runat="server" Text="Insert" CommandName="Insert" ID="btnInsert" CssClass="btn btn-default"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" ID="btnDelete" CssClass="btn btn-default"></asp:Button>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" ID="btnCancel" CssClass="btn btn-default"></asp:Button>
                </EditItemTemplate>
                <FooterTemplate>
                     <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" ID="btnCancelInsert" CssClass="btn btn-default"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    <asp:Button ID="BtnShowFooterRedVoznje" runat="server" Text=" + " CssClass="btn btn-default" OnClick="BtnShowFooterRedVoznje_Click" />
    <asp:Label ID="LblRedVoznje" runat="server" Text=""></asp:Label>
    <!-- GridView kraj -->
    <!-- Administracija polazaka kraj -->

    <!-- Administracija linija pocetak -->
    <!-- Kontrole linija pocetak -->
    <asp:DropDownList ID="DdlVrstaVozila" runat="server" CssClass="form-control">
        <asp:ListItem Value="autobus">Autobus</asp:ListItem>
        <asp:ListItem Value="tramvaj">Tramvaj</asp:ListItem>
        <asp:ListItem Value="trolejbus">Trolejbus</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DdlDnevna" runat="server" CssClass="form-control">
        <asp:ListItem>Dnevna</asp:ListItem>
        <asp:ListItem>Noćna</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnLinije" runat="server" Text="Traži" OnClick="BtnLinije_Click" CssClass="btn btn-default" />
    <!-- Kontrole linija kraj -->
    <!-- GridView pocetak -->
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnLinije" />
        </Triggers>
        <ContentTemplate>
    <asp:GridView ID="GvLinije" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GvLinije_PageIndexChanging" OnRowCancelingEdit="GvLinije_RowCancelingEdit" OnRowCommand="GvLinije_RowCommand" OnRowDeleting="GvLinije_RowDeleting" OnRowEditing="GvLinije_RowEditing" OnRowUpdating="GvLinije_RowUpdating" AllowPaging="False" OnDataBound="GvLinije_DataBound" OnSelectedIndexChanged="GvLinije_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField CommandName="Select" Text="&gt;"></asp:ButtonField>
            <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ID") %>' ID="LblID"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Naziv" SortExpression="Naziv">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Naziv") %>' ID="TxtNazivEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Naziv") %>' ID="LblNaziv"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Naziv") %>' ID="TxtNaziv"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Opis linije" SortExpression="Opis linije">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("OpisLinije") %>' ID="TxtOpisLinijeEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("OpisLinije") %>' ID="LblOpisLinije"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("OpisLinije") %>' ID="TxtOpisLinije"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vrsta vozila" SortExpression="Vrsta vozila">
                <EditItemTemplate>
                    <asp:DropDownList ID="DdlVrstaVozilaEdit" SelectedValue='<%# Bind("VrstaVozila") %>' runat="server" CssClass="form-control">
                        <asp:ListItem Value="autobus">Autobus</asp:ListItem>
                        <asp:ListItem Value="tramvaj">Tramvaj</asp:ListItem>
                        <asp:ListItem Value="trolejbus">Trolejbus</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DdlVrstaVozilaInsert" runat="server" CssClass="form-control">
                        <asp:ListItem Value="autobus">Autobus</asp:ListItem>
                        <asp:ListItem Value="tramvaj">Tramvaj</asp:ListItem>
                        <asp:ListItem Value="trolejbus">Trolejbus</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vrsta linije" SortExpression="Vrsta linije">
                <EditItemTemplate>
                    <asp:DropDownList ID="DdlVrstaLinijeEdit" SelectedValue='<%# Bind("VrstaLinije") %>' runat="server" CssClass="form-control">
                        <asp:ListItem Value="redovna">Redovna</asp:ListItem>
                        <asp:ListItem Value="privremena">Privremena</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("VrstaLinije") %>' ID="LblVrstaLinije"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DdlVrstaLinijeInsert" runat="server" CssClass="form-control">
                        <asp:ListItem Value="redovna">Redovna</asp:ListItem>
                        <asp:ListItem Value="privremena">Privremena</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vreme poluobrta" SortExpression="Vreme poluobrta">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("VremePoluobrta") %>' ID="TxtVremePoluobrtaEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("VremePoluobrta") %>' ID="LblVremePoluobrta"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("VremePoluobrta") %>' ID="TxtVremePoluobrta"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dnevna" SortExpression="Dnevna">
                <EditItemTemplate>
                    <asp:DropDownList ID="DdlDnevnaEdit"  runat="server" SelectedValue='<%# Bind("Dnevna") %>' CssClass="form-control">
                        <asp:ListItem Value="True">Dnevna</asp:ListItem>
                        <asp:ListItem Value="False">Noćna</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                   
                    <asp:DropDownList ID="DdlDnevnaInsert" runat="server" CssClass="form-control">
                        <asp:ListItem Value="True">Dnevna</asp:ListItem>
                        <asp:ListItem Value="False">Noćna</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                <EditItemTemplate>
                    <asp:DropDownList ID="DdlStatusEdit" SelectedValue='<%# Bind("Status") %>' runat="server" CssClass="form-control">
                        <asp:ListItem Value="True">Saobraća</asp:ListItem>
                        <asp:ListItem Value="False">Ne saobraća</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Status") %>' ID="LblStatus"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DdlStatusInsert" runat="server">
                        <asp:ListItem Value="True">Saobraća</asp:ListItem>
                        <asp:ListItem Value="False">Ne saobraća</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" ID="btnEdit" CssClass="btn btn-default"></asp:Button>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="false" ID="btnUpdate" CssClass="btn btn-default"></asp:Button>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button runat="server" Text="Insert" CommandName="Insert" ID="btnInsert" CssClass="btn btn-default"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" CssClass="btn btn-default" ID="btnDelete"></asp:Button>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" CssClass="btn btn-default" ID="btnCancel"></asp:Button>
                </EditItemTemplate>
                <FooterTemplate>
                     <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" ID="btnCancelInsert" CssClass="btn btn-default"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    <asp:Button ID="BtnShowFooterLinije" runat="server" Text=" + " OnClick="BtnShowFooterLinije_Click" CssClass="btn btn-default" />
    <!-- GridView kraj -->
    <!-- Administracija linija kraj -->

    <!-- Administracija stajalista pocetak -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GvLinije" />
        </Triggers>
        <ContentTemplate>
    <asp:GridView ID="GvStajalista" AllowPaging="true" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnPageIndexChanging="GvStajalista_PageIndexChanging" OnRowCancelingEdit="GvStajalista_RowCancelingEdit" OnRowCommand="GvStajalista_RowCommand" OnRowDeleting="GvStajalista_RowDeleting" OnRowEditing="GvStajalista_RowEditing" OnRowUpdating="GvStajalista_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("ID") %>' ID="LblID"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Naziv" SortExpression="Naziv">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Naziv") %>' ID="TxtNazivEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Naziv") %>' ID="LblNaziv"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Naziv") %>' ID="TxtNazivInsert"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Ulica" SortExpression="Ulica">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Ulica") %>' ID="TxtUlicaEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Ulica") %>' ID="LblUlica"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("Ulica") %>' ID="TxtUlicaInsert"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Naselje" SortExpression="Naselje">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Naselje") %>' ID="LblNaselje"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox runat="server" Text='<%# Bind("Naselje") %>' ID="TxtNaseljeEdit"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Naselje") %>' ID="TxtNaseljeInsert"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Opština" SortExpression="Opština">
                <EditItemTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("Opstina") %>' ID="TxtOpstinaEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Opstina") %>' ID="LblOpstina"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("Opstina") %>' ID="TxtOpstinaInsert"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zona" SortExpression="Zona">
                <EditItemTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("Zona") %>' ID="TxtZonaEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Zona") %>' ID="LblZona"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("Zona") %>' ID="TxtZonaInsert"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Redni broj" SortExpression="Redni broj">
                <EditItemTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("RedniBroj") %>' ID="TxtRedniBrojEdit"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("RedniBroj") %>' ID="LblRedniBroj"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                   <asp:TextBox runat="server" Text='<%# Bind("RedniBroj") %>' ID="TxtRedniBrojInsert"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" ID="btnEdit" CssClass="btn btn-default"></asp:Button>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" Text="Update" CommandName="Update" CausesValidation="false" ID="btnUpdate" CssClass="btn btn-default"></asp:Button>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button runat="server" Text="Insert" CommandName="Insert" ID="btnInsert" CssClass="btn btn-default"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" CssClass="btn btn-default" ID="btnDelete"></asp:Button>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" CssClass="btn btn-default" ID="btnCancel"></asp:Button>
                </EditItemTemplate>
                <FooterTemplate>
                     <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" ID="btnCancelInsert" CssClass="btn btn-default"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        
    <asp:HiddenField ID="HiddenlLinija" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    <!-- Administracija stajalista kraj -->
</asp:Content>

