﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security; // For the Settings class
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
                Response.Redirect("~", true);
            if(!IsPostBack)
            {
                // Load up the info on the supplier
                // TODO: Replace hard-coded supplier ID with the user's supplier ID
                SupplierInfo.Text = "Temp supplier: ID 2";

            }
        }

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Ship")
            {
                // Gather information from the form to send to the BLL for shipping
                //  - ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
                int orderId = 0;
                Label orderIdLabel = e.Item.FindControl("OrderIdLabel") as Label; // safe cast the Control object to a Label object
                if(orderIdLabel != null)
                    orderId = int.Parse(orderIdLabel.Text);

                ShippingDirections shipInfo = new ShippingDirections(); // blank object instance
                DropDownList shipViaDropDown = e.Item.FindControl("ShipperDropDown") as DropDownList;
                if (shipViaDropDown != null) // if I got the control
                    shipInfo.ShipperId = int.Parse(shipViaDropDown.SelectedValue);

                TextBox trackingCode = e.Item.FindControl("TrackingCode") as TextBox;
                if (trackingCode != null)
                    shipInfo.TrackingCode = trackingCode.Text;

                TextBox freightCharge = e.Item.FindControl("FreightCharge") as TextBox;
                if (freightCharge != null && decimal.TryParse(freightCharge.Text, out decimal price))
                    shipInfo.FreightCharge = price;

                List<ShippedItem> goods = new List<ShippedItem>();
                GridView gv = e.Item.FindControl("ProductsGridView") as GridView;
                if (gv != null)
                {
                    foreach(GridViewRow row in gv.Rows)
                    {
                        // get productId and shipQty
                        HiddenField prodId = row.FindControl("ProductId") as HiddenField;
                        TextBox qty = row.FindControl("ShipQuantity") as TextBox;

                        if(prodId != null && qty != null && short.TryParse(qty.Text, out short quantity))
                        {
                            ShippedItem item = new ShippedItem
                            {
                                Product = prodId.Value,
                                Quantity = quantity
                            };
                            goods.Add(item);
                        }
                    }
                }

                var controller = new OrderProcessingController();
                controller.ShipOrder(orderId, shipInfo, goods);
            }
        }
    }
}