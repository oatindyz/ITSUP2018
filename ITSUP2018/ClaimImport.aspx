<%@ Page Title="Claim Import" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClaimImport.aspx.cs" Inherits="ITSUP2018.ClaimImport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="ps-header">
        <img src="Image/Icon/Manage.png" />Import Claim
        <span style="text-align: right; float: right;"><a href="Claim.aspx">
            <img src="Image/Icon/Manage.png" />Search Claim</a></span>
    </div>
    <div>
        <div class="ps-div-title-red">Select Excel File</div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-body">
                    <div class="col-md-8 text-left">
                        <span style="padding: 5px 15px; float: left">File:</span>
                        <asp:FileUpload ID="FUExcel" runat="server" Style="margin-left: 15px; float: left; cursor: pointer; width: 300px;" CssClass="center-block" />
                        <asp:Button ID="btnInsertExcel" runat="server" Style="margin-left: 10px; float: left; cursor: pointer; width: 150px;" CssClass="btn btn-block" OnClick="btnInsertExcel_Click" Text="Insert Data" />
                    </div>
                    <div class="col-md-4 text-right">
                        <asp:Button ID="btnDownloadFormat" runat="server" Style="margin-right: 10px; float: right; cursor: pointer; width: 150px;" CssClass="btn btn-block" OnClick="btnDownloadFormat_Click" Text="DownloadFormat" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
