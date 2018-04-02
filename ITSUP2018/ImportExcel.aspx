<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImportExcel.aspx.cs" Inherits="ITSUP2018.ImportExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="ps-header">
        <img src="Image/Icon/Manage.png" />Import Data
        <span style="text-align: right; float: right;"><a href="DataStock.aspx">
            <img src="Image/Icon/Manage.png" />Search Excel</a></span>
    </div>
    <div>

        <div class="ps-div-title-red">Select Excel File</div>
        <table class="ps-table-1" style="margin: 0 auto; margin-bottom: 10px;">
            <tr>
                <td class="col1">
                    <asp:FileUpload ID="FUExcel" runat="server" CssClass="center-block" />
                </td>

                <td class="col2">
                    <asp:Button ID="btnInsertExcel" runat="server" CssClass="btn btn-block" OnClick="btnInsertExcel_Click" Text="Insert Data" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
