<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EPi.Gadgets.NewRelic.Models.NewRelicSettings>" %>
<%@ Import Namespace="EPiServer.Shell.Web.Mvc.Html" %>
<% Html.RequiredClientResources("Header"); %>
<div class="epi-formArea epi-padding">
    <% Html.BeginGadgetForm("SaveConfiguration"); %>

    <fieldset>
        <legend>Settings</legend>
        <div class="epi-size10">
            <%= Html.LabelFor(m => m.ApiKey, new { @class = "epi-size10" })%>
            <%= Html.TextBoxFor(m => m.ApiKey, new { @class = "epi-size30" })%>
            <%= Html.ValidationMessageFor(m => m.ApiKey)%>
        </div>
        <div class="epi-size10">
            <%= Html.LabelFor(m => m.MachineId, new { @class = "epi-size10" })%>
            <%= Html.TextBoxFor(m => m.MachineId, new { @class = "epi-size3" })%>
            <%= Html.ValidationMessageFor(m => m.MachineId)%>
        </div>

        <%= Html.HiddenFor(m => m.GadgetId, new { @Value = Html.GetGadgetId() })%>
    </fieldset>
    <div>
        <%= Html.AcceptButton() %>
    </div>
    <% Html.EndForm(); %>
</div>
