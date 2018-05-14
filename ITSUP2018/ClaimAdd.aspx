<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClaimAdd.aspx.cs" Inherits="ITSUP2018.ClaimAdd" %>
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
        .textred{
            color:red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Icon/Manage.png" />เพิ่มรายการแจ้งซ่อม
        <span style="text-align: right; float: right;"><a href="Claim.aspx">
            <img src="Image/Icon/Manage.png" />Claim</a></span>
    </div>
    <div class="panel panel-default">
            <div class="panel-heading">
                <div class="ps-div-title-red">Add Claim</div>
                <div class="panel-body">
                    <table class="ps-table-1" style="margin: 0 auto;">
            <tr id="trEquip_Rep" runat="server">
                <td class="col1">เลขที่เอกสาร <span class="textred">*</span></td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Rep" runat="server" CssClass="ps-textbox" placeHolder="เลขที่เอกสาร"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Date" runat="server">
                <td class="col1">วันที่เอกสาร <span class="textred">*</span></td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Date" runat="server" CssClass="ps-textbox" placeHolder="วันที่เอกสาร"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_location" runat="server">
                <td class="col1">Location ต้นทางที่ส่งมาซ่อม</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_location" runat="server" CssClass="ps-textbox" placeHolder="Location ต้นทางที่ส่งมาซ่อม"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Name" runat="server">
                <td class="col1">ชื่อรุ่นคอมพิวเตอร์ <span class="textred">*</span></td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Name" runat="server" CssClass="ps-textbox" placeHolder="ชื่อรุ่นคอมพิวเตอร์"></asp:TextBox>
                </td>
            </tr>

            <tr id="trID_Equip_Type" runat="server">
                <td class="col1">อุปกรณ์ประเภท <span class="textred">*</span></td>
                <td class="col2">
                    <asp:RadioButton ID="RB_Type_PC" runat="server" CssClass="radio_button radio_button_default" GroupName="Typed" Text="PC" />
                    <asp:RadioButton ID="RB_Type_NB" runat="server" CssClass="radio_button radio_button_default" GroupName="Typed" Text="Notebook" />
                </td>
            </tr>

            <tr id="trEquip_Serial" runat="server">
                <td class="col1">หมายเลข Serial</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Serial" runat="server" CssClass="ps-textbox" placeHolder="หมายเลข Serial"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Asset" runat="server">
                <td class="col1">หมายเลข Asset</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Asset" runat="server" CssClass="ps-textbox" placeHolder="หมายเลข Asset"></asp:TextBox>
                </td>
            </tr>

            <tr id="trEquip_Remark" runat="server">
                <td class="col1">อาการอุปกรณ์ที่เสีย</td>
                <td class="col2">
                    <asp:TextBox ID="tbEquip_Remark" runat="server" CssClass="ps-textbox" placeHolder="อาการอุปกรณ์ที่เสีย"></asp:TextBox>
                </td>
            </tr>

            <tr id="trDate_Call_Claim" runat="server">
                <td class="col1">วันที่โทรแจ้งเคลม <span class="textred">*</span></td>
                <td class="col2">
                    <asp:TextBox ID="tbDate_Call_Claim" runat="server" CssClass="ps-textbox" placeHolder="วันที่โทรแจ้งเคลม"></asp:TextBox>
                </td>
            </tr>

            <tr id="trCase_Claim" runat="server">
                <td class="col1">เลขเคสงาน <span class="textred">*</span></td>
                <td class="col2">
                    <asp:TextBox ID="tbCase_Claim" runat="server" CssClass="ps-textbox" placeHolder="เลขเคสงาน" onkeypress="return isNumberKey(event)"></asp:TextBox>
                </td>
            </tr>

            <tr id="trCase_Brand" runat="server">
                <td class="col1">เคสแบรนที่แจ้ง <span class="textred">*</span></td>
                <td class="col2">
                    <asp:RadioButton ID="RB_Case_Brand_Lenovo" runat="server" CssClass="radio_button radio_button_default" GroupName="CaseBrand" Text="Lenovo" />
                    <asp:RadioButton ID="RB_Case_Brand_HP" runat="server" CssClass="radio_button radio_button_default" GroupName="CaseBrand" Text="HP" />
                    <asp:RadioButton ID="RB_Case_Brand_Dell" runat="server" CssClass="radio_button radio_button_default" GroupName="CaseBrand" Text="Dell" />
                </td>
            </tr>

           
        </table>
        <div style="text-align: center; margin-top: 10px;">
            <asp:LinkButton ID="lbuBack" runat="server" CssClass="ps-button ekknidRight" OnClick="lbuBack_Click">Back</asp:LinkButton>
            <asp:LinkButton ID="lbuSave" runat="server" CssClass="ps-button ekknidLeft" OnClick="lbuSave_Click">Save</asp:LinkButton>
        </div>
                </div>
            </div>
        </div>
        
</asp:Content>