<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SOZ.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .modalBackground {
background-color:#000;
filter:alpha(opacity=80);
opacity:0.8;
} 
        </style>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col col-2 col-sm-2 col-lg-2 col-xl-2">
    <div class="inner-addon left-addon">
    <i class=" glyphicon fa fa-barcode"></i>
    <asp:TextBox runat="server" ID="txtBarCode" AutoPostBack="true" OnTextChanged="txtBarCode_TextChanged" CssClass="form-control" placeholder="Código de barras" autofocus="autofocus" TextMode="Number"></asp:TextBox>
</div>
            </div>
        <div class="col col-5 col-sm-5 col-lg-5 col-xl-5"></div>
        <div style="position:relative;right:0px;" class="col col-5 col-sm-5 col-lg-5 col-xl-5">
    <div class="inner-addon left-addon">
    <i class=" glyphicon" style="color:lightgreen;font-size:50px">₡</i>
            <asp:TextBox runat="server" ID="txtMonto" BackColor="Black" Width="100%" Height="90px" Font-Size="100px" ForeColor="LightGreen" style="text-align:right" TextMode="Number" Enabled="false" Text="0.00"></asp:TextBox>
        </div>
            </div>
        </div>
    
    <div class="row">
        <div class="col col-12 col-sm-12 col-lg-12 col-xl-12">
            <asp:GridView CssClass=" table table-hover" runat="server" ID="grvVenta"></asp:GridView>
            </div>
        </div>
</asp:Content>
