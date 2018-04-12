<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataStock.aspx.cs" Inherits="ITSUP2018.DataStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="css/cssGridview/jquery-1.11.1.min.js"></script>
    <script src="css/cssGridview/jquery.dataTables.min.js"></script>
    <link href="css/cssGridview/bootstrap-theme.css" rel="stylesheet" />
    <link href="css/cssGridview/dataTables.jqueryui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').dataTable({
                "bLengthChange": true,
                "paging": true,
                "sPaginationType": "full_numbers",                    //For Different Paging  Style
                // "scrollY": 400,                                     // For Scrolling
                "jQueryUI": true                                      //Enabling JQuery UI(User InterFace)
            });
        });
    </script>
    <style type="text/css">
        .paging_full_numbers span.paginate_button {
            background-color: #fff;
        }

            .paging_full_numbers span.paginate_button:hover {
                background-color: #ccc;
            }

        .paging_full_numbers span.paginate_active {
            background-color: #99B3FF;
        }
        .center{
            text-align: center;
            width:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header">
            <img src="Image/Icon/Manage.png" />Search Data Stock
        <span style="text-align: right; float: right;"><a href="ImportExcel.aspx">
            <img src="Image/Icon/Manage.png" />Import File Excel</a></span>
        </div>
        <div style="margin-top: 30px">
            <table class="table table-striped table-bordered " style="font-family: Serif;" id="example">
                <thead>
                    <tr>
                        <th class="center">Equip_Rep</th>
                        <th class="center">Equip_Name</th>
                        <th class="center">Equip_location</th>
                        <th class="center">Equip_Asset</th>
                        <th class="center">Equip_Remark</th>
                        <th class="center">Equip_Case_Claim</th>
                        <th class="center">Actions</th>
                    </tr>
                </thead>
                <tbody id="tlist" runat="server">
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
