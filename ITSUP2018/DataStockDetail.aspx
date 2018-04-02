<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataStockDetail.aspx.cs" Inherits="ITSUP2018.DataStockDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_tbEquip_Date, #ContentPlaceHolder1_tbDate_Start_Claim, #ContentPlaceHolder1_tbDate_End_Claim").datepicker({
                dateFormat: 'mm/dd/yy',
                beforeShow: function () {
                    $(".ui-datepicker").css('font-size', 14)
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Icon/Manage.png" />Editing Data
        <span style="text-align: right; float: right;"><a href="DataStock.aspx">
            <img src="Image/Icon/Manage.png" />Data Stock</a></span>
    </div>
    <div>
        <div class="ps-div-title-red">Please fill data</div>
        <table class="ps-table-1" style="margin: 0 auto;">
            <tr id="trEquip_Date" runat="server">
                <td class="col1">Equip_Date</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Date" runat="server" CssClass="ps-textbox" placeHolder="Equip_Date"></asp:TextBox>
                </td>
            </tr>
            <tr id="trEquip_Name" runat="server">
                <td class="col1">Equip_Name</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Name" runat="server" CssClass="ps-textbox" placeHolder="Equip_Date"></asp:TextBox>
                </td>
            </tr>

            <tr id="trID_Equip_Type" runat="server">
                <td class="col1">ID_Equip_Type</td>
                <td class="col2">
                    <asp:TextBox ID="tbID_Equip_Type" runat="server" CssClass="ps-textbox" placeHolder="ID_Equip_Type"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Serial" runat="server">
                <td class="col1">Equip_Serial</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Serial" runat="server" CssClass="ps-textbox" placeHolder="Equip_Serial"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Asset" runat="server">
                <td class="col1">Equip_Asset</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Asset" runat="server" CssClass="ps-textbox" placeHolder="Equip_Asset"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Remark" runat="server">
                <td class="col1">Equip_Remark</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Remark" runat="server" CssClass="ps-textbox" placeHolder="Equip_Remark"></asp:TextBox>
                </td>
            </tr>

            <tr id="trDate_Start_Claim" runat="server">
                <td class="col1">Date_Start_Claim</td>
                <td class="col2">
                    <asp:TextBox ID="tbDate_Start_Claim" runat="server" CssClass="ps-textbox" placeHolder="Date_Start_Claim"></asp:TextBox>
                </td>
            </tr>

            <tr id="trDate_End_Claim" runat="server">
                <td class="col1">Date_End_Claim</td>
                <td class="col2">
                    <asp:TextBox ID="tbDate_End_Claim" runat="server" CssClass="ps-textbox" placeHolder="Date_End_Claim"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Case_Claim" runat="server">
                <td class="col1">Equip_Case_Claim</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Case_Claim" runat="server" CssClass="ps-textbox" placeHolder="Equip_Case_Claim"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Case_Brand" runat="server">
                <td class="col1">Equip_Case_Brand</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Case_Brand" runat="server" CssClass="ps-textbox" placeHolder="Equip_Case_Brand"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Status" runat="server">
                <td class="col1">Equip_Status</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Status" runat="server" CssClass="ps-textbox" placeHolder="Equip_Status"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_File" runat="server">
                <td class="col1">Equip_File</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_File" runat="server" CssClass="ps-textbox" placeHolder="Equip_File"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_PC" runat="server">
                <td class="col1">Equip_PC</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_PC" runat="server" CssClass="ps-textbox" placeHolder="Equip_PC"></asp:TextBox>
                </td>
            </tr>

        </table>
        <div style="text-align: center; margin-top: 10px;">
            <asp:LinkButton ID="lbuS1Back" runat="server" CssClass="ps-button" OnClick="lbuS1Back_Click">Back</asp:LinkButton>
        </div>

    </div>
</asp:Content>
