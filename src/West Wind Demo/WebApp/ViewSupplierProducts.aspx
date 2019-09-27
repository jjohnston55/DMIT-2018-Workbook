<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplierProducts.aspx.cs" Inherits="WebApp.ViewSupplierProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">View Supplier Products</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="SupplierRepeater" runat="server"
                DataSourceID="SupplierProductDataSource"
                ItemType="WestWindSystem.DataModels.SupplierSummary">
                <ItemTemplate>
                    <h2><%# Item.CompanyName %></h2>
                    <p><%# Item.ContactName %> - <%# Item.Phone %></p>
                    <blockquote>
                        <asp:Repeater ID="ProductRepeater" runat="server"
                            DataSource="<%# Item.ProductSummary %>"
                            ItemType="WestWindSystem.DataModels.SupplierProduct">
                            <HeaderTemplate>
                                <table>
                            </HeaderTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Item.ProductName %></td>
                                    <td><%# Item.CategoryName %></td>
                                    <td style="text-align: right;"><%# $"{Item.UnitPrice:C}" %></td>
                                    <td><%# Item.QuantityPerUnit %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </blockquote>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <asp:ObjectDataSource ID="SupplierProductDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="ListSupplierProducts" 
        TypeName="WestWindSystem.BLL.ProductManagementController"></asp:ObjectDataSource>
</asp:Content>
