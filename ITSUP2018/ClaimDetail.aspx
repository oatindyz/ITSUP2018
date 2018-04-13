<%@ Page Title="Claim Detail" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClaimDetail.aspx.cs" Inherits="ITSUP2018.ClaimDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_tbEquip_Date, #ContentPlaceHolder1_tbDate_Call_Claim, #ContentPlaceHolder1_tbDate_Claim, #ContentPlaceHolder1_tbDate_Sent").datepicker({
                dateFormat: 'dd/mm/yy',
                beforeShow: function () {
                    $(".ui-datepicker").css('font-size', 14)
                }
            });
        });
    </script>
    <style>
        .col2{
            width:500px
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Icon/Manage.png" />Editing Claim
        <span style="text-align: right; float: right;"><a href="Claim.aspx">
            <img src="Image/Icon/Manage.png" />Claim</a></span>
    </div>
    <div class="panel panel-default">
            <div class="panel-heading">
                <div class="ps-div-title-red">Claim Details</div>
                <div class="panel-body">
                    <table class="ps-table-1" style="margin: 0 auto;">
            <tr id="trEquip_Rep" runat="server">
                <td class="col1">Equip_Rep</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Rep" runat="server" CssClass="ps-textbox" placeHolder="Equip_Rep"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Date" runat="server">
                <td class="col1">Equip_Date</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Date" runat="server" CssClass="ps-textbox" placeHolder="Equip_Date"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_location" runat="server">
                <td class="col1">Equip_location</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_location" runat="server" CssClass="ps-textbox" placeHolder="Equip_location"></asp:TextBox>
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

            <tr id="trDate_Call_Claim" runat="server">
                <td class="col1">Date_Call_Claim</td>
                <td class="col2">
                    <asp:TextBox ID="tbDate_Call_Claim" runat="server" CssClass="ps-textbox" placeHolder="Date_Call_Claim"></asp:TextBox>
                </td>
            </tr>

            <tr id="trCase_Claim" runat="server">
                <td class="col1">Case_Claim</td>
                <td class="col2">
                    <asp:TextBox ID="tbCase_Claim" runat="server" CssClass="ps-textbox" placeHolder="Case_Claim"></asp:TextBox>
                </td>
            </tr>

            <tr id="trCase_Brand" runat="server">
                <td class="col1">Case_Brand</td>
                <td class="col2">
                    <asp:TextBox ID="tbCase_Brand" runat="server" CssClass="ps-textbox" placeHolder="Case_Brand"></asp:TextBox>
                </td>
            </tr>

            <tr id="trDate_Claim" runat="server">
                <td class="col1">Date_Claim</td>
                <td class="col2">
                    <asp:TextBox ID="tbDate_Claim" runat="server" CssClass="ps-textbox" placeHolder="Date_Claim"></asp:TextBox>
                </td>
            </tr>

            <tr id="trCase_Remark" runat="server">
                <td class="col1">Case_Remark</td>
                <td class="col2">
                    <asp:TextBox ID="tbCase_Remark" runat="server" CssClass="ps-textbox" placeHolder="Case_Remark"></asp:TextBox>
                </td>
            </tr>

            <tr id="trDate_Sent" runat="server">
                <td class="col1">Date_Sent</td>
                <td class="col2">
                    <asp:TextBox ID="tbDate_Sent" runat="server" CssClass="ps-textbox" placeHolder="Date_Sent"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Status" runat="server">
                <td class="col1">Equip_Status</td>
                <td class="col2">
                    <asp:HiddenField ID="HFvalueCheck" runat="server" />
                    <asp:RadioButton ID="cbtbEquip_StatusY" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="Complete" />
                    <asp:RadioButton ID="cbtbEquip_StatusN" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="Not Complete" />
                </td>
            </tr>
        </table>
        <div style="text-align: center; margin-top: 10px;">
            <asp:LinkButton ID="lbuBack" runat="server" CssClass="ps-button" OnClick="lbuBack_Click">Back</asp:LinkButton>
            <asp:LinkButton ID="lbuSave" runat="server" CssClass="ps-button" OnClick="lbuSave_Click">Save</asp:LinkButton>
        </div>
                </div>
            </div>
        </div>
        
</asp:Content>